using TodoList.API.Extensions;
using TodoList.API.Interfaces;
using TodoList.DataAccess.Interfaces;
using TodoList.DataAccess.Models;
using TodoList.ViewModels.Models;

namespace TodoList.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _userRepository;

        public UserService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUserViewModel(UserViewModel userViewmodel)
        {
            throw new NotImplementedException();
        }

        public void DeleteUserViewModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUserViewModel(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetDefaultUserViewModel()
        {
            User user = await _userRepository.GetDefaultUser();
            UserViewModel userViewModel = user.MapToUser();

            return userViewModel;
        }

        public void UpdateUserViewModel(UserViewModel userViewmodel)
        {
            throw new NotImplementedException();
        }
    }
}
