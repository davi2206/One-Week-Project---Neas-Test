/****** Script for SelectTopNRows command from SSMS  ******/
use [Neas Project];

CREATE TABLE Salesmen
(
Id varchar(16) PRIMARY KEY,
Name varchar(256)
);

CREATE TABLE Districts
(
Nr varchar(16) PRIMARY KEY,
Name varchar(256),
Manager varchar(16) FOREIGN KEY REFERENCES Salesmen(Id) NOT NULL
);

CREATE TABLE DistrictSalesman
(
Salesman_Id varchar(16) FOREIGN KEY REFERENCES Salesmen(Id) NOT NULL,
District_Id varchar(16) FOREIGN KEY REFERENCES Districts(Nr) NOT NULL,
Manager bit NOT NULL
);

CREATE TABLE Stores
(
Id varchar(16) PRIMARY KEY,
Name varchar(256)
);

CREATE TABLE DistrictStore
(
Store_Id varchar(16) FOREIGN KEY REFERENCES Stores(Id) NOT NULL,
District_Nr varchar(16) FOREIGN KEY REFERENCES Districts(Nr) NOT NULL
);