using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using VSTU.EquipmentDiagnostics.Services;
using VSTU.EquipmentDiagnostics.ObjectModel;

namespace VSTU.EquipmentDiagnostics.RestAPI
{
    [ApiController]
    [Route("[controller]")]
    public class RootCauseController : ControllerBase
    {
        private IRootCauseService RootCauseService { get; set; }


        public RootCauseController(IRootCauseService rootCauseService)
        {
            RootCauseService = rootCauseService;

        }

        [HttpGet]
        public ActionResult<List<RootCause>> GetRootCauses()
        {
            try
            {
                return RootCauseService.GetRootCauses();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<List<RootCause>> GetRootCausesByName(string name)
        {
            try
            {
                return RootCauseService.GetRootCausesByName(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public ActionResult<RootCause> GetRootCauseById(Guid id)
        {
            try
            {
                return RootCauseService.GetRootCauseById(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPost]
        //public ActionResult<RootCause> PostRootCause(string nameRootCause)
        //{
        //    try
        //    {
        //        return RootCauseService.CreateRootCause(nameRootCause);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpDelete]
        public ActionResult DeleteRootCause(Guid id)
        {
            try
            {
                RootCauseService.DeleteRootCause(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
