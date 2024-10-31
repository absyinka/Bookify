using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public record PricingDetails(
    Money PricingForPeriod,
    Money CleaningFee,
    Money AmentiesUpCharge,
    Money TotalPrice
    );
