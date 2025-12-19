using Gym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public string FullName { get; set; } = null!;
        public string Specialty { get; set; } = null!;

        private readonly List<Session> _sessions = new();
        public IReadOnlyCollection<Session> Sessions => _sessions;

        private Trainer() { }

        public Trainer(string fullName, string specialty)
        => (FullName , Specialty) = (fullName, specialty);
    }
}
