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

        public static int GetDouAllGroupsCount(int douid)
        {
            var entity = new DiplomEntities();
            var dou = entity.Dou.SingleOrDefault(i=>i.id == douid);
            int sum = 0;
            sum = dou.dou_group01 + dou.dou_group12 + dou.dou_group23 + dou.dou_group34 + dou.dou_group45 +
                  dou.dou_group56 + dou.dou_group67;
            return sum;
        }


        public static IEnumerable<Models.Dou> GetDouById(string ID)
        {
            var entity = new DiplomEntities();
            var dous = entity.Dou.ToList().Where(i => i.dou_district.ToString() == ID);
            return dous;
        }

        /*public static int GetDouGroupNum(int age)
        {
            int num = 0;
            var entity = new DiplomEntities();
            var dous = entity.Dou;
            switch (age)
            {
                case 1: foreach (var t in dous)
                    {
                        num = num + t.dou_group01;
                    }
                    break;
                case 2: foreach (var t in dous)
                    {
                        num = num + t.dou_group12;
                    }
                    break;
                case 3: foreach (var t in dous)
                    {
                        num = num + t.dou_group23;
                    }
                    break;
                case 4: foreach (var t in dous)
                    {
                        num = num + t.dou_group34;
                    }
                    break;
                case 5: foreach (var t in dous)
                    {
                        num = num + t.dou_group45;
                    }
                    break;
                case 6: foreach (var t in dous)
                    {
                        num = num + t.dou_group56;
                    }
                    break;
                case 7: foreach (var t in dous)
                    {
                        num = num + t.dou_group67;
                    }
                    break;
                case 8:
                    num = 0;
                    break;
                default: foreach (var t in dous)
                    {
                        num = num + t.dou_group01;
                    }
                    break;
            }
            return num;
        }*/
    }
}