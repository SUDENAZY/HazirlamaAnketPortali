namespace Ankethazirlama.Models
{
    public class Question
    {
        private string text = string.Empty;
        private List<Option> options = new();
        private Survey survey = new() { Title = string.Empty, Description = string.Empty }; // Fix: Initialize required property 'Description'  

        public int Id { get; set; }
        public string Text { get => text; set => text = value; }
        public int SurveyId { get; set; }  // Hangi ankete bağlı      
        public Survey Survey { get => survey; set => survey = value; }
        public List<Option> Options { get => options; set => options = value; }
    }
}