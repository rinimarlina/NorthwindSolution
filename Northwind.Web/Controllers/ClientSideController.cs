
using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Base;
using NorthwindContracts.Dto.Category;

namespace Northwind.Web.Controllers
{
    public class ClientSideController : Controller
    {
        public IRepositoryManager _repositoryManager;

        public ClientSideController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public JsonResult GetTotalProductByCategory()
        {
            var result = _repositoryManager.ProductRepository.GetTotalProductByCategory();
            return Json(result);
        }

        public IActionResult IndexJS()
        {
            return View();
        }

        public IActionResult IndexJQuery()
        {
            return View();
        }

        public IActionResult IndexChart()
        {
            return View();
        }

        public IActionResult PostCategory([FromBody]CategoryForCreateDto categoryForCreateDto)
        {
            var categoryDto = categoryForCreateDto;
            var result = new JsonResult(null)
            {
                Value = "Succeed"
            };
            return Ok(result);
        }
    }
}
