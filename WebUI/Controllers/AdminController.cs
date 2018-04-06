using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Enities;

namespace WebUI.Controllers
{
    
    public class AdminController : Controller
    {
        private IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        [Authorize]
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        [Authorize]
        public ViewResult Edit(int productId)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductId == productId);
            return View(product);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Product product, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeType = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} был сохранен", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // cheta ne to
                return View(product);
            }
        }

        [Authorize]
        public ViewResult Create()
        {
            return View("Edit", new Product());
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Delete(int productId)
        {
            Product deletedProduct = repository.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} был удален", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}