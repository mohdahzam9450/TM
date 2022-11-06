using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI_API.API.Modal.JsonModal
{
    public class RestResponse
    {

        private int statusCode;
        private string responseData;

        public RestResponse(int statusCode, string responseData)
        {
            this.statusCode = statusCode;
            this.responseData = responseData;
        }

        public int StatusCode
        {
            get
            {
                return statusCode;
            }
        }

        public string ResponseData
        {
            get
            {
                return responseData;
            }
        }
    }
}
