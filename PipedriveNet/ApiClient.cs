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
using Newtonsoft.Json.Converters;
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
		    Serializer.Converters.Add(new StringEnumConverter {CamelCaseText = true});
		    HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

	    public string ResolveProperty<T>(Expression<Func<T, object>> prop)
	    {
	        return _resolver.ResolveCustomName(prop.ExtractProperty());
	    }


	    Uri GetUri(string endpoint)
	    {
	        return new Uri(ApiBase + endpoint + (endpoint.Contains("?") ? "&" : "?") + "api_token=" + _apiKey);
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
                if (!container.Success)
                    throw new PipedriveException(container.Error);

                //Replace null by empty list
                if (container.Data == null && typeof(T).IsGenericType &&
                    typeof(T).GetGenericTypeDefinition() == typeof(List<>))
                    container.Data = Activator.CreateInstance<T>();

                return container.Data;
            }
	    }
        async Task<T> DeserializeTest<T>(Task<HttpResponseMessage> resp)
        {
            using (var stream = await (await resp).Content.ReadAsStreamAsync())
            {

                Char[] buffer;
                using (var sr = new StreamReader(stream))
                {
                    buffer = new Char[(int)sr.BaseStream.Length];
                    await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
                }
                String response = new string(buffer);


                var container = Serializer.Deserialize<ResponseContainer<T>>(new JsonTextReader(new StreamReader(stream)));
                if (!container.Success)
                    throw new PipedriveException(container.Error);

                //Replace null by empty list
                if (container.Data == null && typeof(T).IsGenericType &&
                    typeof(T).GetGenericTypeDefinition() == typeof(List<>))
                    container.Data = Activator.CreateInstance<T>();

                return container.Data;
            }
        }


        public Task<T> Get<T>(string endpoint)
	    {
	        return Deserialize<T>(HttpClient.GetAsync(GetUri(endpoint)));
	    }

	    Task<T> Send<T>(string endpoint, HttpMethod method, object data)
	    {
            try {
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

                Task<HttpResponseMessage> returnValue = HttpClient.SendAsync(message);
            
                return Deserialize<T>(returnValue);
            }
            catch (System.Exception e)
            {
                string errMsg = e.Message;
                return null;

            }
        }

        Task<T> SendMultipart<T>(string endpoint, HttpMethod method, MultipartFormDataContent form)
        {
            try
            {
                HttpClient httpClient = new HttpClient();
            var message = new HttpRequestMessage(method, GetUri(endpoint));

            Task<HttpResponseMessage> returnValue = HttpClient.PostAsync(message.RequestUri, form);

             Task<T> thisResponse = DeserializeTest<T>(returnValue);

             return thisResponse;

            httpClient.Dispose();
            }
            catch (System.Exception e)
            {
                string errMsg = e.Message;
                return null;

            }
        }

        public Task Delete(string endpoint)
	    {
	        return Send<object>(endpoint, HttpMethod.Delete, null);
	    }

	    public Task<T> Post<T>(string endpoint, object data)
	    {
            return Send<T>(endpoint, HttpMethod.Post, data);

	    }

        public Task<T> PostMultipart<T>(string endpoint, MultipartFormDataContent data)
        {
            return SendMultipart<T>(endpoint, HttpMethod.Post, data);

        }

        public Task<T> Put<T>(string endpoint, object data)
	    {
            return Send<T>(endpoint, HttpMethod.Put, data);
	    }
	}
}
