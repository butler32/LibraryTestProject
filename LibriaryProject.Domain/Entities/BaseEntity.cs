using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
