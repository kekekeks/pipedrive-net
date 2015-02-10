using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PipedriveNet
{
	class ApiClient
	{
		private readonly string _apiKey;
	    private readonly ContractResolver _resolver;
	    internal readonly JsonSerializer Serializer = new JsonSerializer();

	    internal readonly HttpClient HttpClient = new HttpClient();
	    private const string ApiBase = "https://api.pipedrive.com/v1/";

		public ApiClient(string apiKey, ContractResolver resolver)
		{
			_apiKey = apiKey;
		    _resolver = resolver;
		    Serializer.ContractResolver = resolver;
		    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

	    public string ResolveProperty<T>(Expression<Func<T, object>> prop)
	    {
	        return _resolver.ResolveCustomName(prop.ExtractProperty());
	    }


	    Uri GetUri(string endpoint)
	    {
	        return new Uri(ApiBase + endpoint + "?api_token=" + _apiKey);
	    }

	    sealed class ResponseContainer<T>
	    {
	        public bool Success { get; set; }
            public string Error { get; set; }
            public T Data { get; set; }
	    }

	    async Task<T> Deserialize<T>(Task<HttpResponseMessage> resp)
	    {
	        using (var stream = await (await resp).Content.ReadAsStreamAsync())
	        {
	            var container = Serializer.Deserialize<ResponseContainer<T>>(new JsonTextReader(new StreamReader(stream)));
                if(!container.Success)
                    throw new PipedriveException(container.Error);
	            return container.Data;
	        }
	    }

	    public Task<T> Get<T>(string endpoint)
	    {
	        return Deserialize<T>(HttpClient.GetAsync(GetUri(endpoint)));
	    }

	    Task<T> Send<T>(string endpoint, HttpMethod method, object data)
	    {
	        var ms = new MemoryStream();
	        var jsonWriter = new JsonTextWriter(new StreamWriter(ms));
            Serializer.Serialize(jsonWriter, data);
            jsonWriter.Flush();
	        ms.Seek(0, SeekOrigin.Begin);

	        var message = new HttpRequestMessage(method, GetUri(endpoint));
	        if (data != null)
	            message.Content = new StreamContent(ms)
	            {
	                Headers = {ContentType = new MediaTypeHeaderValue("application/json") {CharSet = "utf-8"}}
	            };

	        return Deserialize<T>(HttpClient.SendAsync(message));
	    }


	    public Task Delete(string endpoint)
	    {
	        return Send<object>(endpoint, HttpMethod.Delete, null);
	    }

	    public Task<T> Post<T>(string endpoint, object data)
	    {
            return Send<T>(endpoint, HttpMethod.Post, data);

	    }
	}
}
