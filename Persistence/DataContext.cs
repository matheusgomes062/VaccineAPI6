using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<PatientVaccine> PatientVaccines { get; set; }
    public DbSet<Vaccine> Vaccines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<PatientVaccine>(x =>
        x.HasKey(pv => new { pv.PatientId, pv.VaccineId }));

      modelBuilder.Entity<PatientVaccine>()
        .HasOne(pv => pv.Patient)
        .WithMany(p => p.PatientVaccines)
        .HasForeignKey(pv => pv.PatientId);

      modelBuilder.Entity<PatientVaccine>()
        .HasOne(pv => pv.Vaccine)
        .WithMany(p => p.PatientVaccines)
        .HasForeignKey(pv => pv.VaccineId);

      base.OnModelCreating(modelBuilder);
    }
  }
}
