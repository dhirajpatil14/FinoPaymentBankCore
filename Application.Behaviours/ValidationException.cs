using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Application.Behaviours
{
    [Serializable]
    public class ValidationException : Exception
    {
        protected ValidationException(SerializationInfo info,
     StreamingContext context) : base(info, context)
        {
        }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<string>();
        }
        public List<string> Errors { get; }
        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
