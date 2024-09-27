using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Shared.Entities
{
    public class PurchaseDetail
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ID de la compra")]
        public int purchaseID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "ID del producto")]
        public int productID { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Cantidad del producto comprado")]
        public int quantity { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Precio unitario")]
        public int unitPrice { get; set; }
        public Product? Product { get; set; }
        public Purchase? Purchase { get; set; }
    }
}