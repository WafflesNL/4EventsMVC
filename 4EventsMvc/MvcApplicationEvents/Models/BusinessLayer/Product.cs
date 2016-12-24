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

        /// <summary>
        /// creates a product
        /// </summary>
        public Product()
        {

        }

        /// <summary>
        /// creates a product
        /// </summary>
        /// <param name="id">ID of the product<param>
        /// <param name="brand">brand of the product<param>
        /// <param name="serie">1st, 2nd, 3rd serie of the product<param>
        /// <param name="type">product type (tent, stoel, etc..)<param>
        /// <param name="prijs">Price of the product<param>
        public Product(int id, string brand, string serie, string type, int prijs)
        {
            this.ID = id;
            this.Brand = brand;
            this.Serie = serie;
            this.Type = type;
            this.Prijs = prijs;
        }

        /// <summary>
        /// creates a product
        /// </summary>
        /// <param name="id">ID of the product<param>
        /// <param name="brand">brand of the product<param>
        /// <param name="serie">1st, 2nd, 3rd serie of the product<param>
        /// <param name="type">product type (tent, stoel, etc..)<param>
        /// <param name="prijs">Price of the product<param>
        /// <param name="aantal">number that has been ordered<param>
        public Product(int id, string brand, string serie, string type, int prijs, int aantal)
        {
            this.ID = id;
            this.Brand = brand;
            this.Serie = serie;
            this.Type = type;
            this.Prijs = prijs;
            this.Aantal = aantal;
        }

        /// <summary>
        /// Gets all available copies from the database
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Product> GetAvailableCopies()
        {
            this.CopyList = DatabaseGetProduct.GetProductAvailable();
            return CopyList;
        }

        /// <summary>
        /// Gets all unavailable copies from the database
        /// </summary>
        /// <returns>A list of products</returns>
        public List<Product> GetAllRentedItems()
        {
            this.CopyList = DatabaseGetProduct.GetRentedProducts();
            return CopyList;
        }



    }
}