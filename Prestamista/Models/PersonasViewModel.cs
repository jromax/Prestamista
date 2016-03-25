using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
namespace Prestamista.Models
{
    [Table("prestarbd.Personas")]
    public class PersonasViewModel
    {
        public int Id { get; set; }
        public Nullable<int> tipoDocumento { get; set; }
        public string numDocumento { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public Nullable<int> genero { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string observaciones { get; set; }
    }
}