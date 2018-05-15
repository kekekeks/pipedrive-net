using System.Collections.Generic;
using System.Threading.Tasks;
using PipedriveNet.Dto;

namespace PipedriveNet.Endpoints
{
    public class StagesEndpoint<TStage>
    {
        private readonly ApiClient _client;

        internal StagesEndpoint(ApiClient client)
        {
            _client = client;
        }

        public Task<List<StageDto>> All { get { return _client.Get<List<StageDto>>("stages"); } }
    }
}
