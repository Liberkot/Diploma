using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diploma.Models
{
    public class DouConnectionClass
    {
        public static int GetAgeGroup(DateTime bday)//Вычислить возраст во время подачи заявки в очередь
        {
            DateTime today = DateTime.Today;
            return today.Year - bday.Year;
        }

        public static int GetNewAgeGroup(DateTime bday)//Вычислить текущий возраст
        {
            var today = new DateTime(DateTime.Today.Year,9,1);
            return today.Year - bday.Year;
        }
    }
}