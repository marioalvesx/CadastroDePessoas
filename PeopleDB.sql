create database teste_cadastros 
go
use PeopleDB
go
create table pessoas
(
	Id int IDENTITY(1,1) primary key,
	Nome varchar (100) not null,
	Telefone varchar (100) not null,	
)
go
insert into pessoas values('Alberto', '51992435677')
insert into pessoas values('Joao', '51992455677')
insert into pessoas values('Flavio', '51992665677')
insert into pessoas values('Leonardo', '51992488677')
insert into pessoas values('Giacomo', '51992435600')
insert into pessoas values('Antonio', '51955435677')
insert into pessoas values('Mario', '519999435677')
insert into pessoas values('Roberto', '51992437777677')
insert into pessoas values('Jessica', '51992435577')
insert into pessoas values('Leticia', '5199243335677')

go
select * from pessoas