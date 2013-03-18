using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class GetStreets
    {
        public static IEnumerable<Models.Street> GetAllStreets()
        {
            var entity = new DiplomEntities();
            return entity.Street;
        }

        public static IEnumerable<Models.Street> GetStreetsById(int ID)
        {
            var entity = new DiplomEntities();
            var streets = entity.Street.ToList().Where(i => i.districtid == ID);
            return streets;
        }
    }
}