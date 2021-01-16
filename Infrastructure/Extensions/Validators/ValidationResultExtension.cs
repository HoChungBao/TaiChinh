using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions.Validators
{
    public static class ValidationResultExtension
    {
        public static string GetErrorMessageValidator(this ValidationResult validation)
        {
            return string.Join(",", validation.Errors.GroupBy(x => x.ErrorMessage).ToList());
        }
    }
}
