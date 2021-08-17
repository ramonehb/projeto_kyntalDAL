
	CREATE TABLE USUARIO(
	IDUsuario INT PRIMARY KEY NOT NULL IDENTITY (1,1),
	IDTipoUsuario INT NOT NULL,
	nome NVARCHAR (15) NOT NULL,
	senha NVARCHAR (15) NOT NULL,
	email NVARCHAR (30) NOT NULL,
	FtStatus BIT NOT NULL
	 FOREIGN KEY (IDTipoUsuario) REFERENCES TIPO_USUARIO(IDTipoUsuario)

)

INSERT INTO USUARIO (IDTipoUsuario,nome,senha,email,FtStatus)
	VALUES (2,TRIM('gerson '),TRIM('aa2468'),TRIM('taf@gmail.com'),1)





CREATE TABLE TIPO_USUARIO(
	IDTipoUsuario INT PRIMARY KEY NOT NULL IDENTITY(1,1),
	tipo NVARCHAR(20) NOT NULL
)

INSERT INTO TIPO_USUARIO(tipo)
	VALUES(TRIM('Outros'))

CREATE TABLE CLIENTE(
	IDCliente INT PRIMARY KEY NOT NULL IDENTITY,
	nomecompleto VARCHAR (50) NOT NULL,
	numeromesa INT NOT NULL,
	email VARCHAR (50) NOT NULL,
	telefone VARCHAR (20) NOT NULL,
	assunto VARCHAR (1000) NULL,
	nascimento DATE NOT NULL

)

INSERT INTO CLIENTE (nomecompleto,numeromesa,email,telefone,assunto,nascimento)
	VALUES(TRIM('Larissa da Silva'),8,TRIM('larissa@gmail.com'),TRIM('(11) 99873-4098'),TRIM('Gostarei muito do lugar!'),'1998-02-08')


	select * from CLIENTE

