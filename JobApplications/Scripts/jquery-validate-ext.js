// These need to match the  Binders/NullableDateTimeModelBinder  so that they can validate the same value formats.

var filters = [
    {
        filter: "^\\s*(\\d{1,2})[-/.](\\d{1,2})[-/.](\\d{2}|\\d{4})((\\s+)(\\d{1,2}):(\\d{1,2})(:(\\d{1,2}))?)?\\s*$",
        year: 3, month: 2, day: 1, hour: 6, minute: 7, seconds: 9
    },
    {
        filter: "^\\s*(\\d{4})-(\\d{2})-(\\d{2})((T|\\s+)(\\d{2}):(\\d{2})(:(\\d{2}))?)?\\s*$",
        year: 1, month: 2, day: 3, hour: 6, minute: 7, seconds: 9
    },
    {
        filter: "^\\s*(\\d{4})(\\d{2})(\\d{2})((T|\\s+)(\\d{2}):(\\d{2})(:(\\d{2}))?)?\\s*$",
        year: 1, month: 2, day: 3, hour: 6, minute: 7, seconds: 9
    },
    {
        filter: "^\\s*(\\d{1,2}):(\\d{1,2})(:(\\d{1,2}))?\\s*$",
        hour: 1, minute: 2, seconds: 4
    }
];

function checkDate(value, element) {
    var matches;

    for (var idx = 0; idx < filters.length; idx++) {
        var filter = filters[idx];

        matches = new RegExp(filter.filter).exec(value);
        if (matches !== null) {
            var date = new Date();
            var valid = true;
            if (filter.year !== undefined) {
                var year = parseInt(matches[filter.year], 10);
                var month = parseInt(matches[filter.month], 10) - 1;
                var day = parseInt(matches[filter.day], 10);

                if (year < 49) {
                    year += 2000;
                }
                else if (year < 100) {
                    year += 1900;
                }

                date.setFullYear(year, month, day);

                if (date.getFullYear() !== year || date.getMonth() !== month || date.getDate() !== day) {
                    valid = false;
                }
            }

            if (filter.hour !== undefined && matches[filter.hour] !== undefined) {
                var hour = parseInt(matches[filter.hour], 10);
                var minute = parseInt(matches[filter.minute], 10);
                var seconds = 0;

                if (matches[filter.second] !== undefined) {
                    seconds = parseInt(matches[filter.seconds], 10);
                }

                date.setHours(hour, minute, seconds);

                if (date.getHours() !== hour || date.getMinutes() !== minute || date.getSeconds() !== seconds) {
                    valid = false;
                }
            }

            if (valid) {
                return date;
            }
        }
    }

    return null;
}

(function () {
    // You'd think it would use the  data-val-datetime  attribute on the input field as the error message.
    // But it doesn't, so we have to duplicate it here. So much for the DRY principal.
    $.validator.addMethod("datetime", function (value, element) {
        var check = (checkDate(value) !== null);
        
        return this.optional(element) || check;
    }, $.validator.format("Valid format is DD/MM/YYYY [HH:MM[:SS]]"));

    // The MVC framework automatically adds a "data-val-date='...'" for a DateTime field.
    // I don't know how to get rid of it through configuration, so ...
    // if we want to use a custom validator, then we need to remove this attribute from
    // the input field so that jquery won't use its date validation function.
    // If we don't do this, then it will use both the jquery validator and the custom
    // validator.
    $("[data-val-datetime]").removeAttr("data-val-date");
}());
