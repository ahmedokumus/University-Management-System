using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Web_Tasarim.Models;

namespace Web_Tasarim.Security
{
    public class UserRolProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            Context context = new Context();
            if (context.Admins.FirstOrDefault(x => x.Username == username) != null)
            {
                var userAdmin = context.Admins.FirstOrDefault(x => x.Username == username);
                return new string[]
                {
                    userAdmin.Role.ToString(),
                };
            }
            else if (context.Officers.FirstOrDefault(x => x.Username == username) != null)
            {
                var userOfficer = context.Officers.FirstOrDefault(x => x.Username == username);
                return new string[]
                {
                    userOfficer.Role.ToString(),
                };
            }
            else if (context.Instructors.FirstOrDefault(x => x.Username == username) != null)
            {
                var userInstructor = context.Instructors.FirstOrDefault(x => x.Username == username);
                return new string[]
                {
                    userInstructor.Role.ToString(),
                };
            }
            else
            {
                var userStudent = context.Students.FirstOrDefault(x => x.Username == username);
                return new string[]
                {
                    userStudent.Role.ToString(),
                };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}