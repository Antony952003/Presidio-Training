create database dbDoctorPatient

use dbDoctorPatient

create table Patient(
Id int,
Name varchar(20),
MobNumber varchar(20)
)

ALTER TABLE Patient
ALTER COLUMN Id int NOT NULL;

ALTER TABLE Patient
ADD CONSTRAINT PK_Patient PRIMARY KEY (Id)

create table Doctor(
Id int,
Name varchar(20),
Specialization varchar(20)
)

ALTER TABLE Appointment
ALTER COLUMN Id int NOT NULL;

ALTER TABLE Appointment
ADD CONSTRAINT PK_Appointment PRIMARY KEY (Id)

create table Appointment(
Id int ,
PatientId int constraint fk_patient_id foreign key references Patient(Id),
DoctorId int constraint fk_doctor_id foreign key references Doctor(Id),
AppointmentDateTime DateTime,
AppointmentStatus varchar(20),
MedicalInformation varchar(20)
)



