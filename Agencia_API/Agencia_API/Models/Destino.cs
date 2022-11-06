using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agencia_API.Models
{



    [Table("Destino")]
    public class Destino
    {
        [Key]
        public int DestinoId { get; set; }
        [Required(ErrorMessage = "Informe o ID do Destino")]
        [StringLength(50)]
        public string Pais { get; set; }
        [Required(ErrorMessage = "Informe o País")]
        public string Cidade { get; set; }

    }
}