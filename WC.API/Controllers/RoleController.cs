using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WC.API.Model.Role;
using WC.DTO;
using WC.Service.Contracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService service;

        public RoleController(IRoleService service)
        {
            this.service = service;
        }

        [HttpGet("{id}")]
        public Role Get(int id)
        {
            return service.GetRoleById(id);
        }

        [HttpGet]
        public GetRolesResponse GetRoles()
        {
            return new GetRolesResponse()
            {
                Roles = this.service.GetRoles()
            };
        }

        [HttpPost("create")]
        public ActionResult CreateRole(CreateRoleRequest request)
        {
            service.CreateRole(request.Name, request.FunctionsId);

            return Ok();
        }

        [HttpPut("{id}/update")]
        public ActionResult UpdateRole(int id, UpdateRoleRequest request)
        {
            try
            {
                service.UpdateRole(
                    request.Name, 
                    request.FunctionsId,
                    id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}/inactivate")]
        public ActionResult InactivateRole(int id)
        {
            service.DeleteLogicRole(id);
            return Ok();
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteRole(int id)
        {
            service.DeleteRole(id);
            return Ok();
        }
    }
}
