﻿using Bookify.Application.Abstractions.Email;
using Bookify.Domain.Bookings;
using Bookify.Domain.Bookings.Events;
using Bookify.Domain.Users;
using MediatR;

namespace Bookify.Application.Bookings.ReserveBooking;

internal sealed class BookingReservedDomainEventHandler : INotificationHandler<BookingReservedDomainEvent>
{
    private readonly IUserRepository _userRepository;
    private readonly IBookingRepository _bookingRepository;
    private IEmailService _emailService;

    public BookingReservedDomainEventHandler(
        IUserRepository userRepository,
        IBookingRepository bookingRepository,
        IEmailService emailService)
    {
        _userRepository = userRepository;
        _bookingRepository = bookingRepository;
        _emailService = emailService;
    }


    public async Task Handle(BookingReservedDomainEvent notification, CancellationToken cancellationToken)
    {
        var booking = await _bookingRepository.GetByIdAsync(notification.BookingId, cancellationToken);

        if (booking == null)
        {
            return;
        }

        var user = await _userRepository.GetByIdAsync(booking.UserId, cancellationToken);

        if (user == null) 
        { 
            return; 
        } 

        await _emailService.SendAsync(
            user.Email,
            "Booking Reserved!",
            "You have 10 minutes to confirm this booking");
    }
}
