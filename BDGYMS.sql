create database GYMS
go
USE GymDatabase
create table RegistrarCliente
(
	Id int IDENTITY(1,1) not null primary key,
	Nombre varchar(50) not null,
	Direccion varchar(500) not null,
	Telefono varchar(20) not null,
	Correo VARCHAR(50) NOT NULL,
	Contraseña VARCHAR(50) NOT NULL,
	Verificador UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
	Verificado CHAR(1) NOT NULL
	--tiposuscripcion varchar(100) not null,
	--fechapago date not null,
	--pago decimal(12,2) not null
	--Aquí se crearía la cuenta el cliente, tendría su Usuario y Contraseña

-- tu crees que seria bueno agregar esos campos??
-- Si, lo que pasa que si estan aquí mira
)
GO
CREATE TABLE DetalleCliente
(
	--Aquí una vez que se haiga comprado la suscripción, si el cliente gusta tomarse las medidas se le toman, si no me imagina que se dejaría en blanco sii seria como extra si como un extra que se le ofreciera opcionalmente sii
	Id INT NOT NULL IDENTITY,
	IdUsuario INT NOT NULL,
	FechaMedida DATE NOT NULL,
	FechaNacimiento DATE NOT NULL,
	Edad VARCHAR(10) not null,
	Peso varchar(20) not null,
	MedidaCuello varchar(15) not null,
	MedidaHombro varchar(15) not null,
	MedidaPecho varchar(15) not null,
	MedidaCintura varchar(15) not null,
	MedidaAntebrazo varchar(15) not null,
	MedidaMuslo varchar(15) not null,
	MedidaPantorrilla varchar(15) not null,
	MedidaBiceps varchar(15) not null,
	MedidaCadera varchar(15) not null,
	PRIMARY KEY(IdUsuario,FechaMedida),
	foreign key (IdUsuario) references RegistrarCliente(Id)
)
GO
CREATE TABLE TipoSucripcion
(
	--Aquí se registran los tipos de suscripciones que van a existir, por ejemplo,
	--Id: 1, Nombre: Bronce(3 meses), Tiempo: 3 meses
	Id INT NOT NULL PRIMARY KEY,--aqui sera el tipo de membresia si es dorada plata o bronce mes etc
    Nombre VARCHAR(50) NOT NULL,--aqui sera el nombre traido de la tabla registrar cliente
	Tiempo VARCHAR(20) not null,--Aquí creo que tal vez se podría poner el tiempo que se pueda calcular, a lo mejor puede ser otro tipo de dato como DateTime si, para el tiempo poder calcular el restante y que aparezca en la página al cliente cuanto le resta de dias
	Precio DECIMAL(12,12) NOT NULL --Aquí el precio de cada uno
)
GO
CREATE TABLE Asistencia
(
	
	Id INT NOT NULL IDENTITY,
	IdUsuario INT NOT NULL,
	Fecha DATETIME NOT NULL,
	DescripcionDeRutina VARCHAR(100) NOT NULL,--Como se le podria llamar a ese campo podria ser descripcionderutina Okok
	PRIMARY KEY(IdUsuario,Fecha),
	FOREIGN KEY (IdUsuario) REFERENCES RegistrarCliente(Id)
)
go
CREATE TABLE Compra
(
	--Aquí la compra, yo creo que podriamos poner la fecha tambien cuando la compro, de esta tabla me imagino que se podria calcular el restante de acuerdo a la suscripcion que tenga, los dias que tiene la suscripcion  sii, para calcular el restante Jeje
	Id INT NOT NULL IDENTITY,
	IdUsuario INT NOT NULL FOREIGN KEY REFERENCES RegistrarCliente(Id),
	IdTipoSuscripcion INT NOT NULL FOREIGN KEY REFERENCES TipoSucripcion(Id),
	FechaCompra DATETIME NOT NULL,
	PRIMARY KEY(IdUsuario)
	--El tiempo restante yo creo que no se registraria si no que seria como una consulta que arrojara lo que le queda y si tiene 0 dias que manda un mensaje que se termino la suscripcion,
	--siii Jeje
	--Por ejemplo, 
	--enttonces seria si esta dado de alta puede comprar??
)
go
INSERT INTO Compra (IdUsuario,IdTipoSuscripcion, FechaCompra) VALUES(1, 2, SYSDATETIME())
INSERT INTO Compra (IdUsuario,IdTipoSuscripcion, FechaCompra) VALUES(4, 1, SYSDATETIME())
INSERT INTO Compra (IdUsuario,IdTipoSuscripcion, FechaCompra) VALUES(5, 3, SYSDATETIME())
INSERT INTO Compra (IdUsuario,IdTipoSuscripcion, FechaCompra) VALUES(6, 4, SYSDATETIME())

SELECT RegistrarCliente.Id, RegistrarCliente.Nombre,  TipoSucripcion.Nombre AS [TipoSuscripcion], TipoSucripcion.Tiempo FROM Compra 
INNER JOIN RegistrarCliente ON RegistrarCliente.Id=Compra.IdUsuario
INNER JOIN TipoSucripcion ON TipoSucripcion.Id=Compra.IdTipoSuscripcion

--Se le podria calcular el restante tal vez con la fecha que inicia a ir al gym y con el plan que compro sii pero eso seria desde que lo compra seria , no se si se contara desde a partir del dia en que paga en adelante o desde el primer dia que va, por si alguien fuera y pagara y dijera que empezaria el lunes no se, o decirle que pague cuando valla a empezar podria ser cuando valla empezar digamos en la asistencia que le muestre ya el conteo pago un mes pone su usuario contraseña para entrar al gym o huella y que le muestre el mensaje 30 dias 23:59:59
--Si se calcularia yo creo con la fecha de compra y el tiempo que dura la suscripcion y ese numero que resta se le mostrara en la pantalla siii

CREATE TABLE Rutinas
(
	--Estas serian las rutinas que estarian disponibles, que se pudieran ver en la pagina web verdad?
	--sii son las que mostraria al consultar 
	--OkOk Jeje
	Dia1 varchar(50) not null,--Pectoral + abdominales
	Imagen1 varchar(max) not null,
	Dia2 varchar(50) not null,--Espalda
	Imagen2 varchar(max) not null,
	Dia3 varchar(50) not null,--Hombros + abdominales
	Imagen3 varchar(max) not null,
	Dia4 varchar(50) not null,--Piernas
	Imagen4 varchar(max) not null,
	Dia5 varchar(50) not null,--Brazos + abdominales
	Imagen5 varchar(max) not null,
	Dia6 varchar(50) not null,--Biceps + Triceps
	Imagen6 varchar(max) not null,
	Dia7 varchar(50) not null, --Espalda + Piernas
	Imagen7 varchar(max) not null
	
)
go

--======================================================================
ALTER procedure spGuardarCliente
@op int,
@Id int=0,
@IdNombre varchar(100)='',
@Nombre varchar (50)='',
@Direccion varchar (500)='',
@Telefono varchar (20)='',
@Correo varchar (50)='',
@Contraseña varchar (50)='' 

as
begin 
  if @op=1 --Obtener datos de Estados
	begin
		 --select * from RegistrarCliente where Id=@Id;
			select * from RegistrarCliente where(convert(varchar(20),Id)+Nombre) 
			like '%'+@IdNombre+'%' collate Latin1_General_CI_AI order by Id
			
end
  if @Op=2 --Agregar  
begin
  if not exists(select Id from RegistrarCliente where Id=@Id)
		 begin
						--declare @MaxId int select @MaxId=isnull(max(Id+1),1) From RegistrarCliente
                      insert into RegistrarCliente(Nombre, Direccion, Telefono, Correo, Contraseña) 
					  values (@Nombre, @Direccion, @Telefono, @Correo, @Contraseña)
		 end
end


   if @Op=3 --Eliminar 
 begin
      delete from RegistrarCliente where Id=@Id
   end
   --Intenta calarlo si gustas haber si funciona ok no esta hecho
   if @Op=4 --cargar
   begin
      Select * from RegistrarCliente where Id=@Id
   end

   if @Op=5 --pasar al siguiente cliente
    begin
      Select isnull(max(Id+1),1) from RegistrarCliente 
    end

  end

   if @Op=6 --modificar
   begin
if exists(select * from RegistrarCliente where Id=@Id)
begin
update RegistrarCliente set Nombre=@Nombre, Direccion=@Direccion,Telefono=@Telefono,Correo=@Correo, Contraseña=@Contraseña
where Id=@Id
end
end
 

 --resgistrar clinete despues tipo de subcripcion despues compra despues asistencia despues detalle cliente


 --UNIONS DE TABLA mañana tiramos me dormire te aparare todo aqui  erick te dormiste?? te apagare aquii

 select * from RegistrarCliente

  select * from TipoSucripcion

 select r.id, r.Nombre,  t.Nombre as'Tipo de suscripcion', t.Tiempo from RegistrarCliente r
  inner join TipoSucripcion t on r.id=t.Id
 
-------------------------------------
 CREATE PROCEDURE spGuardarTipoSuscripcion
 @Id INT,
 @Nombre VARCHAR(50),
 @Tiempo VARCHAR(20),
 @Precio DECIMAL(12,2)
 AS
 BEGIN
	IF NOT EXISTS(SELECT * FROM TipoSucripcion WHERE Id=@Id)
	BEGIN
		INSERT INTO TipoSucripcion (Id,Nombre, Tiempo, Precio) VALUES (@Id,@Nombre, @Tiempo, @Precio)
	END
	ELSE
	BEGIN
		UPDATE TipoSucripcion SET Nombre=@Nombre, Tiempo=@Tiempo, Precio=@Precio WHERE Id=@Id
	END
 END
 --Pense que era identity el Id jeje, pero aqui yo creo que es mejor que no sea identity si es mejor por que ser los tipos de promo que habran asi le ponemos el id si seran el tipo de suscripciones que habran disponibles, sin identity por si se elimina para que se pueda usar el id de nuevo, por que con identity se va sumando aunque se valla eliminando eso sii esta bien Okok Jeje
--------------------------------------
 CREATE PROCEDURE spBorrarSuscripcion
 @Id INT
 AS
 BEGIN
	DELETE FROM TipoSucripcion WHERE Id=@Id
 END
--------------------------------------
 CREATE PROCEDURE spListaTipoSuscripcion
 @IdNombre VARCHAR(50)
 AS
 BEGIN
	IF @IdNombre IS NULL OR @IdNombre=''
	BEGIN
		SELECT Id, Nombre, Tiempo, Precio FROM TipoSucripcion ORDER BY Precio DESC
	END
	ELSE
	BEGIN
		SELECT Id, Nombre, Tiempo, Precio FROM TipoSucripcion WHERE (CONVERT(VARCHAR(20),Id)+Nombre) LIKE '%'+@IdNombre+'%' COLLATE Latin1_General_CI_AI ORDER BY Precio DESC
	END
 END

 CREATE PROCEDURE spCargarSuscripcion
 @Id INT
 AS
 BEGIN
	SELECT * FROM TipoSucripcion WHERE Id=@Id
 END
CREATE PROCEDURE spSiguienteSuscripcion
AS
BEGIN
	SELECT ISNULL(MAX(Id+1),1) FROM TipoSucripcion
END




INSERT INTO TipoSucripcion VALUES(2,'Plata','3',CONVERT(DECIMAL(12,2),200))


SELECT CONVERT(VARCHAR(100), SYSDATETIME(),103)




--Estos tres procedimientos
-----------------------------------
CREATE PROCEDURE spConsultarVerificador
AS
BEGIN
	DECLARE @Verificador UNIQUEIDENTIFIER
	SELECT @Verificador=NEWID()
	SELECT @Verificador AS [Verificador]
END
-------------------------------------
CREATE PROCEDURE spRegistrarUsuario
@Nombre VARCHAR(50),
@Direccion VARCHAR(500),
@Telefono VARCHAR(20),
@Correo VARCHAR(50),
@Contraseña VARCHAR(50),
@Verificador VARCHAR(100),
@Verificado CHAR(1)
AS
BEGIN
	INSERT INTO RegistrarCliente (Nombre, Direccion, Telefono, Correo, Contraseña, Verificador, Verificado) VALUES (@Nombre, @Direccion, @Telefono, @Correo, @Contraseña, @Verificador, @Verificado)
END
-----------------------------------------
CREATE PROCEDURE spVerificarUsuario
@Verificador VARCHAR(100)
AS
BEGIN
	UPDATE RegistrarCliente SET Verificado='S' WHERE Verificador=@Verificador
END
------------------------------------














ALTER PROCEDURE spValidarUsuario
@Correo VARCHAR(50),
@Contraseña VARCHAR(50)
AS
BEGIN
	SELECT * FROM RegistrarCliente WHERE Correo=@Correo AND Contraseña=@Contraseña
END

EXECUTE spValidarUsuario 'Abcdefghijxa@gmail.com','1'