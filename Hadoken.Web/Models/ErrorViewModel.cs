using System;

namespace Hadoken.Web.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string requestID)
        {
            _requestID = requestID;
        }

        private readonly string _requestID;

        public string RequestID
        {
            get
            {
                return _requestID;
            }
        }

        public bool ShowRequestID
        {
            get
            {
                return (String.IsNullOrEmpty(RequestID) == false);
            }
        }
    }
}