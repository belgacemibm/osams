

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
CREATE TABLE dbo.lecturer(
	lecturer_id varchar(10) NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES account(user_name),
	family_name varchar(500) NULL,
	middle_name varchar(500) NULL,
	given_name varchar(500) NULL,
	gender varchar(1) NOT NULL,
	email varchar(500) NULL,
	active bit NULL
	)
CREATE TABLE dbo.day_of_week(
	day_id int NOT NULL PRIMARY KEY,
	day varchar(500) NOT NULL,
	active bit NULL
	)


CREATE TABLE dbo.course
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
values ('v00000', 'Vo', 'Ngoc', 'Diep', 'M', 's3231181@rmit.edu.vn', 1)



--sample data



insert into semester
values ('2011C', '2011-10-17', '2012-01-21', 1)
insert into semester
values ('2012A', '2012-02-20', '2012-05-30', 1)
insert into course
values ('ISYS2132', 'Capstone Project', 12, 'Bachelor', 1)
insert into course
values ('BAFI3184', 'Business Finance', 12, 'Bachelor', 1)
insert into account
VALUES ('v92345', '1234', 1, 3)
insert into account
VALUES ('v91111', '1234', 1, 3)
insert into account
VALUES ('v92222', '1234', 1, 4)
insert into lecturer
values ('v92345', 'Nelson', '', 'Leung', 'M', 's3220658@rmit.edu.vn', 1)
insert into lecturer
values ('v91111', 'James', '', 'Murphy', 'M', 's3220658@rmit.edu.vn', 1)
insert into lecturer
values ('v92222', 'Pierre', '', 'Rostan', 'M', 's3220658@rmit.edu.vn', 1)
insert into account
VALUES ('s9220658', '1234', 1, 5)
insert into account
VALUES ('s9220670', '1234', 1, 5)
insert into account
VALUES ('s9220677', '1234', 1, 5)
insert into account
VALUES ('s9231181', '1234', 1, 5)
insert into account
VALUES ('s9246051', '1234', 1, 5)
insert into student
values ('s9220658', 'Nguyen', 'Ly', 'Nam', 'M', 's3220658@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s9220670', 'Nguyen', 'Tran Dang', 'Khoa', 'M', 's3220670@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s9220677', 'Ha', 'Hong', 'Truong', 'M', 's3220677@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s9231181', 'Nguyen', 'Duc Hai', 'Duong', 'M', 's3231181@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s9246051', 'Vo', 'Ngoc', 'Diep', 'F', 's3246051@rmit.edu.vn', 'BP181', 'M', 1)



insert into [dbo].[group] values ('1', 4, 1, 'ISYS2132', '2012A', 'v91111') 
insert into group_day values ('08:00:00', '11:00:00', 'Lecture', 1, 1, 1)  
insert into group_day values ('07:00:00', '09:00:00', 'Tutorial', 1, 1, 3)  
insert into student_group values (NULL, NULL, NULL, 1, 1, 's9220658')  
insert into student_group values (NULL, NULL, NULL, 1, 1, 's9220670')  
insert into student_group values (NULL, NULL, NULL, 1, 1, 's9220677')    
insert into student_group values (NULL, NULL, NULL, 1, 1, 's9231181')  


insert into schedule values ('20120220', 1, 1)
insert into schedule values ('20120222', 1, 1)
insert into schedule values ('20120227', 1, 1) 
insert into schedule values ('20120229', 1, 1)
insert into schedule values ('20120305', 1, 1) 
insert into schedule values ('20120307', 1, 1) 
insert into schedule values ('20120312', 1, 1)
insert into schedule values ('20120314', 1, 1) 
insert into schedule values ('20120319', 1, 1) 
insert into schedule values ('20120321', 1, 1) 
insert into schedule values ('20120326', 1, 1)
insert into schedule values ('20120328', 1, 1) 
insert into schedule values ('20120402', 1, 1) 
insert into schedule values ('20120404', 1, 1) 
insert into schedule values ('20120409', 1, 1) 
insert into schedule values ('20120411', 1, 1) 
insert into schedule values ('20120416', 1, 1) 
insert into schedule values ('20120418', 1, 1) 
insert into schedule values ('20120423', 1, 1) 
insert into schedule values ('20120425', 1, 1) 
insert into schedule values ('20120430', 1, 1) 
insert into schedule values ('20120502', 1, 1) 
insert into schedule values ('20120507', 1, 1) 
insert into schedule values ('20120509', 1, 1) 




insert into [dbo].[group]
values ('1', 1, 1, 'BAFI3184', '2011C', 'v92222')
insert into group_day
values ('10:00:00', '13:00:00', 'both', 1, 2, 3)




insert into student_group
values (NULL, NULL, NULL, 1, 2, 's9220658')


insert into schedule
values ('2011-10-17', 1, 2)
insert into schedule
values ('2011-10-24', 1, 2)
insert into schedule
values ('2011-10-31', 1, 2)
insert into schedule
values ('2011-11-07', 1, 2)
insert into schedule
values ('2011-11-14', 1, 2)
insert into schedule
values ('2011-11-21', 1, 2)
insert into schedule
values ('2011-11-28', 1, 2)
insert into schedule
values ('2011-12-05', 1, 2)
insert into schedule
values ('2011-12-12', 1, 2)
insert into schedule
values ('2011-12-19', 1, 2)
insert into schedule
values ('2011-12-26', 1, 2)
insert into schedule
values ('2012-01-02', 1, 2)

insert into account
VALUES ('v00001', '1234', 1, 2)
insert into [dbo].[admin]
values ('v00001', 'Truong', 'Vo', 'Ky', 'M', 's3246051@rmit.edu.vn', 1)
insert into account
VALUES ('v00002', '1234', 1, 2)
insert into [dbo].[admin]
values ('v00002', 'Trinh', 'Cong', 'Son', 'M', 's3246051@rmit.edu.vn', 1)



insert into student_schedule
values ('present', 1, 25, 's9220658')
insert into student_schedule
values ('present', 1, 26, 's9220658')
insert into student_schedule
values ('present', 1, 27, 's9220658')
insert into student_schedule
values ('present', 1, 28, 's9220658')
insert into student_schedule
values ('present', 1, 29, 's9220658')
insert into student_schedule
values ('present', 1, 30, 's9220658')
insert into student_schedule
values ('absent', 1, 31, 's9220658')
insert into student_schedule
values ('present', 1, 32, 's9220658')
insert into student_schedule
values ('present', 1, 33, 's9220658')
insert into student_schedule
values ('present', 1, 34, 's9220658')
insert into student_schedule
values ('present', 1, 35, 's9220658')
insert into student_schedule
values ('present', 1, 36, 's9220658')



insert into student_schedule
values ('present', 1, 1, 's9220658')
insert into student_schedule
values ('present', 1, 2, 's9220658')
insert into student_schedule
values ('present', 1, 3, 's9220658')
insert into student_schedule
values ('present', 1, 4, 's9220658')
insert into student_schedule
values ('present', 1, 5, 's9220658')
insert into student_schedule
values ('present', 1, 6, 's9220658')


insert into student_schedule
values ('present', 1, 1, 's9220670')
insert into student_schedule
values ('present', 1, 2, 's9220670')
insert into student_schedule
values ('present', 1, 3, 's9220670')
insert into student_schedule
values ('present', 1, 4, 's9220670')
insert into student_schedule
values ('present', 1, 5, 's9220670')
insert into student_schedule
values ('present', 1, 6, 's9220670')


insert into student_schedule
values ('present', 1, 1, 's9220677')
insert into student_schedule
values ('present', 1, 2, 's9220677')
insert into student_schedule
values ('present', 1, 3, 's9220677')
insert into student_schedule
values ('present', 1, 4, 's9220677')
insert into student_schedule
values ('present', 1, 5, 's9220677')
insert into student_schedule
values ('present', 1, 6, 's9220677')


insert into student_schedule
values ('present', 1, 1, 's9231181')
insert into student_schedule
values ('present', 1, 2, 's9231181')
insert into student_schedule
values ('present', 1, 3, 's9231181')
insert into student_schedule
values ('present', 1, 4, 's9231181')
insert into student_schedule
values ('present', 1, 5, 's9231181')
insert into student_schedule
values ('present', 1, 6, 's9231181')






