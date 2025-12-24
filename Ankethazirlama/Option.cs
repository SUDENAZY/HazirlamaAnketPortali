namespace Ankethazirlama.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty; // Varsayılan değer atandı  
        public int QuestionId { get; set; }  // Hangi soruya bağlı  
        public required Question Question { get; set; } // 'required' eklenerek null atanamazlık sağlandı  
    }
}
