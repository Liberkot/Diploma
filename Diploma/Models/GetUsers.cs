using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class GetUser
    {
        public static IEnumerable<User> GetUsersByAuth(int auth)
        {
            var entity = new DiplomEntities();
            var users = entity.User.ToList().Where(i => i.authid == auth);
            return users;
        } 

        public static int GetNumberInLine(int user)
        {
            var entity = new DiplomEntities();
            var usersbefore = entity.User.ToList().Where(i => i.id < user);
            int before = usersbefore.Count();
            return before+1;
        }

        public static User GetUsersById(int id)
        {
            var entity = new DiplomEntities();
            try
            {
                var user = entity.User.SingleOrDefault(i => i.id == id);
                return user;
            }
            catch
            {
                return null;
            }
         }

        public static bool DelUserById(int id)
        {
            var entity = new DiplomEntities();
            try
            {
                var user = entity.User.SingleOrDefault(i => i.id == id);
                var douconnections = entity.DouConnection.ToList().Where(i => i.userid == id);
                entity.User.DeleteObject(user);
                foreach (var connection in douconnections)
                {
                    entity.DouConnection.DeleteObject(connection);
                }
                entity.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}