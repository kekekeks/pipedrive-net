using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

using System.Net.Http;

namespace PipedriveNet.Endpoints
{
	public class FilesEndpoint<TFile>
	{
		private readonly ApiClient _client;

		internal FilesEndpoint(ApiClient client)
		{
			_client = client;
		}

	    public Task<List<TFile>> All
	    {
	        get { return _client.Get<List<TFile>>("files"); }
	    }

	    public Task<TFile> Create(String FileName, ByteArrayContent filedata, int dealId = 0, int personId = 0, int orgId = 0)
	    {
            MultipartFormDataContent form = new MultipartFormDataContent();
            if (dealId != 0)
            {
                form.Add(new StringContent(dealId.ToString()), "dealId");
            }
            if (personId != 0)
            {
                form.Add(new StringContent(personId.ToString()), "personId");
            }
            if (orgId != 0)
            {
                form.Add(new StringContent(orgId.ToString()), "orgId");
            }
            form.Add(filedata,"file", FileName);
            return _client.PostMultipart<TFile>("files", form);
	    }

	    public Task Delete(int id)
	    {
	        return _client.Delete("files/" + id);
	    }
	}
}
