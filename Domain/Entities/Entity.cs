using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Updated_At { get; set; } = DateTime.Now;
        public DateTime Created_At { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
    }
}
