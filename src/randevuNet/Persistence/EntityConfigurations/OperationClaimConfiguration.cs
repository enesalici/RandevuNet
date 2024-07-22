using Application.Features.Auth.Constants;
using Application.Features.OperationClaims.Constants;
using Application.Features.UserOperationClaims.Constants;
using Application.Features.Users.Constants;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NArchitecture.Core.Security.Constants;
using Application.Features.Appointments.Constants;
using Application.Features.AppointmentReports.Constants;
using Application.Features.Cities.Constants;
using Application.Features.Countries.Constants;
using Application.Features.Departments.Constants;
using Application.Features.Districts.Constants;
using Application.Features.DoctorScheduleSlots.Constants;
using Application.Features.Faqs.Constants;
using Application.Features.Feedbacks.Constants;
using Application.Features.Hospitals.Constants;
using Application.Features.HospitalAddresses.Constants;
using Application.Features.HospitalDepartments.Constants;
using Application.Features.Quarters.Constants;
using Application.Features.DoctorTitles.Constants;
using Application.Features.Doctors.Constants;
using Application.Features.Patients.Constants;
using Application.Features.UserRoles.Constants;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static int AdminId => 1;
    private IEnumerable<OperationClaim> _seeds
    {
        get
        {
            yield return new() { Id = AdminId, Name = GeneralOperationClaims.Admin };

            IEnumerable<OperationClaim> featureOperationClaims = getFeatureOperationClaims(AdminId);
            foreach (OperationClaim claim in featureOperationClaims)
                yield return claim;
        }
    }

#pragma warning disable S1854 // Unused assignments should be removed
    private IEnumerable<OperationClaim> getFeatureOperationClaims(int initialId)
    {
        int lastId = initialId;
        List<OperationClaim> featureOperationClaims = new();

        #region Auth
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AuthOperationClaims.Admin },
                new() { Id = ++lastId, Name = AuthOperationClaims.Read },
                new() { Id = ++lastId, Name = AuthOperationClaims.Write },
                new() { Id = ++lastId, Name = AuthOperationClaims.RevokeToken },
            ]
        );
        #endregion

        #region OperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = OperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region UserOperationClaims
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Read },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Write },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Create },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Update },
                new() { Id = ++lastId, Name = UserOperationClaimsOperationClaims.Delete },
            ]
        );
        #endregion

        #region Users
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UsersOperationClaims.Admin },
                new() { Id = ++lastId, Name = UsersOperationClaims.Read },
                new() { Id = ++lastId, Name = UsersOperationClaims.Write },
                new() { Id = ++lastId, Name = UsersOperationClaims.Create },
                new() { Id = ++lastId, Name = UsersOperationClaims.Update },
                new() { Id = ++lastId, Name = UsersOperationClaims.Delete },
            ]
        );
        #endregion

        
        #region Appointments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Read },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Write },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Create },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Update },
                new() { Id = ++lastId, Name = AppointmentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region AppointmentReports CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = AppointmentReportsOperationClaims.Admin },
                new() { Id = ++lastId, Name = AppointmentReportsOperationClaims.Read },
                new() { Id = ++lastId, Name = AppointmentReportsOperationClaims.Write },
                new() { Id = ++lastId, Name = AppointmentReportsOperationClaims.Create },
                new() { Id = ++lastId, Name = AppointmentReportsOperationClaims.Update },
                new() { Id = ++lastId, Name = AppointmentReportsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Cities CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CitiesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Read },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Write },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Create },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Update },
                new() { Id = ++lastId, Name = CitiesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Countries CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = CountriesOperationClaims.Admin },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Read },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Write },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Create },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Update },
                new() { Id = ++lastId, Name = CountriesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Departments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Read },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Write },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Create },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Update },
                new() { Id = ++lastId, Name = DepartmentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Districts CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Read },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Write },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Create },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Update },
                new() { Id = ++lastId, Name = DistrictsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DoctorScheduleSlots CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DoctorScheduleSlotsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DoctorScheduleSlotsOperationClaims.Read },
                new() { Id = ++lastId, Name = DoctorScheduleSlotsOperationClaims.Write },
                new() { Id = ++lastId, Name = DoctorScheduleSlotsOperationClaims.Create },
                new() { Id = ++lastId, Name = DoctorScheduleSlotsOperationClaims.Update },
                new() { Id = ++lastId, Name = DoctorScheduleSlotsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Faqs CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FaqsOperationClaims.Admin },
                new() { Id = ++lastId, Name = FaqsOperationClaims.Read },
                new() { Id = ++lastId, Name = FaqsOperationClaims.Write },
                new() { Id = ++lastId, Name = FaqsOperationClaims.Create },
                new() { Id = ++lastId, Name = FaqsOperationClaims.Update },
                new() { Id = ++lastId, Name = FaqsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Feedbacks CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = FeedbacksOperationClaims.Admin },
                new() { Id = ++lastId, Name = FeedbacksOperationClaims.Read },
                new() { Id = ++lastId, Name = FeedbacksOperationClaims.Write },
                new() { Id = ++lastId, Name = FeedbacksOperationClaims.Create },
                new() { Id = ++lastId, Name = FeedbacksOperationClaims.Update },
                new() { Id = ++lastId, Name = FeedbacksOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Hospitals CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = HospitalsOperationClaims.Admin },
                new() { Id = ++lastId, Name = HospitalsOperationClaims.Read },
                new() { Id = ++lastId, Name = HospitalsOperationClaims.Write },
                new() { Id = ++lastId, Name = HospitalsOperationClaims.Create },
                new() { Id = ++lastId, Name = HospitalsOperationClaims.Update },
                new() { Id = ++lastId, Name = HospitalsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region HospitalAddresses CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = HospitalAddressesOperationClaims.Admin },
                new() { Id = ++lastId, Name = HospitalAddressesOperationClaims.Read },
                new() { Id = ++lastId, Name = HospitalAddressesOperationClaims.Write },
                new() { Id = ++lastId, Name = HospitalAddressesOperationClaims.Create },
                new() { Id = ++lastId, Name = HospitalAddressesOperationClaims.Update },
                new() { Id = ++lastId, Name = HospitalAddressesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region HospitalDepartments CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = HospitalDepartmentsOperationClaims.Admin },
                new() { Id = ++lastId, Name = HospitalDepartmentsOperationClaims.Read },
                new() { Id = ++lastId, Name = HospitalDepartmentsOperationClaims.Write },
                new() { Id = ++lastId, Name = HospitalDepartmentsOperationClaims.Create },
                new() { Id = ++lastId, Name = HospitalDepartmentsOperationClaims.Update },
                new() { Id = ++lastId, Name = HospitalDepartmentsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Quarters CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = QuartersOperationClaims.Admin },
                new() { Id = ++lastId, Name = QuartersOperationClaims.Read },
                new() { Id = ++lastId, Name = QuartersOperationClaims.Write },
                new() { Id = ++lastId, Name = QuartersOperationClaims.Create },
                new() { Id = ++lastId, Name = QuartersOperationClaims.Update },
                new() { Id = ++lastId, Name = QuartersOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region DoctorTitles CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DoctorTitlesOperationClaims.Admin },
                new() { Id = ++lastId, Name = DoctorTitlesOperationClaims.Read },
                new() { Id = ++lastId, Name = DoctorTitlesOperationClaims.Write },
                new() { Id = ++lastId, Name = DoctorTitlesOperationClaims.Create },
                new() { Id = ++lastId, Name = DoctorTitlesOperationClaims.Update },
                new() { Id = ++lastId, Name = DoctorTitlesOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Doctors CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = DoctorsOperationClaims.Admin },
                new() { Id = ++lastId, Name = DoctorsOperationClaims.Read },
                new() { Id = ++lastId, Name = DoctorsOperationClaims.Write },
                new() { Id = ++lastId, Name = DoctorsOperationClaims.Create },
                new() { Id = ++lastId, Name = DoctorsOperationClaims.Update },
                new() { Id = ++lastId, Name = DoctorsOperationClaims.Delete },
            ]
        );
        #endregion
        
        
        #region Patients CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = PatientsOperationClaims.Admin },
                new() { Id = ++lastId, Name = PatientsOperationClaims.Read },
                new() { Id = ++lastId, Name = PatientsOperationClaims.Write },
                new() { Id = ++lastId, Name = PatientsOperationClaims.Create },
                new() { Id = ++lastId, Name = PatientsOperationClaims.Update },
                new() { Id = ++lastId, Name = PatientsOperationClaims.Delete },
            ]
        );
        #endregion

        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = HospitalsOperationClaims.GetDepartmentsByHospitalId });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = DepartmentsOperationClaims.GetDoctorsByDepartmentId });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = DepartmentsOperationClaims.GetAvailableDoctors });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = DoctorsOperationClaims.GetDoctorSchedulesByDoctorId });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = CountriesOperationClaims.GetCitiesByCountryId });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = CitiesOperationClaims.GetDistrictsByCityId });
        
        featureOperationClaims.Add(new() { Id = ++lastId, Name = DistrictsOperationClaims.GetQuartersByDistrictId });
        
        #region UserRoles CRUD
        featureOperationClaims.AddRange(
            [
                new() { Id = ++lastId, Name = UserRolesOperationClaims.Admin },
                new() { Id = ++lastId, Name = UserRolesOperationClaims.Read },
                new() { Id = ++lastId, Name = UserRolesOperationClaims.Write },
                new() { Id = ++lastId, Name = UserRolesOperationClaims.Create },
                new() { Id = ++lastId, Name = UserRolesOperationClaims.Update },
                new() { Id = ++lastId, Name = UserRolesOperationClaims.Delete },
            ]
        );
        #endregion
        
        return featureOperationClaims;
    }
#pragma warning restore S1854 // Unused assignments should be removed
}
