using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Uapp.Shared.Models.Common;
namespace Uapp.Services.StudentProfile.Models
{
    public class StudentProfileViewModel
    {
        // Personal Information
        public long Id { get; set; }
        public string StudentViewId { get; set; }
        public string NameTittle { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name => $"{NameTittle} {FirstName} {LastName}";
        public DateTime? DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string CountryOfResidence { get; set; }
        public string PassportNumber { get; set; }
        public DateTime IssueDate { get; set; } = new DateTime();
        public DateTime ExpiryDate { get; set; } = new DateTime();                  
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string PhoneNumber { get; set; }        
        public string Email { get; set; }
        public string CountryOfBirth { get; set; }

        public MediaFile ProfileImage { get; set; } //ProfileImageId

        //Contact Info
        public List<ProfileStudentContactInformationViewModel> StudentContactInfos { get; set; }

        //Educational Info
        public List<ProfileEducationInfoViewModel> EducationInfos { get; set; }

        //Test Score
        public IELTSScoreViewModel IELTSScore { get; set; }
        public GreScore greScoreInfo { get; set; }
        public GmatScore gmatScoreInfo { get; set; }

        //Experiance Info
        public List<ProfileExperienceViewModel> experienceinfo { get; set; }

        //Reference Info
        public List<profileReferenceViewModel> referenceInfo { get; set; }

        //Personal Statement
        public profilePersonalStatementViewModel profilePersonalStatement { get; set; }
        //Other Info
        public profileOtherInformationViewModel profileOtherInfo { get; set; }

        }
    public class MediaFile
    {
        public string FileUrl { get; set; }
        public string ThumbnailUrl { get; set; }
    }
    public class ProfileStudentContactInformationViewModel
    {
        public long Id { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string HouseNo { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public long StudentId { get; set; }
        public AddressType AddressType { get; set; }
        public Country Country { get; set; }
    }
    public class AddressType()
    {
        public string Name { get; set; }
    }

    public class Country()
    {
        public string Name { get; set; }
    }
    public class IELTSScoreViewModel
    {
        public long StudentId { get; set; }
        public decimal Overall { get; set; }
        public decimal Speaking { get; set; }
        public decimal Reading { get; set; }
        public decimal Writing { get; set; }
        public decimal Listening { get; set; }
        public DateTime ExamDate { get; set; }
    }
    public class GmatScore
    {
        public long StudentId { get; set; }
        public bool? HaveGmatExam { get; set; }
        public DateTime? GmatExamDate { get; set; }
        public string VerbalScore { get; set; }
        public string VerbalRank { get; set; }
        public string QuantitativeScore { get; set; }
        public string QuantitativeRank { get; set; }
        public string WritingScore { get; set; }
        public string WritingRank { get; set; }
        public decimal TotalScore { get; set; }
        public decimal TotalRank { get; set; }
    }
    public class GreScore
    {
        public long StudentId { get; set; }
        public bool? HaveGreExam { get; set; }
        public DateTime? GreExamDate { get; set; }
        public string VerbalScore { get; set; }
        public string VerbalRank { get; set; }
        public string QuantitativeScore { get; set; }
        public string QuantitativeRank { get; set; }
        public string WritingScore { get; set; }
        public string WritingRank { get; set; }
        public decimal TotalScore { get; set; }
        public decimal TotalRank { get; set; }
    }

    public class profilePersonalStatementViewModel
    {
        public string Statement { get; set; }
        public string ScanId { get; set; }
    }

    public class profileOtherInformationViewModel
    {
        public bool IsHaveDisability { get; set; }
        public string DisabilityDescription { get; set; }
        public bool IsHaveCriminalConvictions { get; set; }
        public string CriminalConvictionsDescription { get; set; }
    }

    public class ProfileEducationInfoViewModel
    {
        public string EducationLevelName { get; set; }
        public string NameOfInstitution { get; set; }
        public DateTime AttendedInstitutionFrom { get; set; }
        public bool StillStudying { get; set; }
        public DateTime? AttendedInstitutionTo { get; set; }
        public string QualificationSubject { get; set; }
        public string Duration { get; set; }
        public int FinalGrade { get; set; }
    }
    public class profileReferenceViewModel
    {
        public string ReferenceTypeName { get; set; }
        public string ReferenceName { get; set; }
        public string Institute_Company { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Country { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }

    public class ProfileExperienceViewModel
    {
        public string EmployeementDetails { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsStillWorking { get; set; }
    }
}

