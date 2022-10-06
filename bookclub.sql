create database bookclub;
use bookclub;

create table person (
    id int NOT NULL AUTO_INCREMENT,
    FirstName varchar(50),
    LastName varchar(50),
    Email varchar(50),
    PRIMARY KEY (id)
);

create table presentation (
    id int NOT NULL AUTO_INCREMENT,
    PersonId int,
    PresentationDate datetime,
    BookTitle varchar(50),
    BookAuthor varchar(50),
    Genre varchar(25),
    PRIMARY KEY (id),
    foreign key (PersonId) references person(id)
);

select * from presentation;