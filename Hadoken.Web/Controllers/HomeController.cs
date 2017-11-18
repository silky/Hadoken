#region Using References

using System;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Hadoken.Data;

using Hadoken.Web.Models;
using Hadoken.Web.Models.Home;

#endregion

namespace Hadoken.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Error()
        {
            return View(new ErrorViewModel(Activity.Current?.Id ?? HttpContext.TraceIdentifier));
        }

        public IActionResult Home()
        {
            ElementRepository elementRepository = new ElementRepository();

            return View(elementRepository.SelectElements().Select(m => (ElementModel.ToElementModel(m))));
        }
    }
}
