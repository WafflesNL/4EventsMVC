using MvcApplicationEvents.Models.ActiveDirectory;
using MvcApplicationEvents.Models.DatabaseLayer.DatabaseAccountManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplicationEvents.Models
{
    public static class CurrentAccount
    {
        public static string Username { get; set; }
        public static string Password{ get; set; }
        public static int ID { get; set; }
        public static Function Function { get; set; }
        public static string Email { get; set; }

      
        /// <summary>
        /// Checks if an account exists in the database.
        /// </summary>
        /// <param name="password">The password of an account</param>
        /// <param name="Username">The username of an account</param>
        /// <returns>Trie if an account exists false if not</returns>
        public static bool Login(string password, string username)
        {
            Account account = DatabaseLogin.CheckUser(Password, Username);
            if (account != null)
            {   ActiveDirectory.CheckUser
                account.Password = Password; }
            //if (ID != 0 && GetUserName(ID) && GetPassword(ID) && GetName(ID) && GetFunction(ID) && GetEventID(ID))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// Checks if an account exists in the database
        /// </summary>
        /// <param name="ID">The id of an account</param>
        /// <returns>True if account exists false if not</returns>
        private static bool GetUserName(int ID)
        {
            //string Check = DatabaseLogin.GetString(ID, "Gebruikersnaam");
            //if (Check != "")
            //{
            //    Username = Check;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// Gets the password that belongs to the corresponding AccountID
        /// </summary>
        /// <param name="ID">The id of an account</param>
        /// <returns>True if password exists false if not</returns>
        private static bool GetPassword(int ID)
        {
            //string Check = DatabaseLogin.GetString(ID, "Wachtwoord");
            //if (Check != "")
            //{
            //    Password = Check;
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// Get the function that belongs to the corresponding AccountID
        /// </summary>
        /// <param name="ID">The id of an Account</param>
        /// <returns>True if function exists false if not</returns>
        private static bool GetFunction(int ID)
        {
            //string Check = DatabaseLogin.GetString(ID, "Functie");
            //if (Check != "")
            //{
            //    Function = TranslateFunction(Check);
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }   
   

        /// <summary>
        /// Changes the string to the appropriate Enum.
        /// </summary>
        /// <param name="ParameterFunction">Valid parameters are Bezoeker, Beheerder, Accountbeheerder and Mederwerker</param>
        /// <returns>Returns a single enum Function.</returns>
        public static Function TranslateFunction(string ParameterFunction)
        {
            Function function = Function.Bezoeker;
            switch (ParameterFunction)
            {
                case "Bezoeker":
                    function = Function.Bezoeker;
                    break;
                case "Beheerder":
                    function = Function.Beheerder;
                    break;
                case "Accountbeheerder":
                    function = Function.AccountBeheerder;
                    break;
                case "Medewerker":
                    function = Function.Medewerker;
                    break;
            }
            return function;
        }

        //verkrijg het password en gebruikersnaam uit de database
        public static bool GetIDandPassword()
        {
            Account Account = DatabaseGetAccount.GetUserIDPassword(Username);
            if (Account != null)
            {
                Password = Account.Password;
                ID = Account.ID;
                return true;
            }
            else
            {
                return false;
            }

        }



        /// <summary>
        /// Gets all events from the database
        /// </summary>
        /// <returns>A list with all events that are currently active</returns>
        public static List<Event> GetEvents()
        {
            List<Event> EventList = DatabaseGetEvent.GetEvents();
            return EventList;
        }

        /// <summ
        /// ary>
        /// Gets the password that belongs to the corresponding AccountID
        /// </summary>
        /// <returns>Void</returns>
        public static void UpdateAccount(Account account)
        {
            //Username = account.Username;
            //Password = account.Password;
            //Function = account.Function;
       
        }

        /// <summary>
        /// When user logs out resets the currentaccount data to default
        /// </summary>
        /// <returns>Void</returns>
        public static void RemovePropertys()
        {
            ID = 0;
            Username = null;
            Password = null;
            Function = Function.Bezoeker;      
        }






    }
}