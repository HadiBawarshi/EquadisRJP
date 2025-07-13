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

            public static readonly Error InvalidPartyIds =
            Error.Validation("Partnership.InvalidIds", "SupplierId and RetailerId must be greater than 0.");

            public static readonly Error InvalidExpiry =
                Error.Validation("Partnership.InvalidExpiry", "Expiry date must be after start date.");
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



        public static class Offer
        {
            public static readonly Error NotFound = new(
                "Offer.NotFound",
                "Offer not found",
                ErrorType.NotFound);
            public static readonly Error InvalidDates = new(
                "Offer.InvalidDates",
                "ValidTo must be after ValidFrom",
                ErrorType.Validation);
            public static readonly Error InvalidDiscountValue = new(
                "Offer.InvalidDiscountValue",
                "Discount value must be between 0 and 100",
                ErrorType.Validation);


            public static readonly Error InvalidDateRange =
    Error.Validation("Offer.InvalidDates", "ValidFrom must be earlier than ValidTo.");

            public static readonly Error InvalidDiscount =
                Error.Validation("Offer.InvalidDiscount", "Discount must be between 1 and 100.");

            public static readonly Error InvalidSupplier =
                Error.Validation("Offer.InvalidSupplier", "SupplierId must be a positive value.");


        }


        public static class ServerError
        {
            public static readonly Error InternalServerError = new(
                "InternalServerError",
                "An unexpected error occurred",
                ErrorType.Problem);
        }



        public static class Subscription
        {
            public static readonly Error AlreadyExists =
                Error.Conflict("Subscription.Exists", "Offer already subscribed.");
            public static readonly Error NotFound =
                Error.NotFound("Subscription.NotFound", "Subscription not found.");
            public static readonly Error NotPartnered =
                Error.Conflict("Subscription.NotPartnered", "Retailer is not partnered with supplier.");
        }

    }
}
