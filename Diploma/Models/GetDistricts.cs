using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class GetDistricts
    {
        public static IEnumerable<Models.District> GetAllDistrics()
        {
            var entity = new DiplomEntities();
            return entity.District;
        }
    }
}