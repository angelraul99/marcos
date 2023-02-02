create database pruebas
use pruebas
create table Usuario(
id int primary key not null,
nombre varchar(40) not null,
cotrasena varchar (40) not null


)

create table Productos(
id int primary key not null,
nombre_del_producto varchar(40),
descripcion_product varchar(40),
precio float (40)



)
create table Venta(
id_venta int primary key not null,
id int not null, 
detalle_venta varchar (60),
FOREIGN KEY (id ) REFERENCES Productos(id)
)