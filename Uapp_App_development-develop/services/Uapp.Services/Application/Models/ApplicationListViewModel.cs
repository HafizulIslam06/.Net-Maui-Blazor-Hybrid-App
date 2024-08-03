using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Services.Application.ApplicationList.Models
{
    public class ApplicationListViewModel
    {
        public long Id { get; set; }
        public string ApplicationViewId { get; set; }
        public string ApplicationStatusName { get; set; }
        public long ApplicationStatusId { get; set; }
        public string SubjectName { get; set; }
        public string UniversityName { get; set; }
        public string CampusName { get; set; }
        public string IntakeName { get; set; }
        public string EnrollmentStatusName { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
