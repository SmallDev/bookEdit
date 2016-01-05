using bookEditor.Models;
using bookEditor.Services.Interfaces;
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
        private IPictureService _pictureService;

        public ImagesController(IPictureService pictureService)
        {
            if (pictureService == null)
            {
                throw new ArgumentNullException("PictureService was not initialized");
            }

            _pictureService = pictureService;
        }


        public HttpResponseMessage PostImage()
        {
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count == 1)
            {
                var inputFile = httpRequest.Files[0];
                var bookPicture = _pictureService.CreateBookPicture(inputFile.InputStream);

                return Request.CreateResponse(HttpStatusCode.Created, bookPicture);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
