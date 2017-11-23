#region Using References

using System;
using System.Collections.Generic;

using Hadoken.Core;
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

        public virtual List<SearchResult> Search(List<Element> elements)
        {
            return new List<SearchResult>();
        }

        public static double ToDouble(string value)
        {
            double toDouble = 0;

            if (String.IsNullOrEmpty(value) == false)
            {
                Double.TryParse(value, out toDouble);
            }

            return toDouble;
        }

        public static EGapType ToGapType(string value)
        {
            EGapType toGapType = EGapType.Unknown;

            if (String.IsNullOrEmpty(value) == false)
            {
                object parsed = null;

                Enum.TryParse(typeof(EGapType), value, out parsed);

                if (parsed is EGapType)
                {
                    toGapType = (EGapType)(parsed);
                }
            }

            return toGapType;
        }
    }
}
