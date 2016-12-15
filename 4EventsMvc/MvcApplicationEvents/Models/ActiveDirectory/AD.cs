using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices.AccountManagement;

namespace MvcApplicationEvents.Models.ActiveDirectory
{
    public class AD
    {
        public string GetUser(string accountname)
        {   
            UserPrincipal user = UserPrincipal.FindByIdentity(new PrincipalContext
           (ContextType.Domain, "ptsevents.local"), IdentityType.SamAccountName, accountname);
            return "";
        }
        public void CreateUser(string accountname, string password, string email)
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


        public void AddUserToGroup(string accountname, string groupname)
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
        public void GetGroupFromUser(string accountname)
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
                        CurrentAccount.TranslateFunction(function);
                    }               
                }
            }
            catch (Exception)
            {
                 // do something with the error 
            }
        }
    }
}