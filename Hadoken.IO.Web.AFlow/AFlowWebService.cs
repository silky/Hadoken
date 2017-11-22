#region Using References

using System;

#endregion

namespace Hadoken.IO.Web.AFlow
{
    public class AFlowWebService : WebService
    {
        public AFlowWebService()
            : this(AFlowBaseUrl)
        {
        }

        public AFlowWebService(string baseUrl)
            : base(baseUrl)
        {
        }

        private const string AFlowBaseUrl = "http://aflowlib.duke.edu/AFLOWDATA";
    }
}
