using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;
using WC.Repository.Contracts;

namespace WC.Service.Implementations
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<User> GetNotes()
        {
            return mapper.Map<IEnumerable<Model.User>,IEnumerable<User>>(_repository.GetUsers());
        }

        public User GetUserById(int id)
        {
            return mapper.Map<Model.User, User>(_repository.GetUserById(id));
        }

        public void InsertUser(string username, string mail, string ip, bool banned, string banReason, int level, int roleId)
        {
            User model = new()
            {
                UserName =username,
                Mail = mail,
                Ip = ip,
                Banned = banned,
                BanReason = banReason,
                Level = level,
                RoleId = roleId
            };

            _repository.InsertUser(mapper.Map<User, Model.User>(model));
            _repository.Save();
        }

        public void DeleteLogicUser(int userId)
        {
            User user = mapper.Map<Model.User, User>(_repository.GetUserById(userId));
            user.Active = false;
            _repository.UpdateUser(mapper.Map<User, Model.User>(user));
            _repository.Save();
        }

        public void DeleteUser(int userId)
        {
            _repository.DeleteUser(userId);
            _repository.Save();
        }

        public void UpdateNote(string username, string mail, string ip, bool banned, string banReason, int level, int roleId, int userId)
        {
            User user = mapper.Map<Model.User, User>(_repository.GetUserById(userId));
            user.UserName = username;
            user.Mail = mail;
            user.Ip = ip;
            user.Banned = banned;
            user.BanReason = banReason;
            user.Level = level;
            user.RoleId = roleId;

            _repository.UpdateUser(mapper.Map<User, Model.User>(user));
            _repository.Save();
        }
    }
}
