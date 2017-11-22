#region Using References

using System;
using System.Runtime.Serialization;

#endregion

namespace Hadoken.IO.Web.MaterialsProject
{
    [DataContract]
    internal class SearchResponse
    {
        [DataMember(Name = "created_at")]
        public DateTime CreatedAt
        {
            get;
            set;
        }

        [DataMember(Name = "valid_response")]
        public bool ValidResponse
        {
            get;
            set;
        }

        [DataMember(Name = "response")]
        public MaterialsProjectSearchResult[] SearchResults
        {
            get;
            set;
        }

        [DataMember(Name = "version")]
        public SearchResultVersion Version
        {
            get;
            set;
        }
    }
}
