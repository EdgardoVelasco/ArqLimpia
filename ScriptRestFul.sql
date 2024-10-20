drop database if exists reservas;
create database reservas;
use reservas;
create table users(id int primary key auto_increment, name varchar(100) not null, email varchar(100) not null, password varchar(255));
create table room (
    id int primary key auto_increment,
    roomid varchar(100), 
    available bool,
    FOREIGN KEY () REFERENCES 
);
create table reservations(id primary key auto_increment, userId int, roomId int, begin DATETIME, end DATETIME);



