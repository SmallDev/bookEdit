using bookEditor.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookEditor.Models
{
    public class ValidationItem
    {
        public ValidationType ValidationType { get; set; }

        public string DataToValidate { get; set; }
    }
}