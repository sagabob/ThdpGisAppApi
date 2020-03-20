using System.Collections.Generic;

namespace TdpGisApi.Application.QuerySvc.Message
{
    public class ResponseMsg<TResult>
    {
        public ResponseMsg()
        {
            Results = new List<TResult>();
        }

        public int Count => Results.Count;
        public IList<TResult> Results { get; set; }
        public string ErrorMessage { get; set; }

        public int Skip { get; set; }

        public int Limit { get; set; }
    }
}