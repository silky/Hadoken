#region Using References

using System;
using System.Collections.Generic;

using Hadoken.IO.Web;

#endregion

namespace Hadoken.Web.Models.Home
{
    public class HomeModel
    {
        public HomeModel()
        {
        }

        public HomeModel(List<ElementModel> elementModels)
        {
            _elementModels = elementModels;
        }

        private List<ElementModel> _elementModels;
        private string _search;
        private List<SearchResult> _searchResult;
        private List<string> _symbols;

        public List<ElementModel> ElementModels
        {
            get
            {
                return _elementModels;
            }
            set
            {
                _elementModels = value;
            }
        }

        public List<SearchResult> SearchResults
        {
            get
            {
                if (_searchResult == null)
                {
                    _searchResult = new List<SearchResult>();
                }

                return _searchResult;
            }
            set
            {
                _searchResult = value;
            }
        }

        public List<string> Symbols
        {
            get
            {
                if (_symbols == null)
                {
                    _symbols = new List<string>();
                }
                
                return _symbols;
            }
            set
            {
                _symbols = value;
            }
        }

        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
            }
        }
    }
}
