#region Using References

using System;
using System.Collections.Generic;

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

        private readonly List<ElementModel> _elementModels;
        private string _search;

        public List<ElementModel> ElementModels
        {
            get
            {
                return _elementModels;
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
