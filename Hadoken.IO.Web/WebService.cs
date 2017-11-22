#region Using References

using System;
using System.Collections.Generic;

using Hadoken.Core.Elements;

#endregion

namespace Hadoken.IO.Web
{
    public class WebService
    {
        public WebService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        private readonly string _baseUrl;

        public string BaseUrl
        {
            get
            {
                return _baseUrl;
            }
        }
    
        public virtual List<SearchResult> Search(string url)
        {
            return new List<SearchResult>();
        }

        public virtual List<SearchResult> Search(List<Element> elements)
        {
            return new List<SearchResult>();
        }
    }
}
