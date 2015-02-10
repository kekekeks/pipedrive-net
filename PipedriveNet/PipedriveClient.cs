using System;
using System.Linq.Expressions;
using PipedriveNet.Dto;
using PipedriveNet.Endpoints;

namespace PipedriveNet
{

	public class PipedriveClient : PipedriveClient<PersonDto>
	{
		public PipedriveClient(string apiKey) : base(apiKey)
		{
		}
	}

    public class PipedriveClient<TPerson> where TPerson : PersonDto
    {
		private readonly ContractResolver _resolver = new ContractResolver();

		public PersonsEndpoint<TPerson> Persons { get; private set; }

	    public PipedriveClient(string apiKey)
	    {
		    var client = new ApiClient(apiKey, _resolver);
		    Persons = new PersonsEndpoint<TPerson>(client);
	    }

        public class CustomFieldConfigurator<T>
        {
            private readonly ContractResolver _resolver;

            internal CustomFieldConfigurator(ContractResolver resolver)
            {
                _resolver = resolver;
            }

            public CustomFieldConfigurator<T> Field<TField>(Expression<Func<T, TField>> field, string key)
            {
                _resolver.Register(field.ExtractProperty(), key);
                return this;
            }
        }

        public CustomFieldConfigurator<T> Configure<T>()
        {
            return new CustomFieldConfigurator<T>(_resolver);
        }
    }
}
