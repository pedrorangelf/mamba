using Mamba.Domain.Validations;
using System.ComponentModel.DataAnnotations;

namespace Mamba.API.Extensions.Attributes
{
    public class CnpjValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return true;

            if (!CnpjValidation.Validar(value.ToString()))
                return false;

            return true;
        }
    }
}
