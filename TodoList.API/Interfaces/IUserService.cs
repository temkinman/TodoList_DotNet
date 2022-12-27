using TodoList.ViewModels.Models;

namespace TodoList.API.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetUserViewModel(Guid id);
        void CreateUserViewModel(UserViewModel userViewmodel);
        void DeleteUserViewModel(Guid id);
        void UpdateUserViewModel(UserViewModel userViewmodel);
        Task<UserViewModel> GetDefaultUserViewModel();
    }
}
