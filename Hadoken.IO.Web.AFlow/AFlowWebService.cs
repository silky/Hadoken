#region Using References

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Newtonsoft.Json;

using Hadoken.Core;
using Hadoken.Core.Elements;
using Hadoken.Core.IO;

#endregion

namespace Hadoken.IO.Web.AFlow
{
    public class AFlowWebService : WebService
    {
        public AFlowWebService()
            : this(AFlowBaseUrl)
        {
        }

        public AFlowWebService(string baseUrl)
            : base(baseUrl)
        {
        }

        private const string AFlowBaseUrl = "http://aflowlib.duke.edu/AFLOWDATA";

        private List<SearchResult> Search(List<Element> elements, List<string> attributes)
        {
            List<SearchResult> searchResults = null;

            StringBuilder stringBuilder = new StringBuilder();

            if (elements.Count > 0)
            {
                stringBuilder.Append("species(");

                for (int i = 0; i < elements.Count; i++)
                {
                    stringBuilder.Append(elements[i].Symbol);

                    if (i < (elements.Count - 1))
                    {
                        stringBuilder.Append(",");
                    }
                }

                stringBuilder.Append(")");
            }

            if ((elements.Count > 0) && (attributes.Count > 0))
            {
                stringBuilder.Append(",");
            }

            if (attributes.Count > 0)
            {
                for (int i = 0; i < attributes.Count; i++)
                {
                    stringBuilder.Append(attributes[i]);

                    if (i < (attributes.Count - 1))
                    {
                        stringBuilder.Append(",");
                    }
                }
            }

            string response = Http.Get($"http://aflowlib.duke.edu/search/API/?{stringBuilder.ToString()}");
            dynamic json = JsonConvert.DeserializeObject(response);

            response = JsonConvert.SerializeObject(json, Formatting.Indented);

            if (String.IsNullOrEmpty(response) == false)
            {
                using (JsonTextReader oJsonTextReader = new JsonTextReader(new StringReader(response)))
                {
                    JsonSerializer oJsonSerializer = JsonSerializer.Create();

                    List<AFlowSearchResult> aFlowSearchResults = oJsonSerializer.Deserialize<List<AFlowSearchResult>>(oJsonTextReader);

                    searchResults = aFlowSearchResults.Select(m => new SearchResult
                    (
                        ToDouble(m.Egap),
                        m.Compound,
                        ToDouble(m.EgapFit),
                        ToGapType(m.EgapType),
                        m.Species.Replace(",", "").Trim()
                    )).ToList();
                }
            }

            return searchResults;
        }

        public override List<SearchResult> Search(List<Element> elements)
        {
            return Search(elements, new List<string>(new string[] { "Egap", "Egap_type", "Egap_fit" }));
        }
    }
}