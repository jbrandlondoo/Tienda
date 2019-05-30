USE BDDato

INSERT INTO categoria(nombreCategoria) VALUES('Fútbol');
INSERT INTO categoria(nombreCategoria) VALUES('bascketball');
INSERT INTO categoria(nombreCategoria) VALUES('Tenis campo');

INSERT INTO productos(nombreProducto,stock,precioActual,nombreProveedor,idCategoria,descuento) 
VALUES('Camisa Colombia',100,300000.00,'adidas',1,5);
INSERT INTO productos(nombreProducto,stock,precioActual,nombreProveedor,idCategoria,descuento) 
VALUES('balon',100,200000.00,'adidas',1,0);
INSERT INTO productos(nombreProducto,stock,precioActual,nombreProveedor,idCategoria,descuento) 
VALUES('balon',88,150000.00,'adidas',2,0);
INSERT INTO productos(nombreProducto,stock,precioActual,nombreProveedor,idCategoria,descuento) 
VALUES('Zapatos',50,400000.00,'nike',3,10);
INSERT INTO cliente(idCliente,nombreCliente,direccion,idCiudad) VALUES(1038,'juan brand','cra 92 # 69b-4',1)

