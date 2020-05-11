using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace _91APPDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        /// <summary>
        /// Get datas then return values to view
        /// </summary>
        /// <returns></returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult NinetyOneAPPDemo()
        {
            Models.Entities db = new Models.Entities();
            var result = from ol in db.OrderList
                         join p in db.Product on ol.Product_Id equals p.Id
                         select new ViewModels.NinetyOneAppViewModel
                         {
                             ChangeStatus = false,
                             OrderId = ol.Id,
                             OrderItem = p.ProductName,
                             Price = ol.Price,
                             Cost = p.Cost,
                             Status = ol.Status,
                             ProductId = p.Id
                         };
            return View(result.ToList<ViewModels.NinetyOneAppViewModel>());
        }
        /// <summary>
        /// Update OrderList
        /// </summary>
        /// <param name="Id">OrderId</param>
        /// <returns></returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult ChangeOrderStatus([FromBody]string data)
        {
            Models.Entities db = new Models.Entities();
            var editOrder = db.OrderList.Find(data);
            editOrder.Status = "To be shipped";
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }
        /// <summary>
        /// Get product then return to view
        /// </summary>
        /// <param name="Id">Product Id</param>
        /// <returns></returns>
        public ActionResult Product(string Id)
        {
            Models.Entities db = new Models.Entities();
            var result = db.Product.Find(Id);

            ViewModels.Product pr = new ViewModels.Product
            {
                ProductName = result.ProductName,
                Cost = result.Cost
            };
            return View(pr);
        }
    }
}