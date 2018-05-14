namespace PipedriveNet.Dto
{
    public class OrganizationDto
    {
        public int OrganizationId { get; set; }

        public string Name { get; set; }

        public int PeopleCount { get; set; }

        public string CCEmail { get; set; }

        public int Value { set { OrganizationId = value; } }
    }
}
