﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DB.Models
{
    internal class Status
    {
        [Key]
        public int Id { get; set; }
        public string NameStatus { get; set; }
    }
}