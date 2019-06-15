namespace Check1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    using Check1.Domain;
    using Check1.Domain.Enums;
    using Check1.Models;
    using Check1.Service;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly IStoreService storeService;

        public HomeController(ICollection<Vendor> vendors, IStoreService storeService)
        {
            this.storeService = storeService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(OrderModel orderModel)
        {
            var order = await storeService.BuyAsync(new Order { OrderDetails = { new OrderDetail { ItemType = ItemType.TShirt, Amount = orderModel.TShirtAmount }, new OrderDetail { ItemType = ItemType.DressShirt, Amount = orderModel.DressShirtAmount } } }, 1, HttpContext.RequestAborted);
            return View(order);
        }

        public IActionResult Sell()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sell(OrderModel orderModel)
        {
            var order = await storeService.SellAsync(new Order { OrderDetails = { new OrderDetail { ItemType = ItemType.TShirt, Amount = orderModel.TShirtAmount }, new OrderDetail { ItemType = ItemType.DressShirt, Amount = orderModel.DressShirtAmount } } }, 1, HttpContext.RequestAborted);
            return View(order);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}