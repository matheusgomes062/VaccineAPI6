﻿using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Patient> Patients { get; set; }
    // public DbSet<Vaccine> Vaccines { get; set; }
  }
}
