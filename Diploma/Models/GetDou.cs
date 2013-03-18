using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class GetDou
    {
        public static IEnumerable<Models.Dou> GetAllDou()
        {
            var entity = new DiplomEntities();
            return entity.Dou;
        }

        public static IEnumerable<Models.Dou> GetDouById(string ID)
        {
            var entity = new DiplomEntities();
            var dous = entity.Dou.ToList().Where(i => i.dou_district.ToString() == ID);
            return dous;
        } 
    }
}