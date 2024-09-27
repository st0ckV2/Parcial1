using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Shared.Entities
{
    public class Purchase
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ID del proveedor")]
        public int suplierID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha de la compra en DD/MM/AAAA")]
        public string date { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Monto total")]
        public int totalAmount { get; set; }
        public Suplier? Suplier { get; set; }
        public ICollection<PurchaseDetail>? PurchaseDetails { get; set; }
    }
}