using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Services.Application.Models;

public class ApplicationDetailsModel
{

    public long Id { get; set; }
    public string ApplicationViewId { get; set; }
    public DateTime applicationTime { get; set; }
    public StudentModel Student { get; set; }
    public SubjectModel Subject { get; set; }
    public IntakeModel Intake { get; set; }
    public CampusModel Campus { get; set; }
    public ApplicationStatusViewModel ApplicationStatus { get; set; }
    public EnrollmentStatusViewModel EnrollmentStatus { get; set; }
    public StudentFinanceStatusViewModel StudentFinanceStatus { get; set; }
    public DeliveryPatternViewModel DeliveryPattern { get; set; }
    public UniversityModel University { get; set; }
    public ConsultantModel Consultant { get; set; }
    public AdmissionManagerViewModel AdmissionManager { get; set; }
}

public class StudentModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
}
public class SubjectModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class IntakeModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}
public class UniversityModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}
public class CampusModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}
public class ApplicationStatusViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}
public class EnrollmentStatusViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}
public class StudentFinanceStatusViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}
public class DeliveryPatternViewModel
{
    public long Id { get; set; }
    public string Name { get; set; }
}

public class ConsultantModel
{
    //public List<ConsoleKeyInfo> CompanyConsultantInformations
    public long Id { get; set; }
    public NameTitle NameTitle { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string viewId { get; set; }
    public string FullName => NameTitle != null ? $"{NameTitle.Name} {FirstName} {LastName}" : $"{FirstName} {LastName}";
}
public class AdmissionManagerViewModel
{
    //public List<ConsoleKeyInfo> CompanyConsultantInformations
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
public class NameTitle
{
    public long Id { get; set; }
    public string Name { get; set; }
}