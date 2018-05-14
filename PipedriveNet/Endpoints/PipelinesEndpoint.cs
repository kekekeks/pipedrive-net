using System.Collections.Generic;
using System.Threading.Tasks;

namespace PipedriveNet.Endpoints
{
    public class PipelinesEndpoint<TPipeline>
    {
        private readonly ApiClient _client;

        internal PipelinesEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task<List<TPipeline>> All { get { return _client.Get<List<TPipeline>>("pipelines"); } }
    }
}
