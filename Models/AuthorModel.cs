﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSconsole.Models
{
    class AuthorModel
    {
        public int Id { get; set; }

         public string Name { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public string Nationality { get; set; }
        public bool IsAlive { get; set; }
    }
}
