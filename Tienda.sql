
USE [BDDato]
dbo.telefono/**CREATE TABLE ciudad(id INT PRIMARY KEY IDENTITY (1, 1),name VARCHAR(50) NOT NULL);**/
CREATE TABLE cliente(idCliente INT PRIMARY KEY NOT NULL,nombreCliente VARCHAR(5) NOT NULL, direccion VARCHAR(50) NOT NULL, idCiudad int FOREIGN KEY REFERENCES ciudad(id) NOT NULL);
CREATE TABLE categoria(idCategoria INT PRIMARY KEY IDENTITY(1,1), nombreCategoria VARCHAR(50) NOT NULL, descripcion VARCHAR);
CREATE TABLE productos(idProductos INT PRIMARY KEY IDENTITY(1,1), nombreProducto VARCHAR(50) NOT NULL,stock INT NOT NULL,precioActual FLOAT NOT NULL,nombreProveedor VARCHAR(50),idCategoria int FOREIGN KEY REFERENCES categoria(idCategoria));
CREATE TABLE factura(idFactura INT primary key IDENTITY(1,1), total FLOAT NOT NULL, fecha DATETIME NOT NULL, idCliente int FOREIGN KEY REFERENCES cliente(idCliente));
CREATE TABLE detalleFactura(descuento FLOAT NOT NULL,cantidad INT NOT NULL, idFactura INT FOREIGN KEY REFERENCES dbo.factura(idFactura),idProducto INT FOREIGN KEY REFERENCES dbo.productos(idProductos), PRIMARY KEY (idFactura, idProducto));
CREATE TABLE telefono(idCliente INT FOREIGN KEY REFERENCES dbo.cliente(idCliente), numero VARCHAR(20) PRIMARY KEYdbo.telefono NOT NULL);
