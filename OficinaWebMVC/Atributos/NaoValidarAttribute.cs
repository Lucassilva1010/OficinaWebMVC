using System.ComponentModel.DataAnnotations;

namespace OficinaWebMVC.Atributos
{
    public class NaoValidarAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success; // Retorna sucesso sem fazer nenhuma validação
        }
    }

}

