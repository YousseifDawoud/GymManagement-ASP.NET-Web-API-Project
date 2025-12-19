using Gym.Domain.Common;
using Gym.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Domain.Entities;

/// <summary>
/// Represents a gym member.
/// </summary>
public class Member : BaseEntity
{
    public string FullName { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string Email { get; private set; } = null!;

    public DateOnly MembershipStartDate { get; private set; }
    public DateOnly MembershipEndDate { get; private set; }

    public MembershipStatus Status { get; private set; }


    // Explicit FK + Navigation
    public int MembershipPlanId { get; private set; }
    public MembershipPlan MembershipPlan { get; private set; } = null!;


    // Backing field to protect collection
    private readonly List<Booking> _bookings = new();

    // Read-only exposure (DDD best practice)
    public IReadOnlyCollection<Booking> Bookings => _bookings;


    private Member() { } // For EF Core

    public Member(
        string fullName,
        string phone,
        string email,
        DateOnly startDate,
        DateOnly endDate,
        int membershipPlanId
        )
        => (FullName, Phone, Email, MembershipStartDate, MembershipEndDate, MembershipPlanId, Status)
        = (fullName, phone, email, startDate, endDate, membershipPlanId, MembershipStatus.Active);

        public void ExpireMembership()
        {
            Status = MembershipStatus.Expired;
            SetUpdated();
        }
}

// Encapsulation =>  (private set)
// Uses DateOnly (modern & clean)
// Explicit FK + navigation (MembershipPlanId)
// Business behavior => ExpireMembership method

