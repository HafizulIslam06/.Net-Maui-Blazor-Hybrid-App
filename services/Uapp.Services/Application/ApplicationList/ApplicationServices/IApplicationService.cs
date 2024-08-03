using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Application.ApplicationList.Models;
using Uapp.Services.Auth.Models;
using Uapp.Shared.Responses;

namespace Uapp.Services.Application.ApplicationList.ApplicationServices
{
    public interface IApplicationService:IBaseService
    {
        Task<dynamic> GetbyStudentAsync();
        Task<dynamic> GeApplicationDetails(long id);
        Task<dynamic> GeApplicationDocument(long id);
        Task<dynamic> GeApplicationOverview(long id);
        Task<dynamic> GeApplicationAssesmentbyApplication(long id);
    }
}
