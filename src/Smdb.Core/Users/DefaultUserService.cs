using Shared.Http;
using System.Net;

namespace Smdb.Core.Users;

public class DefaultUserService : IUserService
{
    private IUserRepository repository;

    public DefaultUserService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Result<PagedResult<User>>> ReadUsers(int page, int size)
    {
        if (page < 1 || size < 1)
            return new Result<PagedResult<User>>(new Exception("Invalid pagination"), 400);

        var data = await repository.ReadUsers(page, size);

        return data == null
            ? new Result<PagedResult<User>>(new Exception("Not found"), 404)
            : new Result<PagedResult<User>>(data, 200);
    }

    public async Task<Result<User>> CreateUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            return new Result<User>(new Exception("Name required"), 400);

        var result = await repository.CreateUser(user);

        return result == null
            ? new Result<User>(new Exception("Error"), 404)
            : new Result<User>(result, 201);
    }

    public async Task<Result<User>> ReadUser(int id)
    {
        var result = await repository.ReadUser(id);

        return result == null
            ? new Result<User>(new Exception("Not found"), 404)
            : new Result<User>(result, 200);
    }

    public async Task<Result<User>> UpdateUser(int id, User newData)
    {
        var result = await repository.UpdateUser(id, newData);

        return result == null
            ? new Result<User>(new Exception("Not found"), 404)
            : new Result<User>(result, 200);
    }

    public async Task<Result<User>> DeleteUser(int id)
    {
        var result = await repository.DeleteUser(id);

        return result == null
            ? new Result<User>(new Exception("Not found"), 404)
            : new Result<User>(result, 200);
    }
}