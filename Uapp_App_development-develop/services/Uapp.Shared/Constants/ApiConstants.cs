namespace Uapp.Shared.Constants
{
    public class ApiConstants
    {
        //#if debug
        //public const string Domain = "http://localtest.uapp.uk/";
        //public const string ApiRoot = "http://localtest.uapp.uk/";

        //#else
        public const string Domain = "http://localtest.uapp.uk/";
        public const string ApiRoot = "http://localtest.uapp.uk/";
        //public const string Domain = "https://api.uapp.uk/";
        //public const string ApiRoot = "https://api.uapp.uk/";
        //#endif
        public const string Login = "account/login";
        public const string GetUser = "account/GetCurrentUser";
        public const string SignUp = "StudentRegistration/Register";
        public const string PasswordRecovery = "Account/ForgotPassword";

        public const string
            EdulcationLevelIndex = "EducationLevel/Index",
            EdulcationLevelDetails = "EducationLevel/Get",
            EdulcationLevelDelete = "EducationLevel/Delete",
            EdulcationLevelUpdate = "EducationLevel/Update",
            EducationLevelCreate = "EducationLevel/Create";

        public const string UniversityCountryDD = "UniversityCountryDD/Index";
        public const string NameTitleDD = "NameTittleDD/Index";
        public const string GetStudentProfile = "StudentProfile/Get";
        public const string GetStudentApplicationInfo = "ApplicationInfo/GetByStudentId/";



        //application
        public const string GetByStudent = "Application/GetByStudent";
        public const string GetApplicationDetails = "Application/Get";
        public const string GetApplicationAssesmentbyApplication = "ApplicationAssesment/GetByApplication";
        public const string GetDocument = "ApplicationDocument/GetDocuments?applicationid=";
        public const string ApplicationOverview = "ApplicationInfo/Overview";

        public const string profileDocument = "StudentUploadDocument/Index";
        public const string FundingInfo = "StudentFunding/Get";
        public const string FundingOverView = "StudentFunding/Overview";
    }
}
