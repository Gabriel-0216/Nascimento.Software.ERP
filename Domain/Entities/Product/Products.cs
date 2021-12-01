using Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Product
{
    public class Products : Entity
    {
        public bool SetProductName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            ProductName = new Name(name, null);
            return true;
        }
        public bool SetValue(decimal value)
        {
            if(value == 0)
            {
                return true;
            }
            Value = value;
            return true;
        }
        public bool SetDescription(string description) 
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                return false;
            }
            Description = description;
            return true;
        }
        public bool AddProductQuantityStock(ProductStock productStock) 
        { 
            if(productStock.Quantity == 0)
            {
                return false;
            }
            AvailableQuantity += productStock.Quantity;
            return true;
        }
        public bool RemoveProductQuantity(int value) 
        {
            if(value == 0)
            {
                return false;
            }
            AvailableQuantity -= value;
            return true;
        }

        public Name ProductName { get; private set; }
        public decimal Value { get; private set; }
        public string Description { get; private set; }
        public int AvailableQuantity { get; private set; }

    }
}
