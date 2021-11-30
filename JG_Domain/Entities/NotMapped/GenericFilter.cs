namespace JG_Domain.Entities.NotMapped
{
    public class GenericFilter
    {
        public long Id { get; set; }
        public string Query { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public string SortExpression { get; set; }
        public string Orientation { get; set; }
    }
}
