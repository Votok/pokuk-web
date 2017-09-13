using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace web.controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var years = GalleryModel.GetInstance().Years.OrderByDescending(y => y.Year);
            ViewBag.years = years;

            return View();
        }
        
        public IActionResult Detail(string id)
        {
             var galleryEvent = GalleryModel.GetInstance().GetGalleryEvent(id);
             if (galleryEvent == null)
                return RedirectToAction("Index");

                ViewBag.galleryEvent = galleryEvent;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
