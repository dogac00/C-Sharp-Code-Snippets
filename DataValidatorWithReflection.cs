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
    }

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
