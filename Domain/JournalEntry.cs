namespace Domain
{
    public class JournalEntry
    {
        public DateTime Date { get; set; }

        public int Minutes { get; set; }

        public string? Summary { get; set; }

        public int Id { get; set; }
    }
}