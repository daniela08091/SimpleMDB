using Shared.Http;
using Smdb.Core.Db;

namespace Smdb.Core.Users;

public class MemoryUserRepository : IUserRepository
{
    private MemoryDatabase db;

    public MemoryUserRepository(MemoryDatabase db)
    {
        this.db = db;
    }

    public async Task<PagedResult<User>?> ReadUsers(int page, int size)
    {
        int total = db.Users.Count;
        int start = Math.Clamp((page - 1) * size, 0, total);
        int length = Math.Clamp(size, 0, total - start);

        var values = db.Users.Slice(start, length);
        return await Task.FromResult(new PagedResult<User>(total, values));
    }

    public async Task<User?> CreateUser(User user)
    {
        user.Id = db.NextUserId();
        db.Users.Add(user);
        return await Task.FromResult(user);
    }

    public async Task<User?> ReadUser(int id)
    {
        return await Task.FromResult(db.Users.FirstOrDefault(u => u.Id == id));
    }

    public async Task<User?> UpdateUser(int id, User newData)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
        {
            user.Name = newData.Name;
            user.Email = newData.Email;
        }

        return await Task.FromResult(user);
    }

    public async Task<User?> DeleteUser(int id)
    {
        var user = db.Users.FirstOrDefault(u => u.Id == id);
        if (user != null)
            db.Users.Remove(user);

        return await Task.FromResult(user);
    }
}