using Common.Application.Model;
using System;
using System.Linq;

namespace Utility.Extensions
{
    public static class ExceptionExtensions
    {
        public static Exceptions GetExceptionDetails(this Exception ex)
        {
            var lineNumber = 0;

            const string lineSearch = ":line ";
            var index = ex.StackTrace.IndexOf(lineSearch);
            var exceptions = new Exceptions
            {
                FileName = string.Empty,
                LineNumber = 0
            };

            if (index != -1)
            {
                string part = (ex.StackTrace.ToString().Substring(0, index));
                string fileNames = part[(part.LastIndexOf(@"\") + 1)..];

                var lineNumberText = ex.StackTrace[(index + lineSearch.Length)..];

                var number = new string(lineNumberText.SkipWhile(c => !char.IsDigit(c))
                         .TakeWhile(c => char.IsDigit(c))
                         .ToArray());

                if (int.TryParse(number, out lineNumber))
                {
                    exceptions.LineNumber = lineNumber;
                }
                exceptions.FileName = fileNames;
                exceptions.Message = ex.GetExceptionMessage();

            }
            return exceptions;
        }

        private static string GetExceptionMessage(this Exception ex)
        {
            return ex.Message + "|" + (ex.InnerException != null ? ex.InnerException.ToString() + "|" + ex.InnerException.Message : String.Empty) + "|" + ex.Source + "|" + ex.StackTrace;
        }

    }
}
