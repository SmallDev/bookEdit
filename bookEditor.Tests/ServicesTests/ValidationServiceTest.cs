using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using bookEditor.Services;
using bookEditor.Models;
using bookEditor.Enums;

namespace bookEditor.Tests.ServicesTests
{
    [TestClass]
    public class ValidationServiceTest
    {
        private ValidationService _vldServes;

        [TestInitialize]
        public void InitService()
        {
            _vldServes = new ValidationService();
        }

        [TestMethod]
        public void ValidIsbn10_PassValidation()
        {
            var validIsbn10 = "2-266-11156-6";

            var vi = new ValidationItem
            {
                ValidationType = ValidationType.ISBN,
                DataToValidate = validIsbn10
            };

            var validationResult = _vldServes.Validate(vi);

            Assert.AreEqual(ValidationResult.Valid, validationResult, "Valid isbn 10 dosn't pass validation");

        }

        [TestMethod]
        public void NotValidIsbn10_FailedValidation()
        {
            var validIsbn10 = "2-266-11156-x";

            var vi = new ValidationItem
            {
                ValidationType = ValidationType.ISBN,
                DataToValidate = validIsbn10
            };

            var validationResult = _vldServes.Validate(vi);

            Assert.AreEqual(ValidationResult.NotValid, validationResult, "Not valid isbn 10, passed validation");
        }

        [TestMethod]
        public void ValidIsbn13_PassValidation()
        {
            var validIsbn13 = "978-0-00-720354-3";

            var vi = new ValidationItem
            {
                ValidationType = ValidationType.ISBN,
                DataToValidate = validIsbn13
            };

            var validationResult = _vldServes.Validate(vi);

            Assert.AreEqual(ValidationResult.Valid, validationResult, "Valid isbn 13 dosn't pass validation");

        }

        [TestMethod]
        public void NotValidIsbn13_FailedValidation()
        {
            var validIsbn13 = "978-0-0z-720354-3";

            var vi = new ValidationItem
            {
                ValidationType = ValidationType.ISBN,
                DataToValidate = validIsbn13
            };

            var validationResult = _vldServes.Validate(vi);

            Assert.AreEqual(ValidationResult.NotValid, validationResult, "Not valid isbn 13, passed validation");
        }
    }
}
