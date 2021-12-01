using Domain.Entities.Client;
using Domain.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Purchase
{
    public class Purchases : Entity
    {
        public Purchases()
        {
            Products = new List<Products>();
        }
        public bool AddProduct(Products product)
        {
            if(product == null)
            {
                return false;
            }
            Products.Add(product);
            return true;
        }
        public bool RemoveProduct(Products product) 
        {
            if (product == null) return false;

            Products.Remove(product);
            return true;
        }
        public bool SetBuyer(string Id) 
        {
            if (string.IsNullOrWhiteSpace(Id)) return false;

            BuyerId = Id;
            return true;
        }

        public bool FinishPurchase() 
        {
            if (Products == null) return false;


            foreach(var item in Products)
            {
                PurchaseValue += item.Value;
            }
            return true;
        }
        public decimal PurchaseValue { get; set; }
        public string BuyerId { get; set; }
        public Buyer Buyer { get; set; }
        public List<Products> Products { get; set; }
    }
}
