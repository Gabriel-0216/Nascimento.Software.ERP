using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class Email
    {
        public Email()
        {

        }
        public Email(string Email)
        {
            email = Email;
        }
        [EmailAddress]
        public string email { get; set; }


    }
}
