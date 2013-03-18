using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diploma.Models
{
    public class Privelege
    {
        public static List<SelectListItem> GetAllPriveleges()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem {Text = "Нет", Value = "0", Selected = true});
            list.Add(new SelectListItem { Text = "Преимущественная", Value = "1"});
            list.Add(new SelectListItem { Text = "Первоочередная", Value = "2"});
            list.Add(new SelectListItem { Text = "Внеочередная", Value = "3"});
            return list;
        }
    }
}