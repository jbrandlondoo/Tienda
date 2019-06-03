using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN = tienda.entidad;
using BR = tienda.broker;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace tienda.controlador
{
    public class Producto
    {
        private BR.BDDatoEntities db = new BR.BDDatoEntities();
       
        //protected static IMongoClient client = new MongoClient("mongodb+srv://userdb:Password123@cluster0-laupy.mongodb.net/test?retryWrites=true&w=majority");
        protected static IMongoClient client = new MongoClient("mongodb://userdb:Password123@mycluster0-shard-00-00.mongodb.net:27017,mycluster0-shard-00-01.mongodb.net:27017,mycluster0-shard-00-02.mongodb.net:27017/admin?ssl=true&replicaSet=Mycluster0-shard-0&authSource=admin");
        protected static IMongoDatabase database = client.GetDatabase("DB_Comentarios");
        public List<EN.Producto> listProductos(){
            List<EN.Producto> productos = new List<EN.Producto>();
            try
            {
                var consulta = (from p in db.productos
                                join ca in db.categorias on p.idCategoria equals ca.idCategoria
                                orderby p.nombreProducto descending
                                select new {p.nombreProducto,p.idProductos,p.precioActual,p.stock,p.descuento,ca.nombreCategoria });

                foreach (var item in consulta)
                {
                    EN.Producto producto = new EN.Producto();
                    producto.categoria = item.nombreCategoria;
                    producto.nombre = item.nombreProducto;
                    producto.precioActual = item.precioActual;
                    producto.descuento = item.descuento;
                    producto.id = item.idProductos;
                    producto.stock = item.stock;
                    if(producto.stock > 0)
                        productos.Add(producto);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return productos;
        }

        public EN.Producto listProductos(int id)
        {
            EN.Producto producto = new EN.Producto();
            try
            {
                var consulta = (from p in db.productos
                                join ca in db.categorias on p.idCategoria equals ca.idCategoria
                                where p.idProductos == id
                                orderby p.nombreProducto descending
                                select new { p.nombreProducto, p.idProductos, p.precioActual, p.stock, p.descuento, ca.nombreCategoria });

                foreach (var item in consulta)
                {
                    producto.categoria = item.nombreCategoria;
                    producto.nombre = item.nombreProducto;
                    producto.precioActual = item.precioActual;
                    producto.descuento = item.descuento;
                    producto.id = item.idProductos;
                    producto.stock = item.stock;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        public bool updateProducto(EN.Producto producto) {
            try
            {
                var oldProducto = db.productos.Find(producto.id);
                BR.producto productonew = oldProducto;
                productonew.stock = oldProducto.stock - producto.cantidad;
                db.Entry(oldProducto).CurrentValues.SetValues(productonew);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }

        public bool comProductAsync(String comment,int idProducto,int idCliente)
        {
                var collection = database.GetCollection<BsonDocument>("Comentarios");

                BsonDocument document = new BsonDocument
                {
                    {"producto",idProducto },
                    {"cliente",idCliente },
                    {"comentario" , comment}
                };

                collection.InsertOne(document);

                return true;
            //}catch(Exception e)
            //{
            //    return false;
            //}
            

        }
    }

}
