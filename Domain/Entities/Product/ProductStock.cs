using Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class ProductStock : Entity
    {
        public bool SetProductId(string Id)
        {
            if (string.IsNullOrWhiteSpace(Id)) return false;

            ProductsId = Id;
            return true;
        }
        public bool SetQuantity(int Quantity)
        {
            if(Quantity <= 0) return false;

            this.Quantity = Quantity;
            return true;
        }
        public string ProductsId { get; private set; }
        public Products Products { get; private set; }
        public int Quantity { get; private set; }



    }
}
