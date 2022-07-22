using AutoMapper;
using Coffe.Data;
using Coffe.Entities;
using Coffe.Models.Users.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffe.Repos
{
    public interface IAcountRepo
    {
        Task<User> GetUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<bool> DeleteUser(Guid id);
        Task<bool> CheckUser(Guid id);
        Task<string> AddUser(RequestCreateUserModel model);
    }
    public class AcountRepo : IAcountRepo
    {
        private readonly AppContextdb _contextdb;
        private readonly IMapper _mapper;
        public AcountRepo(AppContextdb contextdb, IMapper mapper)
        {
            _contextdb = contextdb;
            _mapper = mapper;
        }

        public async Task<string> AddUser(RequestCreateUserModel model)
        {
            if (model.UserName.Length < 6)
                return "User Name Length " + model.UserName.Length;

            if (!await _contextdb.UserTypes.AsNoTracking().Where(f => f.Id == model.UserTypeId).AnyAsync())
                return "Notfound userType";

            var user = _mapper.Map<User>(model);

            await _contextdb.Users.AddAsync(user);

            await _contextdb.SaveChangesAsync();

            return user.Id.ToString();
        }

        public async Task<bool> CheckUser(Guid id)
        {
            var check = await _contextdb.Users.Where(f => f.Id == id).AnyAsync();

            return check;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _contextdb.Users.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                _contextdb.Remove(user);
                await _contextdb.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _contextdb.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetUser(Guid id)
        {
            var user = await _contextdb.Users.Where(f => f.Id == id).FirstOrDefaultAsync();
            return user;
        }
    }

}
