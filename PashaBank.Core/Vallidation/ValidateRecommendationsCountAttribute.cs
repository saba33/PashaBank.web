using PashaBank.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace PashaBank.Core.Vallidation
{
    public class ValidateRecommendationsCountAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var recommendations = value as ICollection<Recommendation>;

            if (recommendations != null && recommendations.Count > 3)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
