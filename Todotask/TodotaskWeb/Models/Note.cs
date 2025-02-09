using System.ComponentModel.DataAnnotations;

namespace TodotaskWeb.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? UserId { get; set; }
        public User? User { get; set; }
    }
}
