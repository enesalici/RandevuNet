using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentReport> AppointmentReports { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<DoctorScheduleSlot> DoctorScheduleSlots { get; set; }
    public DbSet<Faq> Faqs { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<HospitalAddress> HospitalAddresses { get; set; }
    public DbSet<Hospital_Department> HospitalDepartments { get; set; }
    public DbSet<Quarter> Quarters { get; set; }
    public DbSet<DoctorTitle> DoctorTitles { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
