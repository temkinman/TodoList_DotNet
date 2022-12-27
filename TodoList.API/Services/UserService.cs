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

        public void Create(UserViewModel userViewmodel)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserViewModel Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserViewModel> GetDefault()
        {
            User user = await _userRepository.GetDefaultUser();
            UserViewModel userViewModel = user.MapToUser();

            return userViewModel;
        }

        public void Update(UserViewModel userViewmodel)
        {
            throw new NotImplementedException();
        }
    }
}
