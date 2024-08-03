using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Services.Application.Models;

public class ApplicationDocumentViewModel
{
    public long CategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<ApplicationDocuments> ApplicationDocuments { get; set; } = new List<ApplicationDocuments>();
    public List<ProfileDocument> Documents { get; set; } = new List<ProfileDocument>();
}

public class ProfileDocument
{
    public long Id { get; set; }
    public string DocumentLevelName { get; set; }
}

public class ApplicationDocuments
{
    public long Id { get; set; }
    public string DocumentName { get; set; }
}
