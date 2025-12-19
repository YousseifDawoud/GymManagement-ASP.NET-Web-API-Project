using System;
using System.Collections.Generic;
using System.Text;


namespace Gym.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; protected set; }

    // Creation timestamp (Domain-level audit)
    // Set when the entity is created in memory
    protected BaseEntity() // Parameterless constructor For EF Core
    {
        CreatedAt = DateTime.UtcNow;
    }
    protected void SetUpdated() => UpdatedAt = DateTime.UtcNow;
}

// Why The Class Is Abstract ? 
// What Is the Meanig The Set Accessor Is Protected ?
// Why I`m Choise DateTime ?
// What Defference Between DateTime.Now And DateTime.UtcNow ?

