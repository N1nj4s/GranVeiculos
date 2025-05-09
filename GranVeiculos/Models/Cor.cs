using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranVeiculos.Models
{
    [Table("Cor")]
    public class Cor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nome { get; set; }
    }
}