﻿using BallastLane.Domain.Interfaces;
using BallastLane.Domain.Models;
using BallastLane.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BallastLane.Infra.Data.Repository;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(BallastLaneContext context)
        : base(context)
    {

    }

    public Customer GetByEmail(string email)
    {
        return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
    }
}
