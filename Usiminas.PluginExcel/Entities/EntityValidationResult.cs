using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usiminas.PluginExcel.Entities
{
    [Serializable]
    public class EntityValidationResult
    {
        public IList<ValidationResult> ValidationErrors { get; private set; }
        public bool HasError
        {
            get
            {
                return ValidationErrors.Count > 0;
            }
        }
        public string ListaErro { get; }
        public EntityValidationResult(IList<ValidationResult> violations = null)
        {
            ValidationErrors = violations ?? new List<ValidationResult>();
            if (ValidationErrors.Count > 0)
            {
                ListaErro += "Erro: ";
                foreach (var erro in ValidationErrors)
                {
                    ListaErro += erro.ErrorMessage + "\n";
                }
            }
        }
    }

    public class DataAnnotation
    {
        public static EntityValidationResult ValidateEntity<T>(T entity)
        {
            return new EntityValidator<T>().Validate(entity);
        }
    }

    public class EntityValidator<T>
    {
        public EntityValidationResult Validate(T entity)
        {
            var validationResults = new List<ValidationResult>();
            var vc = new ValidationContext(entity, null, null);
            var isValid = Validator.TryValidateObject(entity, vc, validationResults, true);

            return new EntityValidationResult(validationResults);
        }
    }
}

