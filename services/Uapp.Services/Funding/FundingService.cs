using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Application.Models;
using Uapp.Services.Funding.Model;
using Uapp.Shared.Constants;
using Uapp.Shared.Http;
using Uapp.Shared.Responses;

namespace Uapp.Services.Funding
{
    public class FundingService : IFundingService
    {
        private readonly IHttpService _httpService;

        public FundingService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<FundingModel> GetByStudentId(long id)
        {
            var response = await _httpService.Request<OldResponse<FundingModel>>().Get($"{ApiConstants.ApiRoot}{ApiConstants.FundingOverView}/{id}");
            return response?.Result;
        }
    }
}
