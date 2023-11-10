using System.ComponentModel.DataAnnotations;

namespace LibraryProject.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
