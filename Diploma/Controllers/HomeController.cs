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

        [HttpGet]
        public ActionResult GetInLine()
        {
            return View(new Users());
        }

        [HttpPost]
        public ActionResult GetInLine(Users model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var entity = new DiplomEntities();
                    entity.User.AddObject(new User
                    {
                        first_name = model.first_name,
                        last_name = model.second_name,
                        third_name = model.third_name,
                        date_birth = model.date_birth,
                        sex = model.sex,
                        type_doc = model.type_doc,
                        series_doc = model.series_doc,
                        number_doc = model.number_doc,
                        date_issue = model.date_issue,
                        adr_district = model.adr_district,
                        adr_street = model.adr_street,
                        adr_house = model.adr_house,
                        pr_type = model.pr_type,
                        pr_first_name = model.pr_first_name,
                        pr_last_name = model.pr_last_name,
                        pr_third_name = model.pr_third_name,
                        pr_series_doc = model.pr_series_doc,
                        pr_number_doc = model.pr_number_doc,
                        pr_date_issue = model.pr_date_issue,
                        year_enter = model.year_enter,
                        during_year_offer = model.during_year_offer,
                        privilege = model.privilege,
                        time_of_study = model.time_of_study,
                        authid = Account.GetName(User.Identity.Name).id
                    });
                    entity.SaveChanges();
                    var i = entity.User.ToList().Last();
                    foreach (var dou in model.main_dou)
                    {
                        entity.DouConnection.AddObject(new DouConnection
                        {
                            douid = Convert.ToInt32(dou),
                            userid = i.id,
                            dou_user_rate = model.privilege,
                            status = 0
                       //authid = Account.GetName(User.Identity.Name).id

                       //main_dou = Convert.ToInt32(model.main_dou),
                       //another_dou = Convert.ToInt32(model.another_dou),
                        });
                        entity.SaveChanges();
                    }
                    foreach (var dou in model.another_dou)
                    {
                        entity.DouConnection.AddObject(new DouConnection
                        {
                            douid = Convert.ToInt32(dou),
                            userid = i.id,
                            dou_user_rate = model.privilege*1.25,
                            status = 0
                            //authid = Account.GetName(User.Identity.Name).id

                            //main_dou = Convert.ToInt32(model.main_dou),
                            //another_dou = Convert.ToInt32(model.another_dou),
                        });
                        entity.SaveChanges();
                    }
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("showError", ex.Message);
            }
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
                houses.Add(new SelectListItem() { Text = i.num, Value = i.id.ToString() });
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
                anotherdou.Add(new SelectListItem() { Text = "Выберите дополнительные ДОУ", Value = "-1" });
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
                        types.RemoveAt(types.Count - 1);
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
