using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace bookEditor.Controllers
{
    public class ImagesController : ApiController
    {
        public HttpResponseMessage PostImage()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count == 1)
            {
                var fl12 = httpRequest.Files[0];
                string bt;
                using (var memoryStream = new MemoryStream())
                {
                    fl12.InputStream.CopyTo(memoryStream);
                    bt =  Convert.ToBase64String(memoryStream.ToArray());
                }

                var bp = new BookPicture { Img = bt };

                return Request.CreateResponse(HttpStatusCode.Created, bp);

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
