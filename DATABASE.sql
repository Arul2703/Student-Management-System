CREATE DATABASE IFET_StudentInfo;

USE IFET_StudentInfo;

CREATE TABLE studentdetails(
  registerNo INT PRIMARY KEY,
  name VARCHAR(50),
  age INT,
  address VARCHAR(100),
  mobileNumber BIGINT,
  emailId VARCHAR(30),
  clgName VARCHAR(30),
  courseName VARCHAR(30),
  specialization VARCHAR(40),
  cgpa FLOAT,
  password VARCHAR(30)
);




