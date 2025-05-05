using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica4.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name ="Evento")]
        public string Title { get; set; } = string.Empty;

        [StringLength(255)]
        [Display(Name ="Descripcion")]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name ="Fecha de Inicio")]
        public DateTime StarDate { get; set; }

        [Required]
        [Display(Name ="Fecha de Fin")]
        public DateTime EndDate { get; set; }

        [Display(Name ="Estado")]
        [ForeignKey("EstadiId")]
        public int EstadoId { get; set; }

        public List<Estado>? Estado { get; set; }

        [Display(Name ="Creado en")]
        public DateTime? CreateAt { get; set; }

        [Display(Name ="Actualizado en")]
        public DateTime? UpdateAt { get; set; }



    }
}
