﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class Name
    {
        protected Name()
        {

        }
        public Name(string firstName, string? lastName)
        {
            FirstName = firstName;
            LastName = lastName;

        }
        
        public string FirstName { get; set; }
        public string? LastName { get; set; }

    }
}
