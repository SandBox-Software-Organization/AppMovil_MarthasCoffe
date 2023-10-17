using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.Modelos
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}
