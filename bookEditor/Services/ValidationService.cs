using bookEditor.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookEditor.Enums;
using bookEditor.Models;

namespace bookEditor.Services
{
    public class ValidationService : IValidationService
    {
        public ValidationResult Validate(ValidationItem validationItem)
        {
            if(validationItem.ValidationType == ValidationType.ISBN)
            {
                return ValidateISBN(validationItem);
            }

            return ValidationResult.UsounsupportedValidationType;
        }

        private ValidationResult ValidateISBN(ValidationItem validationItem)
        {
            bool result = false;
            var isbn = validationItem.DataToValidate;

            if (!string.IsNullOrEmpty(isbn))
            {
                if (isbn.Contains("-")) isbn = isbn.Replace("-", "");

                switch (isbn.Length)
                {
                    case 10: result = IsValidIsbn10(isbn); break;
                    case 13: result = IsValidIsbn13(isbn); break;
                }
            }

            return result ? ValidationResult.Valid : ValidationResult.NotValid;
        }
        private bool IsValidIsbn10(string isbn10)
        {
            bool result = false;
            if (!string.IsNullOrEmpty(isbn10))
            {
                if (isbn10.Contains("-")) isbn10 = isbn10.Replace("-", "");

                long j;

                if (isbn10.Length != 10 || !long.TryParse(isbn10.Substring(0, isbn10.Length - 1), out j))
                    return false;

                char lastChar = isbn10[isbn10.Length - 1];

 
                int sum = 0;
                for (int i = 0; i < 9; i++)
                    sum += int.Parse(isbn10[i].ToString()) * (i + 1);


                int remainder = sum % 11;

                if (lastChar == 'X')
                {
                    result = (remainder == 10);
                }

                else if (int.TryParse(lastChar.ToString(), out sum))
                {
                    result = (remainder == int.Parse(lastChar.ToString()));
                }
            }

            return result;
        }

        private bool IsValidIsbn13(string isbn13)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(isbn13))
            {
                if (isbn13.Contains("-")) isbn13 = isbn13.Replace("-", "");

                long temp;
                if (isbn13.Length != 13 || !long.TryParse(isbn13, out temp)) return false;

                int sum = 0;
                for (int i = 0; i < 12; i++)
                {
                    sum += int.Parse(isbn13[i].ToString()) * (i % 2 == 1 ? 3 : 1);
                }

                int remainder = sum % 10;
                int checkDigit = 10 - remainder;
                if (checkDigit == 10) checkDigit = 0;

                result = (checkDigit == int.Parse(isbn13[12].ToString()));
            }

            return result;
        }
    }
}