﻿using BallastLane.Domain.Core.Commands;

namespace BallastLane.Domain.Commands;

public abstract class CustomerCommand : Command
{
    public Guid Id { get; protected set; }

    public string Name { get; protected set; }

    public string Email { get; protected set; }

    public DateTime BirthDate { get; protected set; }
}
