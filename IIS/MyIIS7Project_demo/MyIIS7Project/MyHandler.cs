//
//  Sample IIS7 module and handler project
//  by Mike Volodarsky (www.mvolo.com)
//

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace MyIIS7Project
{
    class MyHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; } 
        }

        public void ProcessRequest(HttpContext context)
        {
            DateTime dt;

            //
            // Check whether the utc=true querystring parameter is specified
            //
            String useUtc = context.Request.QueryString["utc"];
            if (!String.IsNullOrEmpty(useUtc) &&
                    useUtc.Equals("true"))
            {
                dt = DateTime.UtcNow;
            }
            else 
            { 
                dt = DateTime.Now;
            }

            //
            //  Write the time to response
            //
            context.Response.Write(
                String.Format( "<h1>{0}</h1>",
                               dt.ToLongTimeString()
                               ) );
        }

        #endregion
    }
}
