using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Services.Funding.Model;

namespace Uapp.Services.Funding
{
    public interface IFundingService : IBaseService
    {
        Task<FundingModel> GetByStudentId(long id);
    }
}
