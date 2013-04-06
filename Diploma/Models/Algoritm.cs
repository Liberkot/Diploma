using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public static class Algoritm
    {
        public static void Distribution()
        {
            var entity = new DiplomEntities();
            GetDou.GetDouGroupNum(1);

            foreach (var dou in entity.Dou)
            {
                while (dou.dou_group01 > 0)
                {
                    var UserListOfDou = entity.DouConnection.ToList().Where(i => i.douid == dou.id).Where(i=>i.status != 0);//Все поступающие в это ДОУ
                    if (UserListOfDou != null)
                    {
                        var minkoeff = UserListOfDou.Min(i => i.dou_user_rate); //Минимальный коэффициент
                        var MinUsers = UserListOfDou.ToList().Where(i => i.dou_user_rate == minkoeff);
                        Enrollment(MinUsers);
                    }
                }
            }
        }

        static void Enrollment(IEnumerable<DouConnection> users)
        {
            foreach (var k in users)
            {
             k.userid   
            }
        }
    }
}