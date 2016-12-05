using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public class Account
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Function Function { get; set; }

        public List<Wristband> WristbandList { get; set; }
        public List<Rental> RentalList { get; set; }
        public List<Contribution> ContributionList { get; set; }
        public List<Reservation> ReservationList { get; set; }

        /// <summary>
        /// Used to get account information from the database
        /// </summary>
        /// <param name="ID">Identidication for an account</param>
        /// <param name="username">Username of a user used for Authentication</param>
        /// <param name="password">Password of a user used for Authentication</param>
        /// <param name="function">Function of a user used for authorization<param> 
        /// <param name="WristbandList">List of wristbands an account currently has</param>
        /// <param name="RentalList">List of Rentals an account currently has</param>
        /// <param name="ContributionList">List of Contributions an account currently has</param>
        /// <param name="ReservationList">List of Reservations an account currently has<param> 
        public Account(int ID, string username, string password, Function function, List<Wristband> WristbandList, List<Rental> RentalList, List<Contribution> ListContribution , List<Reservation> ListReservation)
        {
            this.ID = ID;    
            this.Username = username;
            this.Password = password;
            this.Function = function;
            this.WristbandList = WristbandList;
            this.RentalList = RentalList;
            this.ContributionList = ContributionList;
            this.ReservationList = ReservationList;
        }

        /// <summary>
        /// Used to create account information in the database
        /// </summary>
        /// <param name="username">Username of a user used for Authentication</param>
        /// <param name="password">Password of a user used for Authentication</param>
        /// <param name="function">Function of a user used for authorization<param> 
        public Account(string username, string password, Function function)
        {         
            this.Username = username;
            this.Password = password;
            this.Function = function;
        }

        /// <summary>
        /// Check if changes for account are allowed in the database
        /// </summary>
        /// <returns>True if changes are allowed false if not</returns>
        //public bool EditAccount()
        //{
        //    bool Check = DatabaseEditAccount.EditAccount(ID, Username, Password, Function);
        //    return Check;
        //}

        /// <summary>
        /// Checks if the new account is allowed in the database
        /// </summary>
        /// <returns>True if changes are allowed false if not</returns>

        //public bool CreateAccount()
        //{
        //    bool Check = DatabaseCreateAccount.CreateAccount(ID, Username, Password, Function);
        //    return Check;
        //}

        /// <summary>
        /// Tostring methods for Account
        /// </summary>
        /// <returns>Object account to a string</returns>

        public override string ToString()
        {
            return Username + ", " + Username + ", " + Function;
        }




    }
}