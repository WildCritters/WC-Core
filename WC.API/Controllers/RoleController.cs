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
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService service;

        public RoleController(IRoleService service)
        {
            this.service = service;
        }

        [HttpGet("{id}", Name = "GetRolesById")]
        public async Task<ActionResult> Get(int id)
        {
            var role = await service.GetRoleById(id);
            
            if (role == null)
                return NotFound();

            return Ok(role);
        }

        [HttpGet]
        public async Task<GetRolesResponse> GetRoles()
        {
            return new GetRolesResponse()
            {
                Roles = await this.service.GetRoles()
            };
        }

        [HttpPost]
        public ActionResult Create(CreateRoleRequest request)
        {
            service.CreateRole(request.Name, request.FunctionsId);

            return Ok();
        }

        [HttpPut]
        public ActionResult Update(UpdateRoleRequest request)
        {
            try
            {
                service.UpdateRole(
                    request.Name, 
                    request.FunctionsId,
                    request.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}/inactivate", Name = "InactivateRole")]
        public ActionResult InactivateRole(int id)
        {
            service.DeleteLogicRole(id);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteRole(int id)
        {
            service.DeleteRole(id);
            return Ok();
        }
    }
}
