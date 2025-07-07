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
        }

        public static class ServerError
        {
            public static readonly Error InternalServerError = new(
                "InternalServerError",
                "An unexpected error occurred",
                ErrorType.Problem);
        }

    }
}
