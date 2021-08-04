
CREATE TABLE Departamente
(
  id_departament INT primary key,
  nume_departament VARCHAR(30) constraint ch_nume_departament check (len(nume_departament)>1)
);

insert into Departamente values (1, 'Resurse Umane')
insert into Departamente values (2, 'Finante')
insert into Departamente values (3, 'Dezvoltare')
CREATE TABLE Echipe
(
  id_echipa INT primary key,
  nume VARCHAR(30) constraint ch_nume check (len(nume)>=1)
);

insert into Echipe values (1, 'Fullstack1')
insert into Echipe values (2, 'Fullstack2')
insert into Echipe values (3, 'Back-end')
insert into Echipe values (4, 'Back-end2')
CREATE TABLE Clienti
(
  id_client INT constraint pk_client primary key,
  nume VARCHAR(30) NOT NULL,
  prenume VARCHAR(30) NOT NULL,
  numar_telefon VARCHAR(11) NOT NULL unique,
  email VARCHAR(50) NOT NULL unique,
);

insert into Clienti values (1, 'Popescu','Radu','0755746112','pradu@yahoo.com')
insert into Clienti values (2, 'Oprescu','Alexandru','0755776112','alexo@yahoo.com')
insert into Clienti values (3, 'Ionescu','Ivan','0755746512','ioni@yahoo.com')
CREATE TABLE Adrese
(
  id_adresa INT primary key,
  judet VARCHAR(30) NOT NULL,
  localitate VARCHAR(50) NOT NULL,
  strada VARCHAR(40),
  numar INT not null,
  bloc VARCHAR(10),
  scara VARCHAR(10),
  apartament INT,
  id_client INT NOT NULL,
  constraint fk_id_client FOREIGN KEY (id_client) REFERENCES Clienti(id_client) on delete cascade
);

insert into Adrese values (1, 'Arad','Nadlac','Mihai Eminescu',2, 'F5','A',12, 1)
insert into Adrese values (2, 'Arges','Pitesti','I. C. Bratianu',5, 'A5','A',2, 1)
insert into Adrese values (3, 'Arges','Campulung','Negru Voda',66, NULL,NULL,NULL, 2)
insert into Adrese values (4, 'Prahova','Campina','Primaverii',38, NULL,NULL,NULL, 2)
insert into Adrese values (5, 'Vrancea','Focsani','Nicolae Iorga',21, 'B2','D',5, 3)
insert into Adrese values (6, 'Bacau','Bacau','Dumbravei',5, 'A1','C',8, 3)

CREATE TABLE Angajati
(
  id_angajat INT primary key,
  nume VARCHAR(30) NOT NULL,
  prenume VARCHAR(30) NOT NULL,
  numar_telefon VARCHAR(11) NOT NULL unique,
  email VARCHAR(50) NOT NULL unique,
  data_angajarii DATE NOT NULL,
  data_nasterii DATE NOT NULL,
  salariu INT NOT NULL,
  id_departament INT,
  id_echipa INT,
  constraint fk1_departament FOREIGN KEY (id_departament) REFERENCES Departamente(id_departament) on delete cascade,
  constraint fk2_echipa FOREIGN KEY (id_echipa) REFERENCES Echipe(id_echipa) on delete cascade
);



insert into Angajati values (1, 'Popescu','Andrei','0768465988','ap@yahoo.com','12 APR 1990','20 DEC 2018', 6000 , 1, NULL)
insert into Angajati values (2, 'Popa','Alexandru','0768325948','palex@yahoo.com','10 AUG 1995','2 JUN 2019', 3000 , 3, 1)
insert into Angajati values (3, 'Alexandrescu','Theodora','0768465945','ath@yahoo.com','12 MAR 1986','25 FEB 2013', 12000 , 3, 2)
insert into Angajati values (4, 'Cristescu','Marian','0768465345','cma@yahoo.com','17 APR 1993','20 NOV 2018', 5000 , 3, 3)
insert into Angajati values (5, 'Serban','Bianca','0768465789','sbi@yahoo.com','20 MAY 1998','2 OCT 2017', 6300 , 3, 4)
insert into Angajati values (6, 'Nan','Marius','0768465357','nmar@yahoo.com','31 AUG 1998','5 DEC 2019', 6700 , 3, 1)
insert into Angajati values (7, 'Achimescu','Ioana','0768265935','aio@yahoo.com','1 APR 1990','8 SEP 2018', 8000 , 3, 3)
insert into Angajati values (8, 'Tuta','Alin','0762346588','tali@yahoo.com','2 MAR 1982','10 AUG 2011', 15000 , NULL, 2)
insert into Angajati values (9, 'Tuta','Roxana','0768463488','trox@yahoo.com','12 JUL 1993','3 JAN 2017', 5000 , 3, 4)
insert into Angajati values (10, 'Vladimirescu','Bogdan','0768237988','bogv@yahoo.com','13 JAN 1989','13 JUN 2015', 8600 , 2, NULL)
CREATE TABLE Proiecte
(
  id_proiect INT constraint pk_proiect primary key,
  data_inceperii DATE NOT NULL,
  data_finalizarii DATE NOT NULL,
  nume_proiect VARCHAR(30) constraint ch_nume_proiect check (len(nume_proiect)>=1),
  id_echipa INT NOT NULL,
  constraint fk_id_echipa FOREIGN KEY (id_echipa) REFERENCES Echipe(id_echipa) on delete cascade

);
alter table Proiecte
 add constraint check_dates check (data_inceperii < data_finalizarii);

 insert into Proiecte values (1, '6 FEB 2020','5 MAR 2020','A1',1)
 insert into Proiecte values (2, '8 JAN 2017','15 OCT 2018','B2',2)
 insert into Proiecte values (3, '17 APR 2018','5 MAR 2020','C3',3)
 insert into Proiecte values (4, '21 SEP 2019','25 DEC 2019','D4',4)
 insert into Proiecte values (5, '6 NOV 2019','19 AUG 2020','C2',2)


 CREATE TABLE Produse
(
  id_produs INT primary key,
  nume VARCHAR(30) NOT NULL,
  pret INT NOT NULL,
  id_proiect INT NOT NULL,
  FOREIGN KEY (id_proiect) REFERENCES Proiecte(id_proiect)  on delete cascade
);


insert into Produse values (1, 'API', 4325, 1)
insert into Produse values (2, 'Horizon Zero Dawn', 325, 2)
insert into Produse values (3, 'Horizon West', 400, 2)
insert into Produse values (4, 'RE Software', 3600, 3)
insert into Produse values (5, 'ACD Home', 340, 4)

CREATE TABLE Comenzi
(
  cantitate INT NOT NULL,
  id_comanda INT primary key,
  id_produs INT NOT NULL,
  id_adresa INT NOT NULL,
  FOREIGN KEY (id_produs) REFERENCES Produse(id_produs) on delete cascade,
  FOREIGN KEY (id_adresa) REFERENCES Adrese(id_adresa) on delete cascade
);

insert into Comenzi values (1, 1, 2, 4)
insert into Comenzi values (6, 2, 2, 2)
insert into Comenzi values (10, 3, 3, 5)
insert into Comenzi values (2, 4, 4, 5)
insert into Comenzi values (1, 5, 5, 2)
insert into Comenzi values (1, 6, 1, 3)
insert into Comenzi values (1, 7, 2, 3)
insert into Comenzi values (1, 8, 3, 4)


