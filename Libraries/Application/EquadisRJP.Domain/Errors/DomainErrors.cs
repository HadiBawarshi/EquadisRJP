using EquadisRJP.Domain.Primitives;

namespace EquadisRJP.Domain.Errors
{
    public static class DomainErrors
    {

        public static class Partnership
        {
            public static readonly Error PartnershipExpired = new(
                "PartnershipExpired",
                "Active partnership is required",
                ErrorType.Conflict);

            public static readonly Error InvalidIds =
            Error.Validation("Partnership.InvalidIds", "SupplierId and RetailerId must be positive.");

            public static readonly Error InvalidDates =
                Error.Validation("Partnership.InvalidDates", "Expiry date must be after start date.");

            public static readonly Error NotExpired =
                Error.Conflict("Partnership.NotExpired", "Only expired partnerships can be renewed.");


            public static readonly Error AlreadyExists =
               Error.Conflict("Partnership.AlreadyExists", "Partnerships already exists.");


            public static readonly Error AlreadyExpired =
            Error.Conflict("Partnership.AlreadyExpired", "Partnership is already expired.");

            public static readonly Error NotFound =
                Error.NotFound("Partnership.NotFound", "Partnership not found.");
        }

        public static class ServerError
        {
            public static readonly Error InternalServerError = new(
                "InternalServerError",
                "An unexpected error occurred",
                ErrorType.Problem);
        }


        public static class Supplier
        {
            public static Error CreationFailed => Error.Failure(
                "Supplier.CreationFailed",
                "Failed to create the supplier.");
        }


        public static class Retailer
        {
            public static Error CreationFailed => Error.Failure(
                "Retailer.CreationFailed",
                "Failed to create the retailer.");
        }





    }
}
