using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Test.AbstractService;

namespace Test.UserService
{
    internal class UserService : AbstractService.AbstractService
    {
        public UserService() : base() { }

        private static int _userRole; 


        private static int _masterId;

        public bool IsUser(string login, string password)
        {
            try
            {
                var user = _db.Users.Any(x => x.LoginUser == login && x.PasswordUser == password);
                if(user)
                {
                    
                    _userRole = _db.Users.FirstOrDefault(x => x.LoginUser == login)!.RoleId;

                    var userId = _db.Users.FirstOrDefault(x => x.LoginUser == login)!.Id;
                    if(_db.Masters.Any(x => x.UserId == userId))
                    {
                        _masterId = _db.Masters.FirstOrDefault(x => x.UserId == userId)!.Id;
                    }

                }

                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        public  int GetRole()
        {
            return _userRole;
        }

        public static int GetIdMaster()
        {
            return _masterId;
        }

    }
}
