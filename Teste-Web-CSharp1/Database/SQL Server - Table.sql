create table PontosTuristicos
(
	id_pontoturistico int identity(1,1) primary key,
	nome varchar(20) not null,
	descricao varchar(100) not null,
	localizacao varchar(60) not null,
	cidade varchar(50) not null,
	estado varchar(50) not null
);