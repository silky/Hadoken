#region Using References

using System;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Hadoken.Core.Logging;
using Hadoken.Data;

using Hadoken.Web.Models;
using Hadoken.Web.Models.Home;

#endregion

namespace Hadoken.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier));
        }

        [HttpGet]
        public IActionResult Home()
        {
            ElementRepository elementRepository = new ElementRepository();

            return View(new HomeModel(elementRepository.SelectElements().Select(m => (ElementModel.ToElementModel(m))).ToList()));
        }

        [HttpPost]
        public IActionResult Home(HomeModel homeModel)
        {
            ElementRepository elementRepository = new ElementRepository();

            homeModel.ElementModels = elementRepository.SelectElements().Select(m => (ElementModel.ToElementModel(m))).ToList();

            OutputStreams.WriteLine("[HttpPost] Home:");
            homeModel.Symbols.ForEach(m => OutputStreams.WriteLine(m));

            return View(homeModel);
        }
    }
}
