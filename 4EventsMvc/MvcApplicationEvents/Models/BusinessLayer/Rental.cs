using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Rental
    {
        List<Copy> CopyList = new List<Copy>();

        public int ID { get; set; }
        public DateTime Datein { get; set; }
        public DateTime Dateout { get; set; }
        public int Price { get; set; }
        public bool Paid { get; set; }

        /// <summary>
        /// creates a rental
        /// </summary>  
        public Rental()
        {

        }

        /// <summary>
        /// creates a rental
        /// </summary>  
        /// <param name="datein">datestart of the rental<param>
        /// <param name="dateout">dateend of the rental<param>
        /// <param name="price">totalPrice of the rental<param>
        /// <param name="paid">true if paid false if not<param>
        public Rental(DateTime datein, DateTime dateout, int price, bool paid)
        {   
            this.Datein = datein;
            this.Dateout = Dateout;
            this.Price = price;
            this.Paid = false;

        }
        /// <summary>
        /// creates a rental
        /// </summary>
        /// <param name="id">ID of the rental<param>
        /// <param name="datein">datestart of the rental<param>
        /// <param name="dateout">dateend of the rental<param>
        /// <param name="price">totalPrice of the rental<param>
        /// <param name="paid">true if paid false if not<param>
        public Rental(int id, DateTime datein, DateTime dateout, int price, bool paid)
        {
            this.ID = id;
            this.Datein = datein;
            this.Dateout = Dateout;
            this.Price = price;
            this.Paid = paid;

        }

        /// <summary>
        /// Creates a new rent in the database
        /// </summary>
        /// <param name="ProductList">list of products that have to be added</param>
        /// <param name="barcode">barcode which the products have to be added to</param>
        /// <returns>Returns true if the event is allowed in the database false if it is not</returns>
        public bool Rent(List<Product> productlist, string barcode)
        {
            if (DatabaseCreateMaterial.CreateRental(productlist, barcode) == true)
            {
                return true;
            }

            else
            {
                return false;
            }
            
        }

        /// <summary>
        ///  Returns rented products
        /// </summary>
        /// <param name="barcode">barcode which the products have to be added to</param>
        /// <returns>Returns true if the event is allowed in the database false if it is not</returns>
        public bool Return(string barcode)

        {
            if (DatabaseCreateMaterial.ReturnItems(barcode) == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }





    }
}