namespace Application.Features.DoctorTitles.Constants;

public static class DoctorTitlesOperationClaims
{
    private const string _section = "DoctorTitles";

    public const string Admin = $"{_section}.Admin";

    public const string Read = $"{_section}.Read";
    public const string Write = $"{_section}.Write";

    public const string Create = $"{_section}.Create";
    public const string Update = $"{_section}.Update";
    public const string Delete = $"{_section}.Delete";
}