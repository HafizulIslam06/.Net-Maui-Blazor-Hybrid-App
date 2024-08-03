using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uapp.Shared.Http;

namespace Uapp.Shared.Responses
{
    public class OldResponse<T> : IOResponse<T>
    {
        public T Result { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}
