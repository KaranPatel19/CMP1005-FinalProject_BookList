using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookListLibrary.Exceptions
{
    public class BookValidationException : Exception
    {
        public ICollection<ValidationResult> ValidationResults { get; }

        public BookValidationException(string message, ICollection<ValidationResult> validationResults)
            : base(message)
        {
            ValidationResults = validationResults;
        }
    }
}
