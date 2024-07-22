using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Repositories;
using Nest;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class DoctorRepository : EfRepositoryBase<Doctor, Guid, BaseDbContext>, IDoctorRepository
{
    private readonly BaseDbContext _context;

    public DoctorRepository(BaseDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Doctor>> GetAvailableDoctorsAsync(int departmentId, Guid? doctorID, DateOnly? date)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);

        var query = from dr in _context.Doctors
                    join hd in _context.HospitalDepartments on dr.Hospital_DepartmentID equals hd.Id
                    join dp in _context.Departments on hd.DepartmentID equals dp.Id
                    join dss in _context.DoctorScheduleSlots on dr.Id equals dss.DoctorID
                    join dt in _context.DoctorTitles on dr.DoctorTitleID equals dt.Id

                    where dss.Date >= today && dr.Hospital_Department.DepartmentID == departmentId
                    where dss.Date == date || date == default || date == null
                    where dr.Id == doctorID || doctorID == Guid.Empty || doctorID == null
                    orderby dss.Date 
                    group new { 
                        dr.Id,
                        dr.FirstName,
                        dr.LastName,
                        dr.PhoneNumber,
                        dr.About,
                        dr.Education,
                        dr.ProfilePhoto,
                        dr.DoctorTitleID,
                        dt.Name,
                        dt.LevelIndex } 

                    by new {
                        dr.Id,
                        dr.FirstName,
                        dr.LastName,
                        dr.PhoneNumber,
                        dr.About,
                        dr.Education,
                        dr.ProfilePhoto,
                        dr.DoctorTitleID,
                        dt.Name,
                        dt.LevelIndex
                    } into g

                    select new Doctor
                    {
                        Id = g.Key.Id,
                        FirstName = g.Key.FirstName,
                        LastName = g.Key.LastName,
                        PhoneNumber = g.Key.PhoneNumber,
                        About = g.Key.About,
                        Education = g.Key.Education,
                        ProfilePhoto = g.Key.ProfilePhoto,
                        DoctorTitleID = g.Key.DoctorTitleID,
                        DoctorTitle = new DoctorTitle() { Name = g.Key.Name, LevelIndex = g.Key.LevelIndex }
                    };

        return await query.ToListAsync();
    }
}