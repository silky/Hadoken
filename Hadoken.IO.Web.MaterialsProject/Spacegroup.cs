#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Hadoken.IO.Web.MaterialsProject
{
    [DataContract]
    public class Spacegroup
    {
        [DataMember(Name = "crystal_system")]
        public string CrystalSystem
        {
            get;
            set;
        }

        [DataMember(Name = "hall")]
        public string Hall
        {
            get;
            set;
        }

        [DataMember(Name = "number")]
        public int Number
        {
            get;
            set;
        }

        [DataMember(Name = "point_group")]
        public string PointGroup
        {
            get;
            set;
        }

        [DataMember(Name = "source")]
        public string Source
        {
            get;
            set;
        }

        [DataMember(Name = "symbol")]
        public string Symbol
        {
            get;
            set;
        }
    }
}
