#region Using References

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Hadoken.Core.Elements;
using Hadoken.Core.IO;
using Hadoken.Data;
using Hadoken.IO.Web;
using Hadoken.IO.Web.AFlow;
using Hadoken.IO.Web.MaterialsProject;
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

            if (ModelState.IsValid == true)
            {
                List<Element> elements = homeModel.Symbols.Select(m => (Element.FromString(m))).ToList();
                List<WebService> webServices = new List<WebService>(new WebService[] { new AFlowWebService(), new MaterialsProjectWebService() });
                List<SearchResult> searchResults = new List<SearchResult>();

                OutputStreams.WriteLine("Elements:");
                elements.ForEach(m => OutputStreams.WriteLine(m));
                OutputStreams.WriteLine();

                foreach (WebService webService in webServices)
                {
                    OutputStreams.WriteLine($"Searching {webService.BaseUrl}...");
                    List<SearchResult> webServiceSearchResults = webService.Search(elements);
                    OutputStreams.WriteLine($"{webServiceSearchResults.Count} search results");
                    OutputStreams.WriteLine();
                    
                    if (webServiceSearchResults.Count > 0)
                    {
                        searchResults.AddRange(webServiceSearchResults);
                    }
                }

                homeModel.SearchResults = searchResults.OrderBy(m => (m.Compound)).ThenByDescending(m => (m.BandGap)).ToList();
            }

            return View(homeModel);
        }
    }
}
