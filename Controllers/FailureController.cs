using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VSTU.EquipmentDiagnostics.Services;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FailureController : ControllerBase
    {
        private IFailureService FailureService { get; set; }


        public FailureController(IFailureService failureService)
        {
            FailureService = failureService;

        }

        [HttpGet]
        public ActionResult<List<Failure>> GetFailures()
        {
            try
            {
                return FailureService.GetFailures();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<List<Failure>> GetFailuresByName(string name)
        {
            try
            {
                return FailureService.GetFailuresByName(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<Failure> GetFailuresById(Guid id)
        {
            try
            {
                return FailureService.GetFailureById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //public ActionResult<Failure> Post(string nameFailure)
        //{
        //    try
        //    {
        //        return FailureService.CreateFailure(nameFailure);
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
                FailureService.DeleteFailure(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
