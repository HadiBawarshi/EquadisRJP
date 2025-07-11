namespace EquadisRJP.Domain.Primitives
{
    public record Error
    {
        public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);
        public static readonly Error NullValue = new(
            "General.Null",
            "Null value was provided",
            ErrorType.Failure);

        public Error(string code, string description, ErrorType type)
        {
            Code = code;
            Description = description;
            Type = type;
        }

        public string Code { get; }

        public string Description { get; }

        public ErrorType Type { get; }

        public static Error Failure(string code, string description) =>
            new(code, description, ErrorType.Failure);

        public static Error Failure(Error error) =>
            new(error.Code, error.Description, ErrorType.Failure);

        public static Error NotFound(string code, string description) =>
            new(code, description, ErrorType.NotFound);

        public static Error NotFound(Error error) =>
            new(error.Code, error.Description, ErrorType.NotFound);

        public static Error Problem(string code, string description) =>
            new(code, description, ErrorType.Problem);

        public static Error Problem(Error error) =>
           new(error.Code, error.Description, ErrorType.Problem);

        public static Error Conflict(string code, string description) =>
            new(code, description, ErrorType.Conflict);

        public static Error Conflict(Error error) =>
             new(error.Code, error.Description, ErrorType.Conflict);


        public static Error Validation(string code, string description) =>
           new(code, description, ErrorType.Validation);

        public static Error Validation(Error error) =>
             new(error.Code, error.Description, ErrorType.Validation);
    }
}
