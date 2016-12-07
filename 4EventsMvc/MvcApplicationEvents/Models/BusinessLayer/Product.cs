using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Product
    {
        List<Copy> CopyList = new List<Copy>();

        public int ID { get; set; }
        public string Brand { get; set; }
        public string Serie{ get; set; }
        public int Typenummer { get; set; }
        public int Prijs { get; set; }

        public Product(int id, string brand, string serie, int typenummer, int prijs)
        {
            this.ID = id;
            this.Brand = brand;
            this.Serie = serie;
            this.Typenummer = typenummer;
            this.Prijs = prijs;
        }

        public void GetAvailableCopies()
        {
            //this.CopyList = //methode in database
        }



    }
}