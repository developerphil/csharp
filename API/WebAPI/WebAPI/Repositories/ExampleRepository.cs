using System.Collections.Generic;
using WebAPI.Models;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class ExampleRepository : IExampleRepository
    {
        public ExampleDataModel GetData()
        {
            return new ExampleDataModel() {Id = 1, Data = "Data"};
        }

        public AuthToken GetAuthToken(string token)
        {
            return new AuthToken();
            //return _ctx.AuthTokens.Include("ApiUser").Where(t => t.Token == token).FirstOrDefault();
        }

        public bool SaveAll()
        {
            return true;
        }

        public bool Insert(AuthToken authToken)
        {
            return true;
        }

        public List<ApiUser> GetApiUsers()
        {
            return new List<ApiUser>();
        }
    }
}