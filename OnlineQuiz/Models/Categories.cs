using System.ComponentModel.DataAnnotations;

namespace OnlineQuizApi.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public string Title { get; set; }
    }
}
