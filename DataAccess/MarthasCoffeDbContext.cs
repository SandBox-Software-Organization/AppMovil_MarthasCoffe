using MarthasCoffe.Modelos;
using MarthasCoffe.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthasCoffe.DataAccess
{
    public class MarthasCoffeDbContext : DbContext
    {

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDb = $"Filename={ConexionDB.DevolverRuta("MarthasCoffe.db")}";
            optionsBuilder.UseSqlite(conexionDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.IdCategoria).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(c => c.IdDireccion);
                entity.Property(c => c.IdDireccion).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(c => c.IdTarjeta);
                entity.Property(c => c.IdTarjeta).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Producto>(entity => {
                entity.HasKey(c => c.IdProducto);
                entity.Property(c => c.IdProducto).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefCategoria).WithMany(p => p.Productos)
                .HasForeignKey(p => p.IdCategoria);
            });

            modelBuilder.Entity<Compra>(entity => {
                entity.HasKey(c => c.IdCompra);
                entity.Property(c => c.IdCompra).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefDireccion).WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdDireccion);
                entity.HasOne(c => c.RefTarjeta).WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdTarjeta);
            });


            modelBuilder.Entity<DetalleCompra>(entity => {
                entity.HasKey(c => c.IdDetalleCompra);
                entity.Property(c => c.IdDetalleCompra).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefCompra).WithMany(p => p.RefDetalleCompra)
                .HasForeignKey(p => p.IdCompra);
                entity.HasOne(c => c.RefProducto).WithMany(p => p.RefDetalleCompra)
               .HasForeignKey(p => p.IdProducto);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(c => c.IdCarrito);
                entity.Property(c => c.IdCarrito).IsRequired().ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, Descripcion = "Bebidas" },
                new Categoria { IdCategoria = 2, Descripcion = "Platillos" },
                new Categoria { IdCategoria = 3, Descripcion = "Bocadillos" },
            new Categoria { IdCategoria = 4, Descripcion = "Postres" }
                );

            modelBuilder.Entity<Producto>().HasData(
            new Producto
            {
                IdProducto = 1,
                Nombre = "Horchata",
                Descripcion = "---",
                IdCategoria = 1,
                Precio = 2,
                Imagen = "horchata.png"
            },
           new Producto
           {
               IdProducto = 2,
               Nombre = "Limonada de Fresa",
               Descripcion = "---",
               IdCategoria = 1,
               Precio = 2,
               Imagen = "limonada.jpg"
           },
           new Producto
           {
               IdProducto = 3,
               Nombre = "mango",
               Descripcion = "---",
               IdCategoria = 1,
               Precio = 3,
               Imagen = "mango.png"
           },
           new Producto
           {
               IdProducto = 4,
               Nombre = "Jamaica",
               Descripcion = "-----",
               IdCategoria = 1,
               Precio = 3,
               Imagen = "jamaica.png"
           },
           new Producto
           {
               IdProducto = 5,
               Nombre = "Frape de fresa",
               Descripcion = "--",
               IdCategoria = 1,
               Precio = 2,
               Imagen = "frape.png"
           },
           new Producto
           {
               IdProducto = 6,
               Nombre = "Capuchino",
               Descripcion = "---",
               IdCategoria = 1,
               Precio = 2,
               Imagen = "calientesbebida1capuchino.png"
           },
           new Producto
           {
               IdProducto = 7,
               Nombre = "Moca",
               Descripcion = "---",
               IdCategoria = 1,
               Precio = 3,
               Imagen = "calientesbebida2moca.png"
           },
           new Producto
           {
               IdProducto = 8,
               Nombre = "Atol",
               Descripcion = "--",
               IdCategoria = 1,
               Precio = 4,
               Imagen = "calientesbebida3atol.png"
           },
           new Producto
           {
               IdProducto = 9,
               Nombre = "Sushi",
               Descripcion = "--",
               IdCategoria = 2,
               Precio = 2,
               Imagen = "sushi.png"
           },
           new Producto
           {
               IdProducto = 10,
               Nombre = "Rollitos de primavera",
               Descripcion = "Cantidad:10",
               IdCategoria = 2,
               Precio = 5,
               Imagen = "rollitos.png"
           },
           new Producto
           {
               IdProducto = 11,
               Nombre = "Carne",
               Descripcion = "---",
               IdCategoria = 2,
               Precio = 6,
               Imagen = "carne.png"
           },
            new Producto
            {
                IdProducto = 12,
                Nombre = "Bibimbap",
                Descripcion = "--",
                IdCategoria = 2,
                Precio = 2,
                Imagen = "bibimbap.png"
            },
           new Producto
           {
               IdProducto = 13,
               Nombre = "Ensalada",
               Descripcion = "--",
               IdCategoria = 2,
               Precio = 5,
               Imagen = "ensa.png"
           },
            new Producto
            {
                IdProducto = 14,
                Nombre = "Ensalada de pollo",
                Descripcion = "--",
                IdCategoria = 2,
                Precio = 2,
                Imagen = "ensaladapollo.png"
            },
           new Producto
           {
               IdProducto = 15,
               Nombre = "Crema de brocoli",
               Descripcion = "---",
               IdCategoria = 2,
               Precio = 5,
               Imagen = "crema.png"
           },
           new Producto
           {
               IdProducto = 16,
               Nombre = "Alfajores",
               Descripcion = "--",
               IdCategoria = 4,
               Precio = 2,
               Imagen = "alfajores.png"
           },
           new Producto
           {
               IdProducto = 17,
               Nombre = "Mochis",
               Descripcion = "10 mochis con relleno de fresa y chocolate",
               IdCategoria = 4,
               Precio = 8,
               Imagen = "mochi.png"
           },
            new Producto
            {
                IdProducto = 18,
                Nombre = "Pai de Manzana",
                Descripcion = "para 18 personas",
                IdCategoria = 4,
                Precio = 8,
                Imagen = "pai.png"
            },
            new Producto
            {
                IdProducto = 19,
                Nombre = "Pastel de Helado",
                Descripcion ="",
                IdCategoria = 4,
                Precio = 2,
                Imagen = "pastel.png"
            },
           new Producto
           {
               IdProducto = 20,
               Nombre = "Sandwich de Helado",
               Descripcion = "",
               IdCategoria = 4,
               Precio = 5,
               Imagen = "sandwich.png"
           },
            new Producto
            {
                IdProducto = 21,
                Nombre = "Galletas",
                Descripcion = "--",
                IdCategoria = 3,
                Precio = 2,
                Imagen = "galletas.png"
            },
            new Producto
            {
                IdProducto = 22,
                Nombre = "Kiwi",
                Descripcion = "6",
                IdCategoria = 3,
                Precio = 2,
                Imagen = "kiwi.png"
            },
            new Producto
            {
                IdProducto = 23,
                Nombre = "Arroz con leche",
                Descripcion = "--",
                IdCategoria = 4,
                Precio = 2,
                Imagen = "arle.png"
            },
            new Producto
            {
                IdProducto = 24,
                Nombre = "Dulces de Coco",
                Descripcion = "",
                IdCategoria = 3,
                Precio = 2,
                Imagen = "coco.png"
            },
            new Producto
            {
                IdProducto = 25,
                Nombre = "Chocolate",
                Descripcion = "",
                IdCategoria = 3,
                Precio = 2,
                Imagen = "chocolat.png"
            },
            new Producto
            {
                IdProducto = 26,
                Nombre = "Gomitas",
                Descripcion = "20",
                IdCategoria = 3,
                Precio = 5,
                Imagen = "gomitas.png"
            },
            new Producto
            {
                IdProducto = 27,
                Nombre = "Pastel de Chocolate",
                Descripcion = "Para 20 personas",
                IdCategoria = 4,
                Precio = 15,
                Imagen = "choco.png"
            },
            new Producto
            {
                IdProducto = 28,
                Nombre = "Deditos de Quseo",
                Descripcion = "10",
                IdCategoria = 3,
                Precio = 4,
                Imagen = "deditos.png"
            },
            new Producto
            {
                IdProducto = 29,
                Nombre = "Pastel dulce",
                Descripcion = "Patel de dulce de leche, para 30 personas",
                IdCategoria = 4,
                Precio = 18,
                Imagen = "dulcemilk.png"
            },
            new Producto
            {
                IdProducto = 30,
                Nombre = "Mango",
                Descripcion = "--",
                IdCategoria = 3,
                Precio = 3,
                Imagen = "mangoverd.png"
            },
            new Producto
            {
                IdProducto = 31,
                Nombre = "Mani",
                Descripcion = "",
                IdCategoria = 3,
                Precio = 2,
                Imagen = "mani.png"
            },
            new Producto
            {
                IdProducto = 32,
                Nombre = "Pan",
                Descripcion = "--",
                IdCategoria = 3,
                Precio = 2,
                Imagen = "pan.png"
            },
            new Producto
            {
                IdProducto = 33,
                Nombre = "Ensalada",
                Descripcion = "",
                IdCategoria = 3,
                Precio = 5,
                Imagen = "sasa.png"
            },
            new Producto
            {
                IdProducto = 34,
                Nombre = "Pastel de fresa",
                Descripcion = "Pastel de fresa y vainilla, para 15 personas",
                IdCategoria = 4,
                Precio = 9,
                Imagen = "titi.png"
            }

               );
        }
    }
}
