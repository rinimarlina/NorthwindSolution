using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Services.Abstraction;
using NorthwindContracts.Dto.Order;
using NorthwindContracts.Dto.OrderDetail;
using NorthwindContracts.Dto.Product;
using System;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    public class ProductsOnSaleController : Controller
    {
        private IServiceManager _serviceManager;

        public ProductsOnSaleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        // GET: ProductsOnSaleController
        public async Task<ActionResult> Index()
        {
            var productOnSale = await _serviceManager.ProductService.GetProductOnSale(false);
            return View(productOnSale);
        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(ProductDto productDto)
        {
            if(ModelState.IsValid)
            {
                var products = productDto;
                var order = new OrderForCreateDto
                {
                    OrderDate = DateTime.Now,
                    RequiredDate = DateTime.Now.AddDays(3)
                };
                var orderDetail = new OrderDetailForCreateDto
                {
                    ProductId = products.ProductId,
                    UnitPrice = (decimal)products.UnitPrice,
                    Quantity = 0,
                    Discount = 0
                };
                _serviceManager.ProductService.CreateOrder(order, orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
        }

        // GET: ProductsOnSaleController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productOnSale = await _serviceManager.ProductService.GetProductOnSaleById((int)id, false);
            if (productOnSale == null)
            {
                return NotFound();
            }
            return View(productOnSale);
        }

            // GET: ProductsOnSaleController/Create
            public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsOnSaleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsOnSaleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductsOnSaleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsOnSaleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductsOnSaleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
