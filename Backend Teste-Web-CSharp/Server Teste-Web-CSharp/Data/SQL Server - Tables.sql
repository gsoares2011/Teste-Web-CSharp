create table Enderecos
(
	id_endereco int identity(1,1) primary key,
	localizacao varchar(60) not null,
	cidade varchar(50) not null,
	estado varchar(50) not null
);

create table PontosTuristicos
(
	id_pontoturistico int identity(1,1) primary key,
	nome varchar(20) not null,
	descricao varchar(100) not null,
	id_enderecoFK int not null references Enderecos(id_endereco),
	data_inclusao date not null
);