using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobApplications.Custom.ValidationAttributes {
   public class MyDateTimeAttribute : ValidationAttribute, IClientValidatable {
      public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context) {
         var rule = new ModelClientValidationRule {
            ErrorMessage = ErrorMessage ?? "Valid format is DD/MM/YYYY [HH:MM[:SS]]",
            ValidationType = "datetime"
         };

         rule.ValidationParameters["other"] = "A TEST THING";
         yield return rule;
      }

      public MyDateTimeAttribute() {

      }

      protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
         // Validation will be performed by the ModelBinder when it attempts to read the posted data from the form.

         return ValidationResult.Success;
      }
   }
}

/*
public class NotEqualToAttribute : ValidationAttribute, IClientValidatable {

   public string OtherProperty { get; private set; }

   public NotEqualToAttribute(string otherProperty) {
      OtherProperty = otherProperty;
   }

   protected override ValidationResult IsValid(object value, ValidationContext validationContext) {
      var property = validationContext.ObjectType.GetProperty(OtherProperty);
      if (property == null) {
         return new ValidationResult(
             string.Format(
                 CultureInfo.CurrentCulture,
                 "{0} is unknown property",
                 OtherProperty
             ), new[] { validationContext.MemberName }
         );
      }
      var otherValue = property.GetValue(validationContext.ObjectInstance, null);
      if (value == otherValue) {
         return new ValidationResult(
             FormatErrorMessage(validationContext.DisplayName),
             new[] { validationContext.MemberName });
      }
      return ValidationResult.Success;
   }
}
*/