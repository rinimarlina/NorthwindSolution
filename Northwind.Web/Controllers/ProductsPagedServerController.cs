using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Services.Abstraction;
using NorthwindContracts.Dto.Category;
using NorthwindContracts.Dto.Product;
using X.PagedList;

namespace Northwind.Web.Controllers
{
    public class ProductsPagedServerController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly IServiceManager _serviceContext;
        private readonly IUtilityService _utilityService;
        public ProductsPagedServerController(NorthwindContext context, IServiceManager serviceContext, IUtilityService utilityService)
        {
            _context = context;
            _serviceContext = serviceContext;
            _utilityService = utilityService;
        }

        // GET: ProductsPagedServer
        public async Task<IActionResult> Index(string searchString,
            string currentFilter, string sortOrder, int? page, int? fethSize)
        {
            var pageIndex = page ?? 1;
            var pageSize = fethSize ?? 5;

            //keep state searching value
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var productDtosSearch =
                await _serviceContext.ProductService.GetProductPaged(pageIndex, pageSize, false);

            var totalRows = productDtosSearch.Count();


            if (!String.IsNullOrEmpty(searchString))
            {
                productDtosSearch = productDtosSearch.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()));
            }

            //sorting
            ViewBag.ProductNameSort = String.IsNullOrEmpty(sortOrder) ? "product_name" : "";
            ViewBag.UnitPriceSort = sortOrder == "price" ? "unit_price" : "price";

            var productDtosSort = from p in productDtosSearch
                                  select p;

            switch (sortOrder)
            {
                case "product_name":
                    productDtosSort = productDtosSearch.OrderByDescending(p => p.ProductName);
                    break;
                case "price":
                    productDtosSort = productDtosSearch.OrderBy(p => p.UnitPrice);
                    break;
                case "unitPrice":
                    productDtosSort = productDtosSearch.OrderByDescending(p => p.UnitPrice);
                    break;
                default:
                    productDtosSort = productDtosSearch.OrderBy(p => p.ProductName);
                    break;

            }

            var productDtosPaged =
                new StaticPagedList<ProductDto>(productDtosSort, pageIndex, pageSize - (pageSize - 1), totalRows);

            ViewBag.PagedList = new SelectList(new List<int> { 8, 15, 20 });

            return View(productDtosPaged);
        }

        // Bukan multiple photo
        /*[HttpPost]
        public async Task<IActionResult> CreateProductPhoto(ProductPhotoGroupDto productPhotoGroupDto)
        {
            if (ModelState.IsValid)
            {
                var productPhotoGroup = productPhotoGroupDto;

                var photo1 = _utilityService.UploadSingleFile(productPhotoGroup.Photo1);
                var photo2 = _utilityService.UploadSingleFile(productPhotoGroup.Photo2);
                var photo3 = _utilityService.UploadSingleFile(productPhotoGroup.Photo3);
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View("Create");
        }*/

        // pakai allphoto
        [HttpPost]
        public async Task<IActionResult> CreateProductPhoto(ProductPhotoGroupDto productPhotoGroupDto)
        {
            if (ModelState.IsValid)
            {
                var productPhotoGroup = productPhotoGroupDto;
                var listPhoto = new List<ProductPhotoCreateDto>();
                foreach (var itemPhoto in productPhotoGroup.AllPhoto)
                {
                    var fileName = _utilityService.UploadSingleFile(itemPhoto);
                    var Photo = new ProductPhotoCreateDto {
                        PhotoFilename = fileName,
                        PhotoFileSize = (short?)itemPhoto.Length,
                        PhotoFileType = itemPhoto.ContentType

                    };

                    listPhoto.Add(Photo);
                }
                _serviceContext.ProductService.CreateProductManyPhoto(productPhotoGroupDto.ProductForCreateDto, listPhoto);
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            ViewData["PhotoProductId"] = new SelectList(_context.ProductPhotos, "PhotoProductId");
            return View("Create");
        }
        // GET: ProductsPagedServer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }


            return View(product);
        }

        // GET: ProductsPagedServer/Create
        public async Task <IActionResult> Create()
        {
            var allcategory = await _serviceContext.CategoryService.GetAllCategory(false);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: ProductsPagedServer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductForCreateDto product)
        {
            if (ModelState.IsValid)
            {
                _serviceContext.ProductService.Insert(product);
                return RedirectToAction(nameof(Index));
            }
            var allCategory = await _serviceContext.CategoryService.GetAllCategory(false);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsPagedServer/Edit/5
        public async Task<IActionResult> Edit(int? id, IFormFile filePhoto)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _serviceContext.ProductService.GetProductById((int)id, true);
            if (product == null)
            {
                return NotFound();
            }

            if (filePhoto == null)
            {
                return NotFound();
            }

            var productPhoto = await _serviceContext.ProductPhotoService.GetProductPhotoById((int)id, true);
            if (productPhoto == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);


            return View(product);
        }

        // POST: ProductsPagedServer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsPagedServer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                //.Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsPagedServer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}