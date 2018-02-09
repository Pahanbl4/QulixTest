# QulixTest

1.Create DB

CREATE DATABASE QulixDB
GO

USE [QulixDB]
CREATE TABLE Company
(
CompanyId int identity(1,1) PRIMARY KEY,
Name varchar(50),
CompanySize int,
OrganizationalLegalForm varchar(50)
)

CREATE TABLE Worker 
(
WorkerId int identity(1,1) PRIMARY KEY, 
LastName varchar(50),
FirstName varchar(50),
Patronymic varchar(50),
EntryDate date,
Position varchar(50),
CompanyId int

FOREIGN KEY(CompanyId) REFERENCES Company(CompanyId)
)

2.Change connectionStrings(PAVEL\INSTANCE1  -  on your server) in folder App.Config.
