using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1.Shared.Entities
{
    public class Assignment
            {
                public int Id { get; set; }

                [Required(ErrorMessage = "El campo {0} es obligatorio")]
                [Display(Name = "ID de la sucursal a asignar")]
                public int branchID { get; set; }

                [Required(ErrorMessage = "El campo {0} es obligatorio")]
                [Display(Name = "ID del empleado a asignar")]
                public int employeeID { get; set; }

                [Required(ErrorMessage = "El campo {0} es obligatorio")]
                [Display(Name = "Fecha de inicio en DD/MM/AAAA")]
                [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
                public string startDate { get; set; } = null!;

                [Required(ErrorMessage = "El campo {0} es obligatorio")]
                [Display(Name = "Fecha de finalización en DD/MM/AAAA")]
                [MaxLength(10, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
                public string endDate { get; set; } = null!;
            }
        }