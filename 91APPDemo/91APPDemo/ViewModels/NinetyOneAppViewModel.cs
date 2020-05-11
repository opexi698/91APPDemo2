using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _91APPDemo.ViewModels
{
    public class NinetyOneAppViewModel
    {
        public bool ChangeStatus { get; set; }
        public string OrderId { get; set; }
        public string OrderItem { get; set; }
        public int Price { get; set; }
        public int Cost { get; set; }
        public string Status { get; set; }
        public string ProductId { get; set; }
    }
    public class OrderId
    {
        public string Id { get; set; }
    }
    public class Product
    {
        public string ProductName { get; set; }
        public int Cost { get; set; }
    }
}