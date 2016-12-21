using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;

namespace MvcApplicationEvents.Models
{
    public static class ActiveDirectory
    {
        public static string GetUser(string accountname)
        {

            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext
               (ContextType.Domain, "ptsevents.local"), IdentityType.SamAccountName, accountname);

                if (user.SamAccountName == accountname)
                {
                    return user.SamAccountName;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                // do something with this error
                return null;
            }
           
        }
        public static void CreateUser(string accountname, string password, string email)
        {
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "ptsevents.local"))
                {
                    using (UserPrincipal up = new UserPrincipal(pc))
                    {
                        up.SamAccountName = accountname;
                        up.EmailAddress = email;
                        up.SetPassword(password);
                        up.Enabled = true;
                        up.Save();
                    }
                }
            }
            catch (Exception)
            {
                // do something with the error }
            }
        }


        public static void AddUserToGroup(string accountname, string groupname)
        {
            try
            {
                using (PrincipalContext pc = new PrincipalContext(ContextType.Domain, "ptsevents.local"))
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(pc, groupname);
                    group.Members.Add(pc, IdentityType.SamAccountName, accountname);
                    group.Save();
                }
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                // do something with the error
            }
        }
        public static Function GetGroupFromUser(string accountname)
        {
           
            try
            {
               UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext
              (ContextType.Domain, "ptsevents.local"), IdentityType.SamAccountName, accountname);
                foreach (GroupPrincipal group in user.GetGroups())
                {
                    if (group.Name != "Domain Users")
                    {
                       string function = group.Name;
                       return CurrentAccount.TranslateFunction(function);
                    }               
                }
            return 0;
          }
            catch (Exception)
            {
                 // do something with the error 
            }
            return 0;
        }
    }
}