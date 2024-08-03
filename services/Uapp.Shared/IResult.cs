using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uapp.Shared
{

    public interface IResponse
    {
        public string Message { get; set; }
        bool IsSuccess { get; set; }
    }

    public interface IOResponse<out T> : IResponse
    {
        T Result { get; }
    }

    public interface IUResponse : IResponse
    {
        string Title { get; set; }
        string Type { get; set; }
        int StatusCode { get; set; }
        string[] Errors { get; set; }
    }

    public interface IUResponse<out T> : IResponse
    {
        T? Data { get; }
    }

    public interface IPaginateResult<out T> : IUResponse where T : class
    {
        int From { get; }

        int Index { get; }

        int Size { get; }

        long TotalFiltered { get; }

        long Total { get; }

        int Pages { get; }

        IReadOnlyList<T> Items { get; }

        bool HasPrevious { get; }

        bool HasNext { get; }
    }

    public interface IUserManagerResponse : IResponse
    {
        public List<int> Permissions { get; set; }
        public List<MenuItemViewModel> MenuItems { get; set; }
        public DateTime ExpireDate { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }

    public interface ILoginResponse : IResponse
    {
        public string DisplayName { get; set; }
        public string DisplayEmail { get; set; }
        public string DisplayUserType { get; set; }
        public string DisplayImage { get; set; }
        public long UserTypeId { get; set; }
        public long ReferenceId { get; set; }
        public string RoleName { get; set; }
        public string UserViewId { get; set; }
        public bool IsActive { get; set; }
    }

    public class MenuItemViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string NavLink { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public long? ParentId { get; set; }
        public string ParentName { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public IEnumerable<MenuItemViewModel> Children { get; set; } = default!;

    }

}
