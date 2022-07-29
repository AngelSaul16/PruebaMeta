CREATE DATABASE collage

USE collage

CREATE TABLE students(
Id int not null primary key,
Nick varchar(30),
Birth date,
Grade varchar(20),
Status varchar(20),
)

INSERT INTO students(Nick, Birth, Grade, Status) VALUES ('Pedro Martinez', '2002-07-20', 'Matematicas', 'Activo')

SELECT * FROM students