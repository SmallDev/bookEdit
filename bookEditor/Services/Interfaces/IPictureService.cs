using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookEditor.Services.Interfaces
{
    public interface IPictureService
    {
        BookPicture CreateBookPicture(Stream imgStream);
    }
}
