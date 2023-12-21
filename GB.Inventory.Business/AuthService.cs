using GB.Inventory.Repository;
using GB.Inventory.Repository.DatabaseRepositories;
using System.Reflection;

namespace GB.Inventory.Business
{
    public class AuthService
    {
        private DatabaseContext dbContext;
        private UserRepository userRepo;

        public AuthService()
        {
            this.dbContext = new DatabaseContext();
            userRepo = new UserRepository(this.dbContext);
        }

        public bool IsValidUser(string username, string password, out Model.User user)
        {
            user = userRepo.GetUserByUserName(username);

            if (user == null || user.Password == null) return false;

            return password == user.Password;
        }
    }
}