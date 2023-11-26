create database FIS;

CREATE TABLE Admin(
AdminId int Primary Key,
Password Nvarchar(max) not null
);

CREATE TABLE UserType (
  UserTypeID int PRIMARY KEY,
  Password nvarchar(max)not null
);

CREATE TABLE Department (
  DeptID int PRIMARY KEY,
  DeptName nvarchar(max)not null
);

CREATE TABLE Designation (
  DesignationID int PRIMARY KEY, 
  DesignationName nvarchar(max)not null
);

CREATE TABLE Faculty (
  FacultyID int PRIMARY KEY,
  FirstName nvarchar(max)not null,
  LastName nvarchar(max)not null,
  Address nvarchar(max)not null,
  City nvarchar(max)not null,
  State nvarchar(max)not null,
  Pincode int not null,
  MobileNo nvarchar(max)not null,
  HireDate date not null,
  EmailAddress nvarchar(max) not null,
  DateofBirth date not null,
  DeptID int FOREIGN KEY REFERENCES Department(DeptID),
  DesignationID int FOREIGN KEY REFERENCES Designation(DesignationID),
  UserTypeID int FOREIGN KEY REFERENCES UserType(UserTypeID)
);

CREATE TABLE Publications (
  PublicationID int PRIMARY KEY,
  FacultyID int FOREIGN KEY REFERENCES Faculty(FacultyID), 
  PublicationTitle nvarchar(max)not null,
  ArticleName nvarchar(max)not null,
  PublisherName nvarchar(max)not null,
  PublicationLocation nvarchar(max)not null,
  PublishedDate date not null
);

CREATE TABLE WorkHistory (
  WorkHistoryID int PRIMARY KEY,
  FacultyID int FOREIGN KEY REFERENCES Faculty(FacultyID),
  Organization nvarchar(max) not null,
  JobTitle nvarchar(max) not null,
  JobBeginDate date not null,
  JobEndDate date not null,
  JobResponsibilities nvarchar(max) not null,
  JobType nvarchar(max) not null
);
 
CREATE TABLE Degrees (
  DegreeID int PRIMARY KEY,
  FacultyID int FOREIGN KEY REFERENCES Faculty(FacultyID),
  Degree nvarchar(max) not null,
  Specialization nvarchar(max)not null,
  DegreeYear int not null,
  Grade nvarchar(max) not null
);
 
CREATE TABLE Grants (
  GrantID int PRIMARY KEY,
  FacultyID int FOREIGN KEY REFERENCES Faculty(FacultyID),
  GrantTitle nvarchar(max) not null,
  GrantDescription nvarchar(max) not null
);
 
CREATE TABLE Courses (
  CourseID int PRIMARY KEY ,
  CourseName nvarchar(max) not null,
  CourseCredits int not null,
  DeptID int FOREIGN KEY REFERENCES Department(DeptID)
);  
 
CREATE TABLE Subjects (
  SubjectID int PRIMARY KEY,
  SubjectName nvarchar(max) not null
);
 
CREATE TABLE CourseSubject (
  CourseID int FOREIGN KEY REFERENCES Courses(CourseID),
  SubjectID int FOREIGN KEY REFERENCES Subjects(SubjectID) 
);
 
CREATE TABLE CoursesTaught (
  CourseID int FOREIGN KEY REFERENCES Courses(CourseID),
  FacultyID int FOREIGN KEY REFERENCES Faculty(FacultyID),
  SubjectID int FOREIGN KEY REFERENCES Subjects(SubjectID),
  FirstDateTaught date not null
);

select * from WorkHistory
select * from Faculty
update UserType set Password='bhavgna@123' where UserTypeID=12
insert into Admin values(1033435,'Lechuash@3701');
Alter table 
INSERT INTO Faculty (FacultyID, FirstName, LastName, Address, City, State, Pincode, MobileNo, HireDate, EmailAddress, DateOfBirth, DeptID, DesignationID,UserTypeID)
VALUES(2, 'Bhavgna', 'Pinninti', '456 Oak St', 'Townsville', 'Stateville', '54321', '555-5678', '2023-02-20', 'jane.smith@email.com', '1985-08-10', 1, 1,12);







