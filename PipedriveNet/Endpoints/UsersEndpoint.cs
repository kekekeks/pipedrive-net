using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PipedriveNet.Endpoints
{
    public class UsersEndpoint<TUser>
    {
        private readonly ApiClient _client;

        internal UsersEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task<List<TUser>> All
        {
            get { return _client.Get<List<TUser>>("users"); }
        }

        JObject PrepareUserData(string name, string email, bool active)
        {
            var req = new JObject();
            req["name"] = name;
            if (email != null)
                req["email"] = email;
            req["active_flag"] = active;

            return req;
        }

        JObject PrepareUserData(bool active)
        {
            var req = new JObject();

            req["active_flag"] = active;

            return req;
        }

        public Task<TUser> Create(string name, string email, bool active)
        {

            return _client.Post<TUser>("users", PrepareUserData(name, email, active));
        }

        public Task<TUser> Update(int id, bool active)
        {
            return _client.Put<TUser>("users/" + id, PrepareUserData(active));
        }

    }
}
