namespace Smdb.Core.Users;

using Shared.Http;
using Smdb.Core.Db;

public class MemoryUserRepository : IUserRepository
{
    private MemoryDatabase db;

    public MemoryUserRepository(MemoryDatabase db)
    {
        this.db = db;
    }

    public async Task<PagedResult<User>?> ReadUsers(int page, int size)
    {
        int totalCount = db.Users.Count;
        int start = Math.Clamp((page - 1) * size, 0, totalCount);
        int length = Math.Clamp(size, 0, totalCount - start);
        var values = db.Users.Slice(start, length);
        var result = new PagedResult<User>(totalCount, values);

        return await Task.FromResult(result);
    }

    public async Task<User?> CreateUser(User newUser)
    {
        newUser.Id = db.NextUserId();
        db.Users.Add(newUser);

        return await Task.FromResult(newUser);
    }

    public async Task<User?> ReadUser(int id)
    {
        User? result = db.Users.FirstOrDefault(m => m.Id == id);
        return await Task.FromResult(result);
    }
    public async Task<User?> UpdateUser(int id, User newData)
    {
        User? result = db.Users.FirstOrDefault(m => m.Id == id);

        if (result != null)
        {
            result.UserName = newData.UserName;
            result.YearBirth = newData.YearBirth;
            result.Email = newData.Email;
        }

        return await Task.FromResult(result);
    }

    public async Task<User?> DeleteUser(int id)
    {
        User? result = db.Users.FirstOrDefault(m => m.Id == id);

        if (result != null) { db.Users.Remove(result); }

        return await Task.FromResult(result);
    }
}