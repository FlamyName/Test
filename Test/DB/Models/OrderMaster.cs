using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB.Models
{
    internal class OrderMaster
    {
        [Key]
        public int Id { get; set; }
        public string Detail { get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }
    }
}
