namespace Application.Features.Departments.Constants;

public static class DepartmentsOperationClaims
{
    private const string _section = "Departments";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
    
    public const string GetDoctorsByDepartmentId = $"{_section}.GetDoctorsByDepartmentId";
    
    public const string GetAvailableDoctors = $"{_section}.GetAvailableDoctors";
}
