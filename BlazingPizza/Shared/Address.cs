using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazingPizza.Shared {
    public class Address {

        public int Id { get; set; }

        [Required(ErrorMessage ="¿Quién resibirá la orden?"), MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Especifique la direccion de envio."), MaxLength(100)]
        public string Line1 { get; set; }

        [MaxLength(100, ErrorMessage = "La longitud maxima son 100 caracteres.")]
        public string Line2 { get; set; }

        [Required(ErrorMessage = "Especifique la ciudad."), MaxLength(50)]
        public string City { get; set; }

        [Required(ErrorMessage = "Especifique la region."), MaxLength(20)]
        public string Region { get; set; }

        [Required(ErrorMessage = "Especifique el codigo postal."), MaxLength(20)]
        public string PostalCode { get; set; }

    }
}
