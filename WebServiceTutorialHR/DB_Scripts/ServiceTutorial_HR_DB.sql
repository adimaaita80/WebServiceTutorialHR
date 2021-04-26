Create database HRDB
go

use HRDB
go

Create Table Departments
(
	DepartmentId int primary key identity(1,1),
	DepartmentName nvarchar(200)
)
go

Create Table Employees
(
	EmployeeId int primary key identity(1,1),
	EmployeeName nvarchar(200),
	DepartmentId int,
	foreign key (DepartmentId) references Departments(DepartmentId)
)
go


insert into Departments values('HR Department')
insert into Departments values('Financial Department')
insert into Departments values('Food Department')
insert into Departments values('Trasportation Department')
insert into Departments values('Procurement Department')

Select * from Departments
