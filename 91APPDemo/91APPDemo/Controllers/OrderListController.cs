using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace _91APPDemo.Controllers
{
    public class OrderListController : ApiController
    {
        // GET: api/OrderList
        public IHttpActionResult Get()
        {
            Models.Entities db = new Models.Entities();

            var result = from ol in db.OrderList
                         join p in db.Product on ol.Product_Id equals p.Id
                         select new ViewModels.NinetyOneAppViewModel
                         {
                             ChangeStatus = false,
                             OrderId = ol.Id,
                             OrderItem = p.ProductName,
                             Price = 10,
                             Cost = 10,
                             Status = ol.Status
                         };
            result.ToList();
            return Json(result);
        }

        // GET: api/OrderList/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderList
        /// <summary>
        /// Updat OrderList
        /// </summary>
        /// <param name="data">OrderId</param>
        /// <returns></returns>
        public ActionResult Post([FromBody]ViewModels.OrderId data)
        {
            Models.Entities db = new Models.Entities();
            var editOrder = db.OrderList.Find(data.Id);
            editOrder.Status = "To be shipped";
            db.SaveChanges();
            return new HttpStatusCodeResult(200);
        }

        // PUT: api/OrderList/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderList/5
        public void Delete(int id)
        {
        }
    }
}
