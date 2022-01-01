namespace OnlineQuizApi.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string CorrAns { get; set; }
        public int CategoryId { get; set; }
        public Categories category { get; set; }
    }
}
