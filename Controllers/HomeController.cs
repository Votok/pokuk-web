using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using pokuk_common;

namespace web.controllers
{
    public class HomeController : Controller
    {
        private readonly GalleryOptions _options;

        public HomeController(IOptions<GalleryOptions> optionsAccessor)
        {
            _options = optionsAccessor.Value;
        }

        public IActionResult Index()
        {
            var years = GalleryService.Instance(_options).Years.OrderByDescending(y => y.Year);
            ViewBag.model = years;

            return View();
        }

        public IActionResult Detail(string id)
        {
            var model = GalleryService.Instance(_options).GetEvent(id);
            if (model == null)
                return RedirectToAction("Index");

            ViewBag.model = model;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
