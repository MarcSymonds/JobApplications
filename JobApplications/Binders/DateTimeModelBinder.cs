using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Web.Mvc;

namespace JobApplications.Binders {
   public class DateTimeModelBinder : DateTimeModelBinderBase, IModelBinder {
      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
         var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

         DateTime? dateTime = parseDateTime(value.AttemptedValue);

         if (dateTime == null) {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Unrecognised date/time value: {0}", value.AttemptedValue));
            return DateTime.MinValue; // Arbitrary value, since we have to return something.
         }
         else {
            return dateTime.Value;
         }
      }
   }
}