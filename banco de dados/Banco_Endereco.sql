drop database if exists EnderecoViaAPI;
Create database EnderecoViaAPI;
use EnderecoViaAPI;

create table enedreco(
Id int primary key auto_increment,
CEP varchar(10) not null,
Estado varchar(70) not null,
Cidade varchar (70) not null,
Bairro varchar(70) not null,
Logradouro varchar(150) not null, 
Complemento varchar (150)not null,
Numero varchar(15));
