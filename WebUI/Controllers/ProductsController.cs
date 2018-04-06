using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using Domain.Enities;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductsController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                    repository.Products.Count() : 
                    repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            
            return View(model);
                
        }

        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            if (prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}