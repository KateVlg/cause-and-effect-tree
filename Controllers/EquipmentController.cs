using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VSTU.EquipmentDiagnostics.Services;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {
        private IEquipmentService EquipmentSrv { get; set; }
        private IFailureService FailureSrv { get; set; }
        private IRootCauseService RootCauseSrv { get; set; }
        private ISymptomService SymptomSrv { get; set; }
        private IFailureComplectService FailureComplectSrv { get; set; }
        private IMatrixService MatrixSrv { get; set; }


        public EquipmentController(IEquipmentService equipmentService, IFailureService failureService, IRootCauseService rootCauseService, ISymptomService symptomService, IFailureComplectService failureComplectService, IMatrixService matrixService)
        {
            EquipmentSrv = equipmentService;
            FailureSrv = failureService;
            RootCauseSrv = rootCauseService;
            SymptomSrv = symptomService;
            FailureComplectSrv = failureComplectService;
            MatrixSrv = matrixService;
        }

        [HttpGet]
        public ActionResult<List<Equipment>> GetEquipments()
        {
            try
            {
                return EquipmentSrv.GetEquipments();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<List<Equipment>> GetEquipmentsByName(string name)
        {
            try
            {
                return EquipmentSrv.GetEquipmentsByName(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<Equipment?> GetEquipmentById(Guid id)
        {
            try
            {
                return EquipmentSrv.GetEquipmentById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public ActionResult<Equipment> Post(string nameEquipment, int[,] matrix, List<Failure> failures, List<RootCause> rootCauses, List<Symptom> symptoms)
        {
            try
            {
                // Проверка и добавление новых отказов, основных причин и симптомов
                foreach (var failure in failures)
                {
                    if (failure.Id == Guid.Empty)
                    {
                        FailureSrv.CreateFailure(failure.Name);
                    }
                }

                foreach (var rootCause in rootCauses)
                {
                    if (rootCause.Id == Guid.Empty)
                    {
                        RootCauseSrv.CreateRootCause(rootCause.Name);
                    }
                }

                foreach (var symptom in symptoms)
                {
                    if (symptom.Id == Guid.Empty)
                    {
                        SymptomSrv.CreateSymptom(symptom.Name);
                    }
                }

                // Трансформация матрицы в комплекты отказов
                List<FailureComplect> failureComplects = MatrixSrv.MatrixToFailureComplects(matrix, failures, rootCauses, symptoms);

                // Создание и сохранение оборудования
                Equipment equipment = new Equipment
                {
                    Name = nameEquipment,
                    FailureComplects = failureComplects
                };

                return EquipmentSrv.CreateEquipment(equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            try
            {
                EquipmentSrv.DeleteEquipment(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
