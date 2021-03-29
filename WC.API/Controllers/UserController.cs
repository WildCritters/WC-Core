using Microsoft.AspNetCore.Mvc;
using System;
using WC.Service.Contracts;
using WC.DTO;
using WC.API.Model.User;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WC.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}", Name = "GetUsersById")]
        public User Get(int id)
        {
            return service.GetUserById(id);
        }

        // GET: api/<UserController>
        [HttpGet]
        public GetUsersResponse GetUsers()
        {
            return new GetUsersResponse()
            {
                Users = this.service.GetUsers()
            };
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult CreateUser(InsertUserRequest request)
        {
            service.CreateUser(
                request.UserName, 
                request.Password, 
                request.Mail, 
                request.Ip, 
                request.Banned, 
                request.BanReason, 
                request.Level, 
                request.RoleId);

            return Ok();
        }

        // PUT api/<UserController>/5
        [HttpPut]
        public ActionResult UpdateUser(UpdateUserRequest request)
        {
            try
            {
                service.UpdateUser(
                request.UserName, 
                request.Password, 
                request.Mail, 
                request.Ip, 
                request.Banned, 
                request.BanReason, 
                request.Level, 
                request.RoleId,
                request.Id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}/inactivate", Name = "InactivateUser")]
        public ActionResult InactivateUser(int id)
        {
            service.DeleteLogicUser(id);
            return Ok();
        }

        [HttpPut("{id}/reset", Name = "ResetUser")]
        public ActionResult ResetPassword(int id, ResetPasswordUserRequest request)
        {
            service.resetPassword(id, request.NewPassword);
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            service.DeleteUser(id);
            return Ok();
        }
    }
}
