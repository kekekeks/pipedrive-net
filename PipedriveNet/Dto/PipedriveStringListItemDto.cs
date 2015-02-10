namespace PipedriveNet.Dto
{
    public class PipedriveStringListItemDto
    {
        public bool Primary { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(PipedriveStringListItemDto item)
        {
            return item == null ? null : item.Value;
        }
    }
}