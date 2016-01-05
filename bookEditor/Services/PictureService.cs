using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookEditor.Models;
using System.IO;

namespace bookEditor.Services
{
    public class PictureService : IPictureService
    {
        public BookPicture CreateBookPicture(Stream imgStream)
        {
            string base64Img;
            using (var memoryStream = new MemoryStream())
            {
                imgStream.CopyTo(memoryStream);
                base64Img = Convert.ToBase64String(memoryStream.ToArray());
            }

            return new BookPicture { Img = base64Img };
        }
    }
}