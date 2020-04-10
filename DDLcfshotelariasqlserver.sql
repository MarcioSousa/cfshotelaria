DROP DATABASE cfshotelaria;
GO

CREATE DATABASE cfshotelaria;
GO

USE cfshotelaria;
GO

CREATE TABLE quarto(
	numero numeric(5) primary key,
	valordiaria numeric(6,2),
	localidade varchar(10)
);
GO

CREATE TABLE limpeza(
	codigo int primary key,
	cod_quarto numeric(5) REFERENCES quarto(numero),
	datalimpeza datetime
);
GO

CREATE TABLE aluguel(
	codigo int primary key,
	cod_quarto numeric(5) REFERENCES quarto(numero),
	datachegada datetime,
	datasaida datetime,
	valor numeric(6,2)
);
GO

CREATE TABLE pagamento(
	codigo int primary key,
	cod_aluguel int REFERENCES aluguel(codigo),
	dia_pagamento datetime,
	tipo varchar(10),
	valor numeric(6,2)
);
GO

CREATE TABLE cliente(
	codigo int primary key,
	cod_aluguel int REFERENCES aluguel(codigo),
	nome varchar(50),
	rg varchar(15),
	cpf varchar(15),
	contato varchar(15)
);
GO

CREATE TABLE pedido(
	codigo int primary key,
	cod_aluguel int REFERENCES aluguel(codigo),
	data_pedido datetime
);
GO

CREATE TABLE produto(
	codigo int primary key,
	nome varchar(50),
	valor numeric(6,2),
	qtde_atual int
);
GO

CREATE TABLE itempedido(
	codigo int primary key,
	cod_pedido int REFERENCES pedido(codigo),
	cod_produto int REFERENCES produto(codigo),
	qtde int,
	valor numeric(6,2)
);
GO

CREATE TABLE entrada(
	codigo int primary key,
	cod_produto int REFERENCES produto(codigo),
	data_entrada datetime,
	data_vencimento datetime,
	qtde int
);
GO