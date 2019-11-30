class DataValidator
    {
        public static List<ErrorInfo> ValidateObject(object obj)
        {
            List<ErrorInfo> errors = new List<ErrorInfo>();
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo property in props)
            {
                object[] attr = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (ValidationAttribute attribute in attr)
                {
                    if (!attribute.IsValid(property.GetValue(obj, null)))
                    {
                        errors.Add(new ErrorInfo(attribute.ErrorMessage, property.Name));
                    }
                }
            }

            return errors;
        }
    
        public static bool IsValid(object obj)
        {
            return GetValidationErrorsReturnsNull(obj) == null;
        }

        // Returns null if the object is valid
        // Uses less memory compared to the method above
        public static List<ErrorInfo> GetValidationErrorsReturnsNull(object obj)
        {
            List<ErrorInfo> errors = null;
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (PropertyInfo property in props)
            {
                object[] attr = property.GetCustomAttributes(typeof(ValidationAttribute), true);

                foreach (ValidationAttribute attribute in attr)
                {
                    if (!attribute.IsValid(property.GetValue(obj, null)))
                    {
                        if (errors == null)
                            errors = new List<ErrorInfo>();
                        else
                            errors.Add(new ErrorInfo(attribute.ErrorMessage, property.Name));
                    }
                }
            }

            return errors;
        }
    }

    // Use of struct instead of class
    // to put less pressure on GC
    internal readonly struct ErrorInfo
    {
        public string Property { get; }
        public string Message { get; }

        public ErrorInfo(string message, string property)
        {
            Property = property;
            Message = message;
        }
    }
