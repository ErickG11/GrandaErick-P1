using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandaErick_P1.Models
{
    public class Celular
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Modelo")]
        public string Modelo { get; set; }
        public int Año { get; set; }
        public float Precio { get; set; }


    }
}