use [Neas Project];

DROP TABLE DistrictStore;
DROP TABLE Stores;
DROP TABLE DistrictSalesman;
DROP TABLE Districts;
DROP TABLE Salesmen;

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

INSERT INTO Salesmen VALUES ('0', 'Dave');
INSERT INTO Salesmen VALUES ('1', 'Mark');
INSERT INTO Salesmen VALUES ('2', 'Hanz');
INSERT INTO Salesmen VALUES ('3', 'Eric');
INSERT INTO Salesmen VALUES ('4', 'Niels');
INSERT INTO Salesmen VALUES ('5', 'Bobby');
INSERT INTO Salesmen VALUES ('6', 'Bruce');
INSERT INTO Salesmen VALUES ('7', 'James');
INSERT INTO Salesmen VALUES ('8', 'Harvey');
INSERT INTO Salesmen VALUES ('9', 'Rachel');
INSERT INTO Salesmen VALUES ('10', 'Alfred');
INSERT INTO Salesmen VALUES ('11', 'Lucius');

INSERT INTO Districts VALUES ('0', 'Nordjylland', (SELECT Id FROM Salesmen WHERE Id='1'));
INSERT INTO Districts VALUES ('1', 'Midtjylland', (SELECT Id FROM Salesmen WHERE Id='1'));
INSERT INTO Districts VALUES ('2', 'Østjylland', (SELECT Id FROM Salesmen WHERE Id='2'));
INSERT INTO Districts VALUES ('3', 'Sønderjylland', (SELECT Id FROM Salesmen WHERE Id='0'));
INSERT INTO Districts VALUES ('4', 'Øerne', (SELECT Id FROM Salesmen WHERE Id='6'));
INSERT INTO Districts VALUES ('5', 'Sjælland', (SELECT Id FROM Salesmen WHERE Id='3'));
INSERT INTO Districts VALUES ('6', 'Hovedstaden', (SELECT Id FROM Salesmen WHERE Id='5'));
INSERT INTO Districts VALUES ('7', 'Bornhold', (SELECT Id FROM Salesmen WHERE Id='4'));
INSERT INTO Districts VALUES ('8', 'Online', (SELECT Id FROM Salesmen WHERE Id='7'));

INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='1'), 
	(SELECT Nr FROM Districts WHERE Nr='0'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='1'), 
	(SELECT Nr FROM Districts WHERE Nr='1'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='2'), 
	(SELECT Nr FROM Districts WHERE Nr='2'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='0'), 
	(SELECT Nr FROM Districts WHERE Nr='3'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='6'), 
	(SELECT Nr FROM Districts WHERE Nr='4'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='3'), 
	(SELECT Nr FROM Districts WHERE Nr='5'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='4'), 
	(SELECT Nr FROM Districts WHERE Nr='7'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='7'), 
	(SELECT Nr FROM Districts WHERE Nr='8'), 
	1);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='8'), 
	(SELECT Nr FROM Districts WHERE Nr='5'), 
	0);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='9'), 
	(SELECT Nr FROM Districts WHERE Nr='6'), 
	0);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='10'), 
	(SELECT Nr FROM Districts WHERE Nr='5'), 
	0);
INSERT INTO DistrictSalesman VALUES (
	(SELECT Id FROM Salesmen WHERE Id='11'), 
	(SELECT Nr FROM Districts WHERE Nr='8'), 
	0);

INSERT INTO Stores VALUES ('0', 'DS Inc.');
INSERT INTO Stores VALUES ('1', 'That one Shop');
INSERT INTO Stores VALUES ('2', 'Salgs butik');
INSERT INTO Stores VALUES ('3', 'Tøj til dyr A/S');
INSERT INTO Stores VALUES ('4', 'Mussefælden Dyrehandel');
INSERT INTO Stores VALUES ('5', 'Kantinen ApS');
INSERT INTO Stores VALUES ('6', 'Gummianden ApS');
INSERT INTO Stores VALUES ('7', 'Bilforhandler Olsen');
INSERT INTO Stores VALUES ('8', 'Købmanden');
INSERT INTO Stores VALUES ('9', 'Audio Butikken');
INSERT INTO Stores VALUES ('10', 'Skip-a-beat Pacemakers Ltd.');
INSERT INTO Stores VALUES ('11', 'Kontorshoppen');
INSERT INTO Stores VALUES ('12', 'Loose Bull Glassware');
INSERT INTO Stores VALUES ('13', 'SælgEnSæl.dk');
INSERT INTO Stores VALUES ('14', 'Privatflyet.com');
INSERT INTO Stores VALUES ('15', 'www.www_forhandleren.dk');

INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='0'), 
	(SELECT Nr FROM Districts WHERE Nr='0'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='1'), 
	(SELECT Nr FROM Districts WHERE Nr='0'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='2'), 
	(SELECT Nr FROM Districts WHERE Nr='1'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='3'), 
	(SELECT Nr FROM Districts WHERE Nr='1'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='4'), 
	(SELECT Nr FROM Districts WHERE Nr='2'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='5'), 
	(SELECT Nr FROM Districts WHERE Nr='2'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='6'), 
	(SELECT Nr FROM Districts WHERE Nr='3'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='7'), 
	(SELECT Nr FROM Districts WHERE Nr='3'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='8'), 
	(SELECT Nr FROM Districts WHERE Nr='4'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='9'), 
	(SELECT Nr FROM Districts WHERE Nr='4'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='10'), 
	(SELECT Nr FROM Districts WHERE Nr='5'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='11'), 
	(SELECT Nr FROM Districts WHERE Nr='5'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='12'), 
	(SELECT Nr FROM Districts WHERE Nr='6'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='13'), 
	(SELECT Nr FROM Districts WHERE Nr='8'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='14'), 
	(SELECT Nr FROM Districts WHERE Nr='8'));
INSERT INTO DistrictStore VALUES (
	(SELECT Id FROM Stores WHERE Id='15'), 
	(SELECT Nr FROM Districts WHERE Nr='8'));
