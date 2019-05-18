using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    [Serializable]
    public class HttpResult
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }

        public HttpResult(bool status = true, string msg = "ok", object data = null)
        {
            Status = status;
            Msg = msg;
            Data = data;
        }
    }
}
