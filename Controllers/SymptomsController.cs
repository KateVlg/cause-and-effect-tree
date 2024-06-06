using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VSTU.EquipmentDiagnostics.Services;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SymptomsController : ControllerBase
    {
        private ISymptomService SymptomService { get; set; }
      

        public SymptomsController(ISymptomService symptomService)
        {
            SymptomService = symptomService;
           
        }

        [HttpGet]
        public ActionResult<List<Symptom>> Get()
        {try
            {
                return SymptomService.GetSymptoms();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<List<Symptom>> GetSymptomsName(string name)
        {
            try
            {
                return SymptomService.GetSymptomsByName(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<Symptom> GetById(Guid id)
        {
            try
            {
                return SymptomService.GetSymptomById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //public ActionResult <Symptom> Post(string nameSymptom)
        //{
        //    try
        //    {
        //        return SymptomService.CreateSymptom(nameSymptom);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpDelete]
        public ActionResult Delete(Guid id)
        {
            try
            {
                SymptomService.DeleteSymptom(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
