using Microsoft.AspNetCore.Mvc;
using System;
using WC.Service.Contracts;
using WC.DTO;
using WC.API.Model.User;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
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
        [HttpPost("create")]
        public ActionResult CreateUser(InsertUserRequest request)
        {
            service.InsertUser(
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
        [HttpPut("{id}/update")]
        public ActionResult UpdateUser(int id, UpdateUserRequest request)
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
                id);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut("{id}/inactivate")]
        public ActionResult InactivateUser(int id)
        {
            service.DeleteLogicUser(id);
            return Ok();
        }

        [HttpDelete("{id}/delete")]
        public ActionResult DeleteUser(int id)
        {
            service.DeleteUser(id);
            return Ok();
        }

        [HttpPut("{id}/resetPassword")]
        public ActionResult ResetPassword(int id, ResetPasswordUserRequest request)
        {
            service.resetPassword(id, request.NewPassword);
            return Ok();
        }
    }
}
