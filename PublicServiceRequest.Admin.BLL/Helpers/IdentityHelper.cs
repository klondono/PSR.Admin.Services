using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PublicServiceRequest.Admin.BLL.Helpers
{
    public static class IdentityHelper
    {
        public static string GetActiveDirectoryDisplayName(this IIdentity identity)
        {
            string userName = identity.Name.Replace("\\", "/");
            DirectoryEntry de = new DirectoryEntry("WinNT://" + userName);
            return de.Properties["fullName"].Value.ToString();
        }

        public static String GetEmail(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                return UserPrincipal.FindByIdentity(principalContext, userIdentity.Name).EmailAddress;
            }
        }

        public static String GetEmail(string userName)
        {
            return GetUserPrincipal(userName).EmailAddress;
        }

        public static String GetFullName(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                var userPrincipal = UserPrincipal.FindByIdentity(principalContext, userIdentity.Name);
                return userPrincipal.GivenName + " " + userPrincipal.Surname;
            }
        }

        public static String GetFullName(string userName)
        {
                var userPrincipal = GetUserPrincipal(userName);
                return userPrincipal.GivenName + " " + userPrincipal.Surname;
        }

        public static bool IsInActiveDirectoryGroup(this IPrincipal user, string group)
        {
            if (String.IsNullOrEmpty(group))
            {
                return false;
            }

            return user.IsInRole(@"Miamidade\" + group);
        }

        public static List<String> GetActiveDirectoryGroups(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                using (PrincipalSearchResult<Principal> src = UserPrincipal.FindByIdentity(principalContext, userIdentity.Name).GetGroups(principalContext))
                {
                    return src.Select(x => x.SamAccountName).ToList();
                }
            }
        }

        public static Guid? GetUserID(this IIdentity userIdentity)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                return UserPrincipal.FindByIdentity(principalContext, userIdentity.Name).Guid;
            }
        }

        public static Guid? GetUserID(string userName)
        {
            return GetUserPrincipal(userName).Guid;
        }

        private static UserPrincipal GetUserPrincipal(string userName)
        {
            using (PrincipalContext principalContext = new PrincipalContext(ContextType.Domain, "Miamidade"))
            {
                var userPrincipal = UserPrincipal.FindByIdentity(principalContext, userName);
                if (userPrincipal == null)
                {
                    throw new Exception($"Invalid UserName: {userName}");
                }
                else
                {
                    return userPrincipal;
                }
            }
        }
    }
}
