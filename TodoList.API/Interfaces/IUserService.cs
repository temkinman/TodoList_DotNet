using TodoList.ViewModels.Models;

namespace TodoList.API.Interfaces
{
    public interface IUserService
    {
        UserViewModel Get(Guid id);
        void Create(UserViewModel userViewmodel);
        void Delete(Guid id);
        void Update(UserViewModel userViewmodel);
        Task<UserViewModel> GetDefault();
    }
}
