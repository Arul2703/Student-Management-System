CREATE DATABASE IFET_StudentInfo;

USE IFET_StudentInfo;

-- CREATE TABLE studentdetails(
--   registerNo INT PRIMARY KEY,
--   name VARCHAR(50),
--   age INT,
--   address VARCHAR(100),
--   mobileNumber BIGINT,
--   emailId VARCHAR(30),
--   clgName VARCHAR(30),
--   courseName VARCHAR(30),
--   specialization VARCHAR(40),
--   cgpa FLOAT,
--   password VARCHAR(30)
-- );

INSERT INTO studentdetails VALUES(1,'Aarthi',20,'No 33,K.S.A.R Road,Cuddalore',8723075351,'aarthinachimuthu@gmail.com','IFET College of Engineering','B.E','C.S.E',8.23,'Aarthi@20'),
(2,'Abinaya Devanathan',19,'No 9, Naidu Street,Sedapalayam, Pudhukuppam, Cuddalore.',7806853534,'abinayadevanathan@gmail.com','IFET College of Engineering','B.E','C.S.E',9.31,'abiNaya@26'),
(13,'Arularasi J',20,'No 1,2nd Rajaji Street,Nellikuppam, Cuddalore.',9361604668,'arularasi2002@gmail.com','IFET College of Engineering','B.E','C.S.E',8.89,'Arju@27');

SELECT * FROM studentdetails;
ALTER TABLE studentdetails ALTER COLUMN courseName VARCHAR(100);





