using System.Collections.Generic;
using UsersWebAPI.Models;

namespace UsersWebAPI.Repository
{
    public interface IUserRepository
    {
        void Add(User user);

        IEnumerable<User> GetAll();

        User Find(long id);

        void Remove(long id);

        void Update(User user);
    }
}
