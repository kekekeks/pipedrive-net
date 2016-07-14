using System;
using System.Linq.Expressions;
using PipedriveNet.Dto;
using PipedriveNet.Endpoints;

namespace PipedriveNet
{

	public class PipedriveClient : PipedriveClient<PersonDto, PipelineDto, StageDto, DealDto, UserDto, PersonFindDto, FileDto, OrganizationDto>
    {
		public PipedriveClient(string apiKey) : base(apiKey)
		{
		}
	}

    public class PipedriveClient<TPerson, TPipeline, TStage, TDeal, TUser, TPersonFind, TFile, TOrganization> 
        where TPerson : PersonDto
        where TPersonFind : PersonFindDto
        where TPipeline : PipelineDto
        where TStage : StageDto
        where TDeal : DealDto
        where TUser : UserDto
        where TFile : FileDto
        where TOrganization: OrganizationDto
    {
		private readonly ContractResolver _resolver = new ContractResolver();

		public PersonsEndpoint<TPerson> Persons { get; private set; }

        public PersonsFindEndpoint<TPersonFind> PersonsFind { get; private set; }
        public PipelinesEndpoint<TPipeline> Pipelines { get; private set; }
        public StagesEndpoint<TStage> Stages { get; private set; }
        public DealsEndpoint<TDeal> Deals { get; private set; }
        public ActivitesEndpoint Activites { get; private set; }
        public NotesEndpoint Notes { get; private set; }
        public UsersEndpoint<TUser> Users { get; private set; }
        public FilesEndpoint<TFile> Files { get; private set; }

        public OrganizationsEndpoint<TOrganization> Organizations { get; private set; }

        public PipedriveClient(string apiKey)
	    {
	        if (apiKey == null) throw new ArgumentNullException("apiKey");
	        var client = new ApiClient(apiKey, _resolver);
		    Persons = new PersonsEndpoint<TPerson>(client);
            PersonsFind = new PersonsFindEndpoint<TPersonFind>(client);
            Pipelines = new PipelinesEndpoint<TPipeline>(client);
            Stages = new StagesEndpoint<TStage>(client);
	        Deals = new DealsEndpoint<TDeal>(client);
            Activites = new ActivitesEndpoint(client);
	        Notes = new NotesEndpoint(client);
            Users = new UsersEndpoint<TUser>(client);
            Files = new FilesEndpoint<TFile>(client);
            Organizations = new OrganizationsEndpoint<TOrganization>(client);
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
                if (field == null) throw new ArgumentNullException("field");
                if (key == null) throw new ArgumentNullException("key");

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
