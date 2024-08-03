using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Application.Models;
using Uapp.Services.StudentProfile.Models;

namespace Uapp.Services.StudentProfile
{
    public interface IStudentProfileService : IBaseService
    {
        Task<StudentProfileViewModel> GetStudentProfileAsync(long id);
        Task<dynamic> GeProfileDocument(long id);
    }
}
