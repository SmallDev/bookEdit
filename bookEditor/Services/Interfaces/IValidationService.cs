using bookEditor.Enums;
using bookEditor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookEditor.Services.Interfaces
{
    public interface IValidationService
    {
        ValidationResult Validate(ValidationItem validationItem);
    }
}
