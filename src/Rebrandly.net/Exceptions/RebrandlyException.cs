using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Rebrandly.Exceptions
{
    public class RebrandlyException : Exception
    {
        public RebrandlyException()
        {
        }

        public RebrandlyException(string message)
            : base(message)
        {
        }

        public RebrandlyException(string message, Exception err)
            : base(message, err)
        {
        }

        public RebrandlyException(HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            this.HttpStatusCode = httpStatusCode;
        }

        public HttpStatusCode HttpStatusCode { get; set; }
        public RebrandlyResponse RebrandlyResponse { get; set; }
    }
}
