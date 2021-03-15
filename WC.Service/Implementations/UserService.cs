using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WC.DTO;
using WC.Repository.Contracts;
using WC.Service.Contracts;
namespace WC.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        private readonly IMapper mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<User> GetUsers()
        {
            return mapper.Map<IEnumerable<Model.User>,IEnumerable<User>>(_repository.GetUsers());
        }

        public User GetUserById(int id)
        {
            return mapper.Map<Model.User, User>(_repository.GetUserById(id));
        }

        public void InsertUser(string username, string password, string mail, string ip, bool banned, string banReason, int level, int roleId)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            
            User model = new()
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
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

        public void UpdateUser(string username, string password, string mail, string ip, bool banned, string banReason, int level, int roleId, int userId)
        {
            User user = mapper.Map<Model.User, User>(_repository.GetUserById(userId));
            user.UserName = username;
            user.Mail = mail;
            user.Ip = ip;
            user.Banned = banned;
            user.BanReason = banReason;
            user.Level = level;
            user.RoleId = roleId;

            if (password != null)
            {
                byte[] passwordHash, passwordSalt;

                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _repository.UpdateUser(mapper.Map<User, Model.User>(user));
            _repository.Save();
        }

        private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
