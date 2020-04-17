using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Playground.Models;

namespace Playground.Controllers
{
    public class ShopController : Controller
    {
        static public List<Product> Products = new List<Product>
        {
            new Product("Eggs", 20),
            new Product("Milk", 10),
            new Product("Bread", 15)
        };

        public IActionResult Index()
        {
            ViewBag.groceries = Products;
            return View();
        }

        public IActionResult AddingPage()
        {
            return View();
        }

        public IActionResult AddProduct(string name, string price)
        {
            if (name != null && price != null)
            {
                if (int.TryParse(price, out int priceResult))
                {
                    Products.Add(new Product(name, priceResult));
                }
            }

            return Redirect("/Shop/Index");
        }
    }
}