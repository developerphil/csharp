using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Repositories.Interfaces
{
    public interface IExampleRepository
    {
        ExampleDataModel GetData();

        AuthToken GetAuthToken(string token);

        bool SaveAll();

        bool Insert(AuthToken authToken);

        List<ApiUser> GetApiUsers();
    }
}