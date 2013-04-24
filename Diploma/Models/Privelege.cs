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
            list.Add(new SelectListItem { Text = "Нет", Value = "1", Selected = true });
            list.Add(new SelectListItem { Text = "Дети сироты, дети оставшиеся без попечения родителей", Value = "4" });
            list.Add(new SelectListItem { Text = "Дети, чьи родители являются лицами из числа детей сирот или детей оставшиеся без попечения родителей", Value = "4" });
            list.Add(new SelectListItem { Text = "Дети судей", Value = "4" });
            list.Add(new SelectListItem { Text = "Дети прокуроров и сотрудников Следственного комитета", Value = "4" });
            list.Add(new SelectListItem { Text = "Дети граждан, подвергшихся воздействию радиации вследствие катастрофы на Чернобыльской АЭС", Value = "4" });

            list.Add(new SelectListItem { Text = "Дети из многодетных семей", Value = "2" });
            list.Add(new SelectListItem { Text = "Дети инвалиды и дети, один из родителей которого является инвалидом", Value = "2" });
            list.Add(new SelectListItem { Text = "Дети военнослужащих, проходящих военную службу по контракту или по призыву, по месту жительства их семей", Value = "2" });
            list.Add(new SelectListItem { Text = "Дети сотрудников полиции", Value = "2" });
            list.Add(new SelectListItem { Text = "Дети сотрудников полиции погибших (умерших) в связи с осуществлением служебной деятельности либо умерших...", Value = "2" });
            
            list.Add(new SelectListItem { Text = "Дети одиноких матерей", Value = "3" });
            list.Add(new SelectListItem { Text = "Дети работников ДОУ", Value = "3" });
            list.Add(new SelectListItem { Text = "Дети, находящиеся в трудной жизненной ситуации", Value = "3" });

            return list;
        }
    }
}