#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Hadoken.IO.Web.MaterialsProject
{
    [DataContract]
    public class SearchResultVersion
    {
        [DataMember(Name = "db")]
        public string Database
        {
            get;
            set;
        }

        [DataMember(Name = "pymatgen")]
        public string Pymatgen
        {
            get;
            set;
        }

        [DataMember(Name = "rest")]
        public string Rest
        {
            get;
            set;
        }
    }
}
