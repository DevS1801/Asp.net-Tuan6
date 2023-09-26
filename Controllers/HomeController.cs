using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using Tuan6.Models;
namespace Tuan6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult showProduct()
        {
            ConnectProduct obj = new ConnectProduct();
            List<Product> pro = obj.getDataAdapter();

            return View(pro);
        }
        [HttpPost]
        //public ActionResult showProduct()
        //{
           

        //    return View(pro);
        //}
        //public ActionResult addLoai()
        //{
        //    return View();
        //}

        public ActionResult search(string txt_search)
        {
            ConnectProduct obj = new ConnectProduct();
            List<Product> lst = obj.searchproduct(txt_search);
            ViewBag.SL = lst.Count();
            return View(lst);
        }
        public ActionResult Delete(string id)
        {
            ConnectProduct obj = new ConnectProduct();
            int kt=  obj.delete(id);
            if (kt == 1)
                ViewBag.mess = "Thành CÔng";
            else
                ViewBag.mess = "ktc";
            return RedirectToAction("showProduct");
        }
    }
}