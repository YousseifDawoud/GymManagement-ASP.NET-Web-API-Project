using Gym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Domain.Entities;

/// <summary>
/// Join entity between Member and Session.
/// </summary>
public class Booking : BaseEntity
{
    public int MemberId { get; private set; }
    public Member Member { get; private set; } = null!;


    // Explicit FK + Navigation property for Session
    public int SessionId { get; private set; }
    public Session Session { get; private set; } = null!;


    public DateTime BookingDate { get; private set; }

    private Booking() { }

    public Booking(int memberId, int sessionId)
    => (MemberId, SessionId, BookingDate) = (memberId, sessionId, DateTime.UtcNow);
}