using Gym.Domain.Common;

namespace Gym.Domain.Entities
{
    public class MembershipPlan : BaseEntity
    {
        public string Name { get; protected set; } = null!;
        public decimal Price { get; protected set; }

        // public int MaxSessionsPerMonth { get; set; } // ❌ breaks encapsulation
        // Must NOT be publicly mutable
        // Business rules should control this value
        public int MaxSessionsPerMonth { get; private set; }
        private MembershipPlan() { } // For EF Core


        public MembershipPlan(string name, decimal price, int maxSessionsPerMonth)
        => (Name, Price, MaxSessionsPerMonth) = (name, price, maxSessionsPerMonth);
    }
}
