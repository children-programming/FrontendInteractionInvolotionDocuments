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
    class MyModule : IHttpModule
    {
        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            //
            //  Hook up to the PreRequestHandlerExecute event
            //
            context.PreRequestHandlerExecute +=
                new EventHandler(OnPreRequestHandlerExecute);

        }

        #endregion

        public void OnPreRequestHandlerExecute(
            Object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpRequest     request = app.Context.Request;

            //
            //  Reject the request if it contains a Referer header
            //
            if (!String.IsNullOrEmpty( request.Headers["Referer"] ))
            {
                throw new HttpException(403, 
                                        "Uh-uh!");
            }
        } 
    }
}