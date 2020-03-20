using System;

namespace TdpGisApi.Application.Config
{
    public class ValidatingResult
    {
        public long ResponseTime { get; set; }

        public bool Status { get; set; }

        public Exception OutputException { get; set; }

        public string Description { get; set; }
    }
}