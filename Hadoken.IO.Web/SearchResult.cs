#region Using References

using Hadoken.Core;
using System;

#endregion

namespace Hadoken.IO.Web
{
    public class SearchResult
    {
        public SearchResult(double bandGap, string compound, double eGapFit, EGapType eGapType, string species)
        {
            _bandGap = bandGap;
            _compound = compound;
            _eGapFit = eGapFit;
            _eGapType = eGapType;
            _species = species;
        }

        private readonly double _bandGap;
        private readonly string _compound;
        private readonly double _eGapFit;
        private readonly EGapType _eGapType;
        private readonly string _species;

        public double BandGap
        {
            get
            {
                return _bandGap;
            }
        }

        public string Compound
        {
            get
            {
                return _compound;
            }
        }

        public double EGapFit
        {
            get
            {
                return _eGapFit;
            }
        }

        public EGapType EGapType
        {
            get
            {
                return _eGapType;
            }
        }

        public string Species
        {
            get
            {
                return _species;
            }
        }
    }
}
