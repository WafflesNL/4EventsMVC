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

        public Rental()
        {

        }
        //aanmaken
        public Rental(DateTime datein, DateTime dateout, int price, bool paid)
        {   
            this.Datein = datein;
            this.Dateout = Dateout;
            this.Price = price;
            this.Paid = false;

        }

        //ophalen
        public Rental(int id, DateTime datein, DateTime dateout, int price, bool paid)
        {
            this.ID = id;
            this.Datein = datein;
            this.Dateout = Dateout;
            this.Price = price;
            this.Paid = paid;

        }

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