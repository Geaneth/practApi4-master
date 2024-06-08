using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using practApi4.Models;

namespace practApi4.Service
{
    public class Productos
    {
        public List<Producto> getTrendingProductos() {
            List<Producto> result = new List<Producto>
            {
        new Producto { ProductoId = 3, ProductoNombre = "Smartphone Tendencia 1 (2024)" },
        new Producto { ProductoId = 7, ProductoNombre = "Tablet Tendencia 7 (2025)" },
        new Producto { ProductoId = 6, ProductoNombre = "Laptop Tendencia 6 (2023)" },
    };

            return result;
        }
        public List<Producto> getAllProductos() {
            List<Producto> result = new List<Producto>
            {
        new Producto { ProductoId = 1, ProductoNombre = "Smartphone Clásico 1 (2022)" },
        new Producto { ProductoId = 2, ProductoNombre = "Tablet Clásico 2 (2021)" },
        new Producto { ProductoId = 3, ProductoNombre = "Laptop Clásica 3 (2020)" },
        new Producto { ProductoId = 4, ProductoNombre = "Smartwatch Clásico 4 (2019)" },
        new Producto { ProductoId = 5, ProductoNombre = "Headset Clásico 5 (2018)" },
        new Producto { ProductoId = 6, ProductoNombre = "Laptop Tendencia 6 (2023)" },
        new Producto { ProductoId = 7, ProductoNombre = "Tablet Tendencia 7 (2025)" },
        new Producto { ProductoId = 8, ProductoNombre = "Smartphone Tendencia 8 (2024)" },
        new Producto { ProductoId = 9, ProductoNombre = "Gafas Inteligentes 9 (2023)" },
        new Producto { ProductoId = 10, ProductoNombre = "Robot Doméstico 10 (2022)" }
    };

            return result;
        }


    }
}