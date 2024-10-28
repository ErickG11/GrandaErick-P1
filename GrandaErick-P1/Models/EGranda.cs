using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrandaErick_P1.Models
{
    public class EGranda
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(15)]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public bool Ecuatoriano { get; set; }
        public float Peso { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        public Celular? Celular { get; set; }

        [ForeignKey("Celular")]
        public int IDCelular { get; set; }
    }
}
