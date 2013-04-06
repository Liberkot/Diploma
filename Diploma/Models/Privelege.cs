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
            list.Add(new SelectListItem {Text = "Нет", Value = "1", Selected = true});
            list.Add(new SelectListItem { Text = "Преимущественная", Value = "0,75"});
            list.Add(new SelectListItem { Text = "Первоочередная", Value = "0,5"});
            list.Add(new SelectListItem { Text = "Внеочередная", Value = "0,25"});
            return list;
        }
    }
}