namespace Ankethazirlama.Models
{
    public class Survey
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; } // Added 'required' modifier to fix CS8618  
        public List<Question> Questions { get; set; } = new(); // Ensure initialization to avoid null  
        public DateTime CreatedDate { get; set; }
    }
}
