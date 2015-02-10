using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PipedriveNet;
using PipedriveNet.Dto;

namespace Sandbox
{
	class Program
	{
		static void Main(string[] args)
		{
		    var client = new PipedriveClient<CustomPerson, PipelineDto, StageDto, DealDto>(args[0]);
		    client.Configure<CustomPerson>().Field(p => p.CustomUserId, "44b58b24007b8a3ae247218ce0d0f7c475fc1514");

		    var firstStage = client.Stages.All.Result.First();

		    var person = client.Persons.Create("Test", "user@example.com", null,
		        new Dictionary<Expression<Func<CustomPerson, object>>, object>
		        {
		            {p => p.CustomUserId, 123321}
		        }).Result;

		    var deal = client.Deals.Create("Test", "100500", "RUB", person.Id, firstStage.Id).Result;

		    Console.ReadLine();
		}
	}
}
