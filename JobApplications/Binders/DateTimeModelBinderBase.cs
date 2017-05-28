using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace JobApplications.Binders {
   /// <summary>
   /// Class for parsing a date/time value posted from a form.
   /// </summary>
   public abstract class DateTimeModelBinderBase {
      private Regex[] Filters = {
         new Regex("^\\s*(?<day>\\d{1,2})[-/.](?<month>\\d{1,2})[-/.](?<year>(\\d{1,2}|\\d{1,4}))(\\s+(?<hour>\\d{1,2}):(?<minute>\\d{1,2})(:(?<second>\\d{1,2}))?)?\\s*$", RegexOptions.Compiled),
         new Regex("^\\s*(?<year>\\d{4})-(?<month>\\d{2})-(?<day>\\d{2})((T|\\s+)(?<hour>\\d{1,2}):(?<minute>\\d{1,2})(:(?<second>\\d{1,2}))?)?\\s*$"),
         new Regex("^\\s*(?<year>\\d{4})(?<month>\\d{2})(?<day>\\d{2})((T|\\s+)(?<hour>\\d{1,2}):(?<minute>\\d{1,2})(:(?<second>\\d{1,2}))?)?\\s*$"),
         new Regex("^\\s*(?<hour>\\d{1,2}):(?<minute>\\d{1,2})(:(?<second>\\d{1,2}))?\\s*$", RegexOptions.Compiled)
      };

      protected DateTime? parseDateTime(string value) {
         foreach (var filter in Filters) {
            var match = filter.Match(value);

            if (match.Success) {
               DateTime dateTime = DateTime.Now; // If only a time is parsed, it will default to the current date.

               int year = valueFor(match, "year", dateTime.Year);

               if (year < 49) {
                  year += 2000;
               }
               else if (year < 100) {
                  year += 1900;
               }

               int month = valueFor(match, "month", dateTime.Month);
               int day = valueFor(match, "day", dateTime.Day);
               int hours = valueFor(match, "hour", 0);
               int minutes = valueFor(match, "minute", 0);
               int seconds = valueFor(match, "second", 0);

               try {
                  dateTime = new DateTime(year, month, day, hours, minutes, seconds, 0);
                  return dateTime;
               }
               catch (Exception ex) {
                  // Ignore the error. Another filter might match.
               }
            }
         }

         return null;
      }

      private int valueFor(Match match, string item, int defaultValue) {
         if (match.Groups[item].Success) {
            return int.Parse(match.Groups[item].Value);
         }
         else {
            return defaultValue;
         }
      }

   }
}