using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB.Models
{
    internal class User
    {
        [Key]
        public int Id { get; set; }
        public string LoginUser { get; set; }
        public string PasswordUser { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
