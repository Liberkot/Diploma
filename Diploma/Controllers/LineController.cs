using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diploma.Models;

namespace Diploma.Controllers
{
    public class LineController : Controller
    {
        //
        // GET: /Line/
        public ActionResult Restricted()
        {
            return View();
        }

        public ActionResult Distributed()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Distribute()
        {
            if (Request.IsAuthenticated)
            {
                if (Account.GetName(User.Identity.Name).admin == true)
                {
                    return View();
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return View("Restricted");
                }
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return View("Restricted");
            }
        }

        [HttpPost]
        public ActionResult Distribute(Algoritm model)
        {
            if (Request.IsAuthenticated)
            {
                if (Account.GetName(User.Identity.Name).admin == true)
                {
                    try
                    {
                        Algoritm.BdayRecalculate();
                        if (model.group01 == true)
                        {
                            ViewData["Raspred1"] = Algoritm.Distribution(1, model.during_year_offer);
                        }
                        if (model.group12 == true)
                        {
                            ViewData["Raspred2"] = Algoritm.Distribution(2, model.during_year_offer);
                        }
                        if (model.group23 == true)
                        {
                            ViewData["Raspred3"] = Algoritm.Distribution(3, model.during_year_offer);
                        }
                        if (model.group34 == true)
                        {
                            ViewData["Raspred4"] = Algoritm.Distribution(4, model.during_year_offer);
                        }
                        if (model.group45 == true)
                        {
                            ViewData["Raspred5"] = Algoritm.Distribution(5, model.during_year_offer);
                        }
                        if (model.group56 == true)
                        {
                            ViewData["Raspred6"] = Algoritm.Distribution(6, model.during_year_offer);
                        }
                        if (model.group67 == true)
                        {
                            ViewData["Raspred7"] = Algoritm.Distribution(7, model.during_year_offer);
                        }
                        ViewData["Raspred"] = Convert.ToInt32(ViewData["Raspred1"]) +
                                              Convert.ToInt32(ViewData["Raspred2"]) +
                                              Convert.ToInt32(ViewData["Raspred3"]) +
                                              Convert.ToInt32(ViewData["Raspred4"]) +
                                              Convert.ToInt32(ViewData["Raspred5"]) +
                                              Convert.ToInt32(ViewData["Raspred6"]) +
                                              Convert.ToInt32(ViewData["Raspred7"]);
                        return View("Distributed");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("showError", ex.Message);
                    }
                }
                else
                {
                    Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    return View("Restricted");
                }
            }
            else
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return View("Restricted");
            }
        }

    }
}
