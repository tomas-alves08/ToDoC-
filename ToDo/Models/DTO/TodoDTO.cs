using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.DTO
{
    public class TodoDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Item { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateComplete { get; set; }
    }
}
