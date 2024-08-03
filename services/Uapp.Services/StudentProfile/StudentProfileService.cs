using System;
using System.Threading.Tasks;
using Uapp.Services.Application.ApplicationList.Models;
using Uapp.Services.Application.Models;
using Uapp.Services.StudentProfile.Models;
using Uapp.Shared.Constants;
using Uapp.Shared.Http;
using Uapp.Shared.Responses;

namespace Uapp.Services.StudentProfile
{
    public class StudentProfileService : IStudentProfileService
    {
        private readonly IHttpService _httpService;

        public StudentProfileService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<StudentProfileViewModel> GetStudentProfileAsync(long id)
        {
            var response = await _httpService.Request<OldResponse<StudentProfileViewModel>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.GetStudentProfile}/{id}"); ;
            return response?.Result;
        }

        public async Task<dynamic> GeProfileDocument(long id)
        {
            var response = await _httpService.Request<OldResponse<List<ApplicationDocumentViewModel>>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.profileDocument}/{id}");
            return response?.Result;
        }
    }
}
