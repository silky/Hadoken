#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Hadoken.IO.Web.AFlow
{
    public class AFlowSearchResult
    {
        public AFlowSearchResult()
        {
        }

        private string _auid;   //	aflow:db93f8a9a57e60f2",
        private string _aurl;   //	aflowlib.duke.edu:AFLOWDATA/ICSD_WEB/ORCC/Ag1As1Na2_ICSD_49007",
        private string _compound;   //	Ag2As2Na4",
        private string _egap;   //	0.7896",
        private string _egapFit;   //	3.19638,
        private string _egapType;   //	insulator_indirect"
        private string _species;    //	Ag,As,Na",

        [DataMember(Name = "auid")]
        public string AUID
        {
            get
            {
                return _auid;
            }
            set
            {
                _auid = value;
            }
        }

        [DataMember(Name = "aurl")]
        public string AUrl
        {
            get
            {
                return _aurl;
            }
            set
            {
                _aurl = value;
            }
        }

        [DataMember(Name = "compound")]
        public string Compound
        {
            get
            {
                return _compound;
            }
            set
            {
                _compound = value;
            }
        }

        [DataMember(Name = "Egap")]
        public string Egap
        {
            get
            {
                return _egap;
            }
            set
            {
                _egap = value;
            }
        }

        [DataMember(Name = "Egap_fit")]
        public string EgapFit
        {
            get
            {
                return _egapFit;
            }
            set
            {
                _egapFit = value;
            }
        }

        [DataMember(Name = "Egap_type")]
        public string EgapType
        {
            get
            {
                return _egapType;
            }
            set
            {
                _egapType = value;

                if (String.IsNullOrEmpty(_egapType) == false)
                {
                    if (_egapType.Contains("_") == true)
                    {
                        _egapType = _egapType.Substring(0, _egapType.IndexOf("_"));
                    }

                    _egapType = $"{_egapType.Substring(0, 1).ToUpper()}{_egapType.Substring(1)}";
                }
            }
        }

        [DataMember(Name = "species")]
        public string Species
        {
            get
            {
                return _species;
            }
            set
            {
                _species = value;
            }
        }
    }
}
