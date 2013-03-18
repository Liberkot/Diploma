using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class GetHouses
    {
        public static IEnumerable<Models.House> GetHousesById(int ID)
        {
            var entity = new DiplomEntities();
            var houses = entity.House.ToList().Where(i => i.streetid == ID);
            return houses;
        }
    }
}