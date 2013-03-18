using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Diploma.Models;

namespace Diploma.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FAQ()
        {
            return View();
        }
        public ActionResult Check()
        {
            return View();
        }
        public ActionResult GetInLine()
        {
            return View(new Users());
        }

        public string GetStreetsForDistrict(string id)
        {
            var streets = new List<SelectListItem>();

            var streetsbyid = GetStreets.GetStreetsById(Convert.ToInt32(id));
            foreach (var i in streetsbyid)
            {
                streets.Add(new SelectListItem() { Text = i.street1, Value = i.id.ToString() });
            }
            if (id == null)
            {
                streets.Add(new SelectListItem() { Text = "Выберите улицу", Value = "-1" });
            }

            return new JavaScriptSerializer().Serialize(streets);
        }

        public string GetHousesForStreet(string id)
        {
            var houses = new List<SelectListItem>();

            var housesbyid = GetHouses.GetHousesById(Convert.ToInt32(id));
            foreach (var i in housesbyid)
            {
                houses.Add(new SelectListItem() { Text = i.num, Value = i.num });
            }
            if (id == null)
            {
                houses.Add(new SelectListItem() { Text = "Выберите номер дома", Value = "-1" });
            }

            return new JavaScriptSerializer().Serialize(houses);
        }

        public string GetMainDouForDistricts(string id)
        {
            var maindou = new List<SelectListItem>();

            var maindoubyid = GetDou.GetDouById(id);
            foreach (var i in maindoubyid)
            {
                maindou.Add(new SelectListItem() { Text = i.dou_name, Value = i.id.ToString() });
            }
            if (id == null)
            {
                maindou.Add(new SelectListItem() { Text = "Выберите главные ДОУ", Value = "-1" });
            }

            return new JavaScriptSerializer().Serialize(maindou);
        }

        public string GetAnotherDouForDistricts(string id)
        {
            var anotherdou = new List<SelectListItem>();

            var anotherdoubyid = GetDou.GetDouById(id);
            foreach (var i in anotherdoubyid)
            {
                anotherdou.Add(new SelectListItem() { Text = i.dou_name, Value = i.id.ToString() });
            }
            if (id == null)
            {
                anotherdou.Add(new SelectListItem() { Text = "Выберите главные ДОУ", Value = "-1" });
            }

            return new JavaScriptSerializer().Serialize(anotherdou);
        }

        public string GetYearForBirth(string id)
        {
            var types = new List<SelectListItem>();
            types.Add(new SelectListItem { Text = "2013", Value = "2013" });
            types.Add(new SelectListItem { Text = "2014", Value = "2014" });
            types.Add(new SelectListItem { Text = "2015", Value = "2015" });
            types.Add(new SelectListItem { Text = "2016", Value = "2016" });
            types.Add(new SelectListItem { Text = "2017", Value = "2017" });
            types.Add(new SelectListItem { Text = "2018", Value = "2018" });
            types.Add(new SelectListItem { Text = "2019", Value = "2019" });
            types.Add(new SelectListItem { Text = "2020", Value = "2020" });
            int u = types.Count - 1;
            switch (id)
            {
                case "2006":
                    do
                    {
                        types.RemoveAt(types.Count - 1);
                    } while (types.Count > 1);
                    break;
                case "2007":
                    do
                    {
                        types.RemoveAt(types.Count - 1);
                    } while (types.Count > 2);
                    break;
                case "2008":
                    do
                    {
                        types.RemoveAt(types.Count - 1);
                    } while (types.Count > 3);
                    break;
                case "2009":
                    do
                    {
                        types.RemoveAt(types.Count - 1);
                    } while (types.Count > 4);
                    break;
                case "2010":
                    do
                    {
                        types.RemoveAt(types.Count - 1);
                    } while (types.Count > 5);
                    break;
                case "2011":
                    do
                    {
                        types.RemoveAt(types.Count - 1);
                    } while (types.Count > 6);
                    break;
                case "2012":
                    do
                    {
                        types.RemoveAt(types.Count-1);
                    } while (types.Count > 7);
                    break;
            }
            if (id == null)
            {
                for (int k = 0; k < types.Count; k++)
                    types.RemoveAt(k);
                types.Add(new SelectListItem() { Text = "Выберите год поступления", Value = "-1" });
            }

            return new JavaScriptSerializer().Serialize(types);
        }
    }
}
