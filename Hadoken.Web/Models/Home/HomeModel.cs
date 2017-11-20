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

        private List<ElementModel> _elementModels;
        private string _search;

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
