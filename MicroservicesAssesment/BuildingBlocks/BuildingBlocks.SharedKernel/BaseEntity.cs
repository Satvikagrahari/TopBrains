using System;
using System.Collections.Generic;
using System.Text;

namespace BuildingBlocks.SharedKernel;

public abstract class BaseEntity
{
    public Guid Id { get; protected set; } = Guid.NewGuid();
}
