using AutoMapper;
using Coffe.Data;
using Coffe.Entities;
using Coffe.Models.Users.Request;
using Microsoft.EntityFrameworkCore;

namespace Coffe.Repository
{
    public interface IAccountRepository
    {
        Task<User> GetUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<bool> DeleteUser(Guid id);
        Task<bool> CheckUser(Guid id);
        Task<bool?> UpdateUser(RequestUpdateUserModel model);
        Task<bool?> AddUser(RequestCreateUserModel model);

    }

    public class AccountRepository : IAccountRepository
    {
        private  AppContextdb _contextdb;
        private readonly IMapper _mapper;

        public AccountRepository(AppContextdb contextdb,IMapper mapper)
        {
            this._contextdb = contextdb;
            this._mapper = mapper;
        }

        public async Task<bool?> UpdateUser(RequestUpdateUserModel model)
        {
            var user = await _contextdb.Users.Where(f => f.Id == model.Id).FirstOrDefaultAsync();
            if (user != null)
            {
                //user = _mapper.Map<User>(model);

                await _contextdb.Users.Update(user);

                //_contextdb.Update<User>(user);
                await _contextdb.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool?> AddUser(RequestCreateUserModel model)
        {
            //if (model.UserName.Length <6)
            //    return false;
            if (!await _contextdb.UserTypes.AsNoTracking().Where(f=>f.Id == model.UserTypeId).AnyAsync())
                return false;
            var user = _mapper.Map<User>(model);

            await _contextdb.Users.AddAsync(user);
            await _contextdb.SaveChangesAsync();

            return true;
            //if (model.UserName.Length < 6)
            //    return "User Name Length " + model.UserName.Length;

            //if (!await _contextdb.UserTypes.AsNoTracking().Where(f => f.Id == model.UserTypeId).AnyAsync())
            //    return "Notfound userType";

            //var user = _mapper.Map<User>(model);

            //await _contextdb.Users.AddAsync(user);

            //await _contextdb.SaveChangesAsync();

            //return user.Id.ToString();
        }

        //public async Task<bool?> AddUser( string fullname, string username, string pasword, Guid userTypeId)
        //{
        //    User user = new User();
        //    user.FullName = fullname;
        //    user.UserName = username;
        //    user.Password = pasword;
        //    user.UserTypeId = userTypeId;
        //    _contextdb.Add(user);
        //    _contextdb.SaveChangesAsync();
        //    return true;
        //}

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
