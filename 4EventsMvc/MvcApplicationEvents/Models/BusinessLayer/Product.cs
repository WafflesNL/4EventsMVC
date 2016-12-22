using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Product
    {
        List<Product> CopyList = new List<Product>();

        public int ID { get; set; }
        public string Brand { get; set; }
        public string Serie{ get; set; }
        public string Type { get; set; }
        public int Prijs { get; set; }

        public int Aantal { get; set; } 

        public Product()
        {

        }
        public Product(int id, string brand, string serie, string type, int prijs)
        {
            this.ID = id;
            this.Brand = brand;
            this.Serie = serie;
            this.Type = type;
            this.Prijs = prijs;
        }

        public Product(int id, string brand, string serie, string type, int prijs, int aantal)
        {
            this.ID = id;
            this.Brand = brand;
            this.Serie = serie;
            this.Type = type;
            this.Prijs = prijs;
            this.Aantal = aantal;
        }

        public List<Product> GetAvailableCopies()
        {
            this.CopyList = DatabaseGetProduct.GetProductAvailable();
            return CopyList;
        }
        public List<Product> GetAllRentedItems()
        {
            this.CopyList = DatabaseGetProduct.GetRentedProducts();
            return CopyList;
        }



    }
}