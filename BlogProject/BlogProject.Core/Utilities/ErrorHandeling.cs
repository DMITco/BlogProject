using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.Core.Utilities
{
    public static class ErrorHandeling
    {
        public static string MessageBadRequest(ModelStateDictionary ModelState)
        {
            string Error = "";

            foreach (var item2 in ModelState.Values.SelectMany(item => item.Errors))
            {
                Error += item2.ErrorMessage + ",";
            }

            return Error.Remove(Error.Length - 1, 1);
        }
        public static object MessageBadRequest(string Model) => new { message = Model };
    }
}
