using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Shared.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nombre del producto")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string name { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Descripción del producto")]
        [MaxLength(300, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string description { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Precio")]
        public int price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Talla")]
        [MaxLength(5, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        public string size { get; set; } = null!;

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Cantidad en existencia")]
        public int stockQuantity { get; set; }
        public ICollection<PurchaseDetail>? PurchaseDetails { get; set; }
        public ICollection<SalesDetail>? SalesDetails { get; set; }
    }
}