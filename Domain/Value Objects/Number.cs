using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class Number
    {
        public Number()
        {

        }
        public Number(string number)
        {
            CellPhoneNumber = number;
        }
        [Phone]
        public string CellPhoneNumber { get; set; }


    }
}
