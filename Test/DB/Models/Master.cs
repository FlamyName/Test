using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB.Models
{
    internal class Master
    {
        [Key]
        public int Id { get; set; }
        public string FullNameMaster { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
