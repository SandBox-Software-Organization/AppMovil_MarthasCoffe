using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.Modelos
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria RefCategoria { get; set; }
        public virtual ICollection<DetalleCompra> RefDetalleCompra { get; set; } = new List<DetalleCompra>();
    }
}
