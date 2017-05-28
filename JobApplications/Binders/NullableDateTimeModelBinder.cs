using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using System.Text.RegularExpressions;

namespace JobApplications.Binders {
   /// <summary>
   /// Model binder for the DateTime? type.
   /// 
   /// 
   /// </summary>
   public class NullableDateTimeModelBinder : DateTimeModelBinderBase, IModelBinder {

      public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
         var value = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

         if (string.IsNullOrWhiteSpace(value.AttemptedValue)) {
            return null;
         }

         DateTime? dateTime = parseDateTime(value.AttemptedValue);

         if (dateTime == null) {
            bindingContext.ModelState.AddModelError(bindingContext.ModelName, string.Format("Unrecognised date/time value: {0}", value.AttemptedValue));
         }

         return dateTime; // This is bound to a nullable type. So returning null should be OK.
      }

   }
}