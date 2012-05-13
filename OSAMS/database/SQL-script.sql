create database [osams]
use [osams]

--create table
CREATE TABLE dbo.account_type(
	account_type_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	account_type varchar(500) NOT NULL,
	active bit NULL
	)
CREATE TABLE dbo.account(
	account_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	user_name varchar(10) NOT NULL UNIQUE,
	password varchar(500) NOT NULL,
	active bit NULL,
	account_type_id int NOT NULL FOREIGN KEY REFERENCES dbo.account_type(account_type_id)
	)

CREATE TABLE dbo.admin(
	staff_id varchar(10) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES account(user_name),
	family_name varchar(500) NULL,
	middle_name varchar(500) NULL,
	given_name varchar(500) NULL,
	gender varchar(1) NOT NULL,
	email varchar(500) NULL,
	active bit NULL
	)
CREATE TABLE dbo.student(
	student_id varchar(10) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES account(user_name),
	family_name varchar(500) NULL,
	middle_name varchar(500) NULL,
	given_name varchar(500) NULL,
	gender varchar(1) NOT NULL,
	email varchar(500) NULL,
	program varchar(500) NOT NULL,
	stream varchar(500) NOT NULL,
	active bit NULL
	)
CREATE TABLE dbo.semester(
	semester_name varchar(500) NOT NULL PRIMARY KEY,
	start_date datetime NOT NULL,
	end_date datetime NOT NULL,
	active bit NULL
	)
CREATE TABLE lecturer(
	lecturer_id varchar(10) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES account(user_name),
	family_name varchar(500) NULL,
	middle_name varchar(500) NULL,
	given_name varchar(500) NULL,
	gender varchar(1) NOT NULL,
	email varchar(500) NULL,
	active bit NULL
	)
CREATE TABLE day_of_week(
	day_id int NOT NULL PRIMARY KEY,
	day varchar(500) NOT NULL,
	active bit NULL
	)


CREATE TABLE course
	(
	course_id varchar(500) NOT NULL PRIMARY KEY,
	course_name varchar(500) NOT NULL,
	credit int NULL,
	level varchar(100) NULL,
	active bit NULL
	)

CREATE TABLE [group]
	(
	group_id int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	group_name varchar(90) NOT NULL,
	number_of_student int NULL,
	active bit NULL,
	course_id varchar(500) NOT NULL FOREIGN KEY REFERENCES dbo.course(course_id),
	semester_name varchar(500) NOT NULL FOREIGN KEY REFERENCES dbo.semester(semester_name),
	lecturer_id varchar(10) NOT NULL FOREIGN KEY REFERENCES dbo.lecturer(lecturer_id)
	)

CREATE TABLE group_day
	(
	group_day_id int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	start_time datetime NULL,
	end_time datetime NULL,
	type varchar(50) NULL,
	active bit NULL,
	group_id int NOT NULL FOREIGN KEY REFERENCES dbo.[group](group_id),
	day_id int NOT NULL FOREIGN KEY REFERENCES dbo.day_of_week(day_id)
	)
CREATE TABLE student_group
	(
	student_group_id int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	grade int NULL,
	result varchar(10) NULL,
	comment varchar(500) NULL,
	active bit NULL,
	group_id int NOT NULL FOREIGN KEY REFERENCES dbo.[group](group_id),
	student_id varchar(10) NOT NULL FOREIGN KEY REFERENCES dbo.student(student_id)
	)
CREATE TABLE schedule
	(
	schedule_id int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	date datetime NULL,
	active bit NULL,
	group_id  int NOT NULL FOREIGN KEY REFERENCES dbo.[group](group_id)
	)
CREATE TABLE student_schedule
	(
	student_schedule_id int NOT NULL IDENTITY (1, 1) PRIMARY KEY,
	status varchar(50) NOT NULL,
	active bit NULL,
	schedule_id int NOT NULL FOREIGN KEY REFERENCES dbo.schedule(schedule_id),
	student_id varchar(10) NOT NULL FOREIGN KEY REFERENCES dbo.student(student_id)
	)
	
	
	--initialize table
	
insert into day_of_week
values (1, 'Monday', 1)
insert into day_of_week
values (2, 'Tuesday', 1)
insert into day_of_week
values (3, 'Wednesday', 1)
insert into day_of_week
values (4, 'Thursday', 1)
insert into day_of_week
values (5, 'Friday', 1)
insert into day_of_week
values (6, 'Saturday', 1)
insert into day_of_week
values (7, 'Sunday', 1)
insert into account_type
values ('Super Admin', 1)
insert into account_type
values ('Admin', 2)
insert into account_type
values ('Senior Lecturer', 3)
insert into account_type
values ('Lecturer', 4)
insert into account_type
values ('Student', 5)
insert into account
VALUES ('v00000', '1234', 1, 1)
insert into [dbo].[admin]
values ('v00000', 'Phan', '', 'Trung', 'M', 'v00000@rmit.edu.vn', 1)
------------------------------------------------------------------------------------

insert into account
VALUES ('v00001', '1234', 1, 2)
insert into [dbo].[admin]
values ('v00001', 'Nguyen', '', 'Tram', 'F', 'v00001@rmit.edu.vn', 1)
insert into account
VALUES ('v00002', '1234', 1, 2)
insert into [dbo].[admin]
values ('v00002', 'Vien', '', 'Uyen', 'F', 'v00002@rmit.edu.vn', 1)

insert into account
VALUES ('v91111', '1234', 1, 3)
insert into lecturer
values ('v91111', 'Narumon', '', 'Cherry', 'F', 'v91111@rmit.edu.vn', 1)
insert into account
VALUES ('v92222', '1234', 1, 4)
insert into lecturer
values ('v92222', 'Au', '', 'Bill', 'M', 'v92222@rmit.edu.vn', 1)
insert into account
VALUES ('v93333', '1234', 1, 4)
insert into lecturer
values ('v93333', 'Ulhaq', '', 'Irfan', 'M', 'v93333@rmit.edu.vn', 1)


-----------------------------------------------------------------------------


INSERT  INTO course (course_id, course_name, credit, level, active) 
VALUES ('ISYS2132','BIS Capstone Project','12','Bachelor',1)
INSERT  INTO course (course_id, course_name, credit, level, active) 
VALUES ('ISYS2424','BIS Strategy and Governance','12','Bachelor',1)

--sua cai end date lai
INSERT  INTO semester (semester_name, start_date, end_date, active) 
VALUES ('2011C','20111017','20120121','1')

insert into account values ( 's9220646', '1234', 1, 5) 
insert into student values ('s9220646', 'Le', 'Lam', 'Lu', 'F', 's9220646@rmit.edu.vn', 'BP138', '', 1)
 insert into account values ( 's9220658', '1234', 1, 5) 
 insert into student values ('s9220658', 'Nguyen', 'Ly', 'Nam', 'M', 's9220658@rmit.edu.vn', 'BP138', '', 1) 
insert into [dbo].[group] values ('1', 2, 1, 'ISYS2132', '2011C', 'v92222') 

insert into group_day values ('09:00:00', '12:00:00', 'Lecture', 1, 1, 1)  
insert into group_day values ('10:00:00', '13:00:00', 'Tutorial', 1, 1, 3)  
insert into student_group values (NULL, NULL, NULL, 1, 1, 's9220646')  
insert into student_group values (NULL, NULL, NULL, 1, 1, 's9220658') 


insert into schedule values ('20111017', 1, 1) 
insert into schedule values ('20111019', 1, 1)
insert into schedule values ('20111024', 1, 1) 
insert into schedule values ('20111026', 1, 1) 
insert into schedule values ('20111031', 1, 1) 
insert into schedule values ('20111102', 1, 1) 
insert into schedule values ('20111107', 1, 1) 
insert into schedule values ('20111109', 1, 1) 
insert into schedule values ('20111114', 1, 1) 
insert into schedule values ('20111116', 1, 1) 
insert into schedule values ('20111121', 1, 1) 
insert into schedule values ('20111123', 1, 1) 
insert into schedule values ('20111128', 1, 1)
insert into schedule values ('20111130', 1, 1)
insert into schedule values ('20111205', 1, 1) 
insert into schedule values ('20111207', 1, 1) 
insert into schedule values ('20111212', 1, 1) 
insert into schedule values ('20111214', 1, 1) 
insert into schedule values ('20111219', 1, 1) 
insert into schedule values ('20111221', 1, 1) 
insert into schedule values ('20111226', 1, 1)
insert into schedule values ('20111228', 1, 1)
insert into schedule values ('20120102', 1, 1) 
insert into schedule values ('20120104', 1, 1) 

insert into account values ( 's9220677', '1234', 1, 5) 
 insert into student values ('s9220677', 'Ha', 'Hong', 'Truong', 'M', 's9220677@rmit.edu.vn', 'BP138', '', 1)
 insert into account values ( 's9222055', '1234', 1, 5)  
insert into student values ('s9222055', 'Tran', 'Thi Giao', 'Ha', 'F', 's9222055@rmit.edu.vn', 'BP138', '', 1) 
insert into [dbo].[group] values ('2', 2, 1, 'ISYS2132', '2011C', 'v93333') 

insert into group_day values ('11:00:00', '14:00:00', 'Both', 1, 2, 1)  
insert into student_group values (NULL, NULL, NULL, 1, 2, 's9220677')  
insert into student_group values (NULL, NULL, NULL, 1, 2, 's9222055') 

insert into schedule values ('20111017', 1, 2) 
insert into schedule values ('20111024', 1, 2) 
insert into schedule values ('20111031', 1, 2) 
insert into schedule values ('20111107', 1, 2) 
insert into schedule values ('20111114', 1, 2) 
insert into schedule values ('20111121', 1, 2) 
insert into schedule values ('20111128', 1, 2) 
insert into schedule values ('20111205', 1, 2) 
insert into schedule values ('20111212', 1, 2) 
insert into schedule values ('20111219', 1, 2) 
insert into schedule values ('20111226', 1, 2) 
insert into schedule values ('20120102', 1, 2) 


--group 1 attendance



insert into student_schedule values ('absent', 1, 1, 's9220646') 
insert into student_schedule values ('present', 1, 1, 's9220658')
insert into student_schedule values ('present', 1, 2, 's9220646') 
insert into student_schedule values ('present', 1, 2, 's9220658')
insert into student_schedule values ('absent', 1, 3, 's9220658') 
insert into student_schedule values ('present', 1, 3, 's9220646')
insert into student_schedule values ('absent', 1, 4, 's9220658') 
insert into student_schedule values ('present', 1, 4, 's9220646')
insert into student_schedule values ('present', 1, 5, 's9220646') 
insert into student_schedule values ('present', 1, 5, 's9220658')
insert into student_schedule values ('present', 1, 6, 's9220646') 
insert into student_schedule values ('present', 1, 6, 's9220658')
insert into student_schedule values ('absent', 1, 7, 's9220658') 
insert into student_schedule values ('present', 1, 7, 's9220646')
insert into student_schedule values ('absent', 1, 8, 's9220646') 
insert into student_schedule values ('present', 1, 8, 's9220658')
insert into student_schedule values ('present', 1, 9, 's9220646') 
insert into student_schedule values ('present', 1, 9, 's9220658')
insert into student_schedule values ('present', 1, 10, 's9220646') 
insert into student_schedule values ('present', 1, 10, 's9220658')
insert into student_schedule values ('absent', 1, 11, 's9220658') 
insert into student_schedule values ('present', 1, 11, 's9220646')
insert into student_schedule values ('present', 1, 12, 's9220646') 
insert into student_schedule values ('present', 1, 12, 's9220658')
insert into student_schedule values ('present', 1, 13, 's9220646') 
insert into student_schedule values ('present', 1, 13, 's9220658')
insert into student_schedule values ('present', 1, 14, 's9220646') 
insert into student_schedule values ('present', 1, 14, 's9220658') 
insert into student_schedule values ('absent', 1, 15, 's9220658') 
insert into student_schedule values ('present', 1, 15, 's9220646')
insert into student_schedule values ('present', 1, 16, 's9220646') 
insert into student_schedule values ('present', 1, 16, 's9220658')
insert into student_schedule values ('present', 1, 17, 's9220646') 
insert into student_schedule values ('present', 1, 17, 's9220658')
insert into student_schedule values ('present', 1, 18, 's9220646') 
insert into student_schedule values ('present', 1, 18, 's9220658')
insert into student_schedule values ('absent', 1, 19, 's9220658') 
insert into student_schedule values ('present', 1, 19, 's9220646')
insert into student_schedule values ('present', 1, 20, 's9220646') 
insert into student_schedule values ('present', 1, 20, 's9220658')
insert into student_schedule values ('present', 1, 21, 's9220646') 
insert into student_schedule values ('present', 1, 21, 's9220658')
insert into student_schedule values ('absent', 1, 22, 's9220658') 
insert into student_schedule values ('present', 1, 22, 's9220646')
insert into student_schedule values ('present', 1, 23, 's9220646') 
insert into student_schedule values ('present', 1, 23, 's9220658')
insert into student_schedule values ('present', 1, 24, 's9220646') 
insert into student_schedule values ('present', 1, 24, 's9220658')


--group 2 2011c attendance


insert into student_schedule values ('present', 1, 25, 's9220677') 
insert into student_schedule values ('present', 1, 25, 's9222055')
insert into student_schedule values ('absent', 1, 26, 's9220677') 
insert into student_schedule values ('present', 1, 26, 's9222055')
insert into student_schedule values ('absent', 1, 27, 's9220677') 
insert into student_schedule values ('present', 1, 27, 's9222055')
insert into student_schedule values ('absent', 1, 28, 's9220677') 
insert into student_schedule values ('present', 1, 28, 's9222055')
insert into student_schedule values ('present', 1, 29, 's9220677') 
insert into student_schedule values ('present', 1, 29, 's9222055')
insert into student_schedule values ('absent', 1, 30, 's9222055') 
insert into student_schedule values ('present', 1, 30, 's9220677')
insert into student_schedule values ('absent', 1, 31, 's9220677') 
insert into student_schedule values ('present', 1, 31, 's9222055')
insert into student_schedule values ('present', 1, 32, 's9220677') 
insert into student_schedule values ('present', 1, 32, 's9222055')
insert into student_schedule values ('present', 1, 33, 's9220677') 
insert into student_schedule values ('present', 1, 33, 's9222055')
insert into student_schedule values ('absent', 1, 34, 's9220677') 
insert into student_schedule values ('present', 1, 34, 's9222055')
insert into student_schedule values ('present', 1, 35, 's9220677') 
insert into student_schedule values ('present', 1, 35, 's9222055')
insert into student_schedule values ('present', 1, 36, 's9220677') 
insert into student_schedule values ('present', 1, 36, 's9222055')

--group for 2012A


INSERT  INTO semester (semester_name, start_date, end_date, active) VALUES ('2012A','20120220','20120601','1')

insert into account values ( 's9231753', '1234', 1, 5)  
insert into student values ('s9231753', 'Pham', 'Sy Nhat', 'Nam', 'M', 's9231753@rmit.edu.vn', 'BP138', '', 1) 
insert into account values ( 's9245674', '1234', 1, 5)  
insert into student values ('s9245674', 'Pham', 'Phong', 'Phanh', 'F', 's9245674@rmit.edu.vn', 'BP138', '', 1) 
insert into account values ( 's9246044', '1234', 1, 5)  
insert into student values ('s9246044', 'Doan', 'Day', 'Da', 'F', 's9246044@rmit.edu.vn', 'BP138', '', 1) 
insert into [dbo].[group] values ('1', 3, 1, 'ISYS2424', '2012A', 'v91111') 

insert into group_day values ('16:00:00', '19:00:00', 'Both', 1, 3, 1)  
insert into student_group values (NULL, NULL, NULL, 1, 3, 's9231753')  
insert into student_group values (NULL, NULL, NULL, 1, 3, 's9245674')  
insert into student_group values (NULL, NULL, NULL, 1, 3, 's9246044') 

insert into schedule values ('20120220', 1, 3) 
insert into schedule values ('20120227', 1, 3) 
insert into schedule values ('20120305', 1, 3) 
insert into schedule values ('20120312', 1, 3) 
insert into schedule values ('20120319', 1, 3) 
insert into schedule values ('20120326', 1, 3) 
insert into schedule values ('20120402', 1, 3) 
insert into schedule values ('20120409', 1, 3) 
insert into schedule values ('20120416', 1, 3) 
insert into schedule values ('20120423', 1, 3) 
insert into schedule values ('20120430', 1, 3) 
insert into schedule values ('20120507', 1, 3)


insert into student_schedule values ('absent', 1, 37, 's9231753')
insert into student_schedule values ('present', 1, 37, 's9245674')
insert into student_schedule values ('present', 1, 37, 's9246044')
insert into student_schedule values ('absent', 1, 38, 's9246044')
insert into student_schedule values ('present', 1, 38, 's9231753')
insert into student_schedule values ('present', 1, 38, 's9245674')



