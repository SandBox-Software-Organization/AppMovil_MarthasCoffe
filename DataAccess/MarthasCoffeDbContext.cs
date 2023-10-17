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
                new Categoria { IdCategoria = 1, Descripcion = "jjjj", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 2, Descripcion = "nnnnn", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 3, Descripcion = "vhbjb", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 4, Descripcion = "vhvkj", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 5, Descripcion = "gvbhvh", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 6, Descripcion = "vggjvhbk", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 7, Descripcion = "bbbbb", Imagen = "cup.jpg" },
                new Categoria { IdCategoria = 8, Descripcion = "bjbubb", Imagen = "cup.jpg" }
                );

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    IdProducto = 1,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 1,
                    Precio = 2000,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 2,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 1,
                    Precio = 2500,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 1,
                    Precio = 3000,
                    Imagen = "prod3.jpg"
                },
                new Producto
                {
                    IdProducto = 4,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 1,
                    Precio = 3200,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 5,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 1,
                    Precio = 1560,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 6,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 2,
                    Precio = 500,
                    Imagen = "prod6.jpg"
                },
                new Producto
                {
                    IdProducto = 7,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 2,
                    Precio = 400,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 8,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 3,
                    Precio = 500,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 9,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 3,
                    Precio = 200,
                    Imagen = "prod9.jpg"
                },
                new Producto
                {
                    IdProducto = 10,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 3,
                    Precio = 450,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 11,
                    Nombre = "sdfsfcds",
                    Descripcion = "jsjsjs\r\nxxxxxD\r\njsjjsjsjsj\r\nssnsjssj\r\njsjsjsjsjjsjsjs",
                    IdCategoria = 3,
                    Precio = 2120,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 12,
                    Nombre = "sdfsfcds",
                    Descripcion = "NINGUNO",
                    IdCategoria = 4,
                    Precio = 220,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 13,
                    Nombre = "sdfsfcds",
                    Descripcion = "NINGUNO",
                    IdCategoria = 4,
                    Precio = 890,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 14,
                    Nombre = "sdfsfcds",
                    Descripcion = "TALLA: 4\r\nTALLA:4.5",
                    IdCategoria = 5,
                    Precio = 260,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 15,
                    Nombre = "jsjsjnjj",
                    Descripcion = "TALLA: 4\r\nTALLA:4.5",
                    IdCategoria = 5,
                    Precio = 230,
                    Imagen = "cup.jpg"
                },
                new Producto
                {
                    IdProducto = 16,
                    Nombre = "jsjsjnjj",
                    Descripcion = "NINGUNO",
                    IdCategoria = 6,
                    Precio = 300,
                    Imagen = "prod16.jpg"
                },
                new Producto
                {
                    IdProducto = 17,
                    Nombre = "mkmkmkmk",
                    Descripcion = "NINGUNO",
                    IdCategoria = 6,
                    Precio = 87,
                    Imagen = "cup.jpg"
                },
                 new Producto
                 {
                     IdProducto = 18,
                     Nombre = "njjnj",
                     Descripcion = "COLOR: NARANJA",
                     IdCategoria = 7,
                     Precio = 90,
                     Imagen = "cup.jpg"
                 },
                  new Producto
                  {
                      IdProducto = 19,
                      Nombre = "njjj",
                      Descripcion = "NINGUNO",
                      IdCategoria = 7,
                      Precio = 130,
                      Imagen = "cup.jpg"
                  },
                  new Producto
                  {
                      IdProducto = 20,
                      Nombre = "njjnjnjnjnj",
                      Descripcion = "NINGUNO",
                      IdCategoria = 7,
                      Precio = 110,
                      Imagen = "cup.jpg"
                  }
                );
        }
    }
}
