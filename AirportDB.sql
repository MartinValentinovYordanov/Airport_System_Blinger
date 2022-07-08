drop database blinger;
create database blinger;
use blinger;




create table if not exists airports(
id int auto_increment unique not null,
airport_id varchar(3) unique not null,
`name` varchar(64) unique not null primary key ,
country varchar(32) not null,
city varchar(32) unique not null,
adress varchar(128) unique not null
);

insert into airports (airport_id, `name`, country, city, adress) values ("SOF", "Sofia Airport", "Bulgaria", "Sofia", "Bulevard „Hristofor Kolumb“ 1, 1540");
insert into airports (airport_id, `name`, country, city, adress) values ("BOJ", "Burgas Airport", "Bulgaria", "Burgas", "Administration floor 2 office 201, 8016 Burgas");
insert into airports (airport_id, `name`, country, city, adress) values ("VAR", "Varna Airport", "Bulgaria", "Varna", "Varna Airport, 9154 Varna");
insert into airports (airport_id, `name`, country, city, adress) values ("PDV", "Plovdiv International Airport", "Bulgaria", "Plovdiv", "4112 Krumovo");
insert into airports (airport_id, `name`, country, city, adress) values ("HND", "Haneda International Airport", "Japan", "Tokyo", "Hanedakuko, Ota City, Tokyo 144-0041");
insert into airports (airport_id, `name`, country, city, adress) values ("ATL", "Hartsfield-Jackson Atlanta International Airport", "USA", "Atlanta", "6000 N Terminal Pkwy, Atlanta, GA 30320");
insert into airports (airport_id, `name`, country, city, adress) values ("DFW", "Dallas/Fort Worth International Airport", "USA", "Texas", "2400 Aviation Dr, DFW Airport, TX 75261");
insert into airports (airport_id, `name`, country, city, adress) values ("ORD", "Chicago O’Hare International Airport", "USA", "Chicago", "10000 W O'Hare Ave, Chicago, IL 60666");
insert into airports (airport_id, `name`, country, city, adress) values ("LAX", "Los Angeles International Airport", "USA", "Los Angeles", "1 World Way, Los Angeles, CA 90045");
insert into airports (airport_id, `name`, country, city, adress) values ("MCO", "Orlando International Airport", "USA", "Orlando", "1 Jeff Fuqua Blvd, Orlando, FL 32827");
insert into airports (airport_id, `name`, country, city, adress) values ("CAN", "Guangzhou Baiyun International Airport", "China", "Guangzhou", "Baiyun, Guangzhou, Guangdong Province");
insert into airports (airport_id, `name`, country, city, adress) values ("CTU", "Chengdu Shuangliu International Airport", "China", "Chengdu", "Shuangliu, Chengdu, Sichuan");

create table if not exists airline(
id int not null auto_increment unique ,
`name` varchar(6) not null primary key
);


create table flight(
id int primary key auto_increment unique not null,
AirlineName varchar(6) not null,
constraint fl_airline_id foreign key (AirlineName) references airline(`name`) on delete cascade,
AirportOriginName varchar(64) not null,
constraint fl_airport_from_id foreign key (AirportOriginName) references airports(`name`) on delete cascade,
AirportDestinationName varchar(64) not null,
constraint fl_airport_to_id foreign key (AirportDestinationName) references airports(`name`) on delete cascade,
TakeOffDate datetime not null,
LandingDate datetime not null,
`Row` int not null,
Col int not null
);


create table seat(
id int not null auto_increment unique primary key,
FlightId int not null,
SeatClass enum('Business','Economy' , 'First'),
IsBooked boolean default(false) not null,
`Row` int not null,
Col char not null,
constraint foreign key (FlightId) references flight(id) on delete cascade
);

insert into seat(FlightId,SeatClass,IsBooked,`Row`,Col) values(2,'Economy',false,2,'A');
select*from seat;
drop table seat;
drop table flight;
drop table airline;
select*from flight;
select*from airline;
select*from airports;
