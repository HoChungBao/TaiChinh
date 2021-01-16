using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace Infrastructure.Validators
{
    public abstract class BaseValidator<T> : AbstractValidator<T> where T : class
    {
        protected BaseValidator() : base()
        {
            SetStringNotNull() ;
        }
        public virtual string GetErrorMessageValidator(ValidationResult validation)
        {
            return string.Join(",", validation.Errors.GroupBy(x => x.ErrorMessage).ToList());
        }

        public virtual PropertyInfo[] GetProperties()
        {
            return typeof(T).GetProperties();
            
        }
        public virtual List<string> GetStringProperties()
        {
            return GetProperties().Where(x => x.PropertyType == typeof(string)&& x.Attributes.GetType()==typeof(RequiredAttribute)).Select(x => x.Name).ToList();
        }
        public virtual void SetStringNotNull()
        {
            var stringproperties = GetStringProperties();
            var expression= stringproperties.Select(property =>new
            {
                Name = property,
                Expression = DynamicExpressionParser.ParseLambda<T, string>(null, false, "@" + property)
            }).ToList();
            expression.ForEach(x =>
            {
                RuleFor(x.Expression).NotNull().WithMessage(x.Name + " Không được để trống")
                .NotEmpty().WithMessage(x.Name + " Không được để trống");
            });

        }

    }
}
