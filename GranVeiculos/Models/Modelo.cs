using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Intrinsics.X86;

namespace GranVeiculos.Models
{
    [Table("Modelo")]
    public class Modelo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nome { get; set; }

        [Required]
        public int MarcaId { get; set; }
        [ForeignKey("MarcaId")]
        public Marca Marca { get; set; }
    }
}