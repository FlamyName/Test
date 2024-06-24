using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB.Models
{
    internal class OrderClient
    {
        [Key]
        public int Id { get; set; }
        public string FullNameClient { get; set; }
        public string Phone {  get; set; }
        public DateTime DateTime { get; set; }
        public string Problem { get; set; }
        public string Device {  get; set; }
        public int MasterId { get; set; }
        public Master Master { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
