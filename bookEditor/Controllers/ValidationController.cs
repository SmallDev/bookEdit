using bookEditor.Models;
using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bookEditor.Controllers
{
    public class ValidationController : ApiController
    {
        private IValidationService _validationService;

        public ValidationController(IValidationService validationService)
        {
            if (validationService == null)
            {
                throw new ArgumentNullException("Validation Service was not initialized");
            }

            _validationService = validationService;
        }

        public HttpResponseMessage PostValidate(ValidationItem valdationItem)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _validationService.Validate(valdationItem));
        }
    }
}
