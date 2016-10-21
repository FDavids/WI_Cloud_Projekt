using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MiniCloud.DataModel;

namespace MiniCloud.ModelHelper.Helper
{
    public class UniqueUserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                bool isValid;

                var valueAsString = value.ToString();

                using (var context = new EntityContext())
                {
                    isValid = !context.Users.Any(x => x.UserName.Equals(valueAsString, StringComparison.InvariantCultureIgnoreCase));
                }

                if (!isValid)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }
            return ValidationResult.Success;
        }
    }
}
