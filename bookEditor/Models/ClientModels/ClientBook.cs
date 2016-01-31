using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookEditor.Models.ClientModels
{
    public class ClientBook : Book
    {
        public bool Collapsed { get; set; } = true;
    }
}