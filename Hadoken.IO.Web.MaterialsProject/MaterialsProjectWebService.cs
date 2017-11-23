#region Using References

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using Hadoken.Core.Elements;
using Hadoken.Core.IO;
using Hadoken.Core;

#endregion

namespace Hadoken.IO.Web.MaterialsProject
{
    public class MaterialsProjectWebService : WebService
    {
        public MaterialsProjectWebService()
            : this(MaterialsProjectBaseUrl)
        {
        }

        public MaterialsProjectWebService(string baseUrl)
            : base(baseUrl)
        {
        }

        private const string MaterialsProjectBaseUrl = "https://www.materialsproject.org/rest/v1/materials";

        private List<SearchResult> Search(string url)
        {
            List<SearchResult> searchResults = null;

            string response = Http.Get($"{MaterialsProjectBaseUrl}{url}", "X-API-KEY", "pusLZwgRdnUkoABi");
            dynamic json = JsonConvert.DeserializeObject(response);

            response = JsonConvert.SerializeObject(json, Formatting.Indented);

            if (String.IsNullOrEmpty(response) == false)
            {
                using (JsonTextReader jsonTextReader = new JsonTextReader(new StringReader(response)))
                {
                    JsonSerializer jsonSerializer = JsonSerializer.Create();

                    SearchResponse searchResponse = jsonSerializer.Deserialize<SearchResponse>(jsonTextReader);

                    List<MaterialsProjectSearchResult> materialsProjectSearchResults = searchResponse.SearchResults.ToList();

                    searchResults = materialsProjectSearchResults.Select(m => new SearchResult
                    (
                        m.BandGap,
                        m.FullFormula,
                        0,
                        EGapType.Unknown,
                        String.Concat(CalculationVariable.FromPrototypeString(m.FullFormula).Select(n => (n.Element.Symbol)))
                    )).ToList();
                }
            }

            return searchResults;
        }

        public override List<SearchResult> Search(List<Element> elements)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (elements.Count > 0)
            {
                stringBuilder.Append("/");

                for (int i = 0; i < elements.Count; i++)
                {
                    stringBuilder.Append(elements[i].Symbol);

                    if (i < (elements.Count - 1))
                    {
                        stringBuilder.Append("-");
                    }
                }

                stringBuilder.Append("/vasp");
            }

            return Search(stringBuilder.ToString());
        }
    }
}