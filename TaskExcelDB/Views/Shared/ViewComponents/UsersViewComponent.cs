using Microsoft.AspNetCore.Mvc;
using TaskExcelDB.Repository.User;

namespace TaskExcelDB.Views.Shared.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {
        private readonly IUserRepository _userRepository;

        public UsersViewComponent(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = _userRepository.GetAllUsers();
            return View(users);
        }
    }
}
