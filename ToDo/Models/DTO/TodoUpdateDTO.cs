using System.ComponentModel.DataAnnotations;

namespace ToDo.Models.DTO
{
    public class TodoUpdateDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Item { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
    }
}
