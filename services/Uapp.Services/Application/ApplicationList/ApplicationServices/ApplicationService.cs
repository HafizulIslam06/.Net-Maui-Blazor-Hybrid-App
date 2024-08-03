using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Uapp.Services.Application.ApplicationList.ApplicationServices;
using Uapp.Services.Application.ApplicationList.Models;
using Uapp.Services.Application.Models;
using Uapp.Shared.Constants;
using Uapp.Shared.Core.Services;
using Uapp.Shared.Http;
using Uapp.Shared.Models;
using Uapp.Shared.Responses;

namespace Uapp.Services.Application.ApplicationList.ApplicationServices
{
    public class ApplicationService : IApplicationService
    {
        private IHttpService _httpService;

        public ApplicationService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<dynamic> GeApplicationAssesmentbyApplication(long id)
        {
            try
            {
                var request =  _httpService.Request<OldResponse<ApplicationAssesmentViewModel>>();

                var response = await request.Get($"{ApiConstants.ApiRoot}{ApiConstants.GetApplicationAssesmentbyApplication}/{id}"); ;


                if (response != null)
                {
                    return response?.Result;
                }
                else
                {
                    // Log or handle the case where the response is null
                    return new List<ApplicationListViewModel>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                // Optionally, rethrow the exception or return a default value
                throw new ApplicationException("An error occurred while getting applications by student.", ex);
            }
        }

        public async Task<dynamic> GeApplicationDetails(long id)
        {
            try
            {
                var response = await _httpService.Request<OldResponse<ApplicationDetailsModel>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.GetApplicationDetails}/{id}"); ;

                if (response != null)
                {
                    return response?.Result;
                }
                else
                {
                    // Log or handle the case where the response is null
                    return new List<ApplicationListViewModel>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                // Optionally, rethrow the exception or return a default value
                throw new ApplicationException("An error occurred while getting applications by student.", ex);
            }
        }

        public async Task<dynamic> GeApplicationDocument(long id)
        {
            try
            {
                var response = await _httpService.Request<OldResponse<List<ApplicationDocumentViewModel>>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.GetDocument}{id}");

                if (response != null)
                {
                    return response?.Result;
                }
                else
                {
                    // Log or handle the case where the response is null
                    return new List<ApplicationListViewModel>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                // Optionally, rethrow the exception or return a default value
                throw new ApplicationException("An error occurred while getting applications by student.", ex);
            }
        }

        public async Task<dynamic> GeApplicationOverview(long id)
        {
            try
            {
                var response = await _httpService.Request<OldResponse<ApplicationOverviewViewModel>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.ApplicationOverview}/{id}");

                if (response != null)
                {
                    return response?.Result;
                }
                else
                {
                    // Log or handle the case where the response is null
                    return new List<ApplicationListViewModel>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                // Optionally, rethrow the exception or return a default value
                throw new ApplicationException("An error occurred while getting applications by student.", ex);
            }

        }

        public async Task<dynamic> GetbyStudentAsync()
        {
            try
            {
                var response = await _httpService.Request<OldResponse<List<ApplicationListViewModel>>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.GetByStudent}"); ;

                if (response != null)
                {
                    return response?.Result;
                }
                else
                {
                    // Log or handle the case where the response is null
                    return new List<ApplicationListViewModel>();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) here
                // Optionally, rethrow the exception or return a default value
                throw new ApplicationException("An error occurred while getting applications by student.", ex);
            }
        }
    }
}
