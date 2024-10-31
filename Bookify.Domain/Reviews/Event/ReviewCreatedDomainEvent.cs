using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews.Event;

public sealed record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
