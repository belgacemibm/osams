
CREATE TABLE dbo.student(
	student_id varchar(10) NOT NULL PRIMARY KEY,
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
	lecturer_id varchar(10) NOT NULL PRIMARY KEY,
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
CREATE TABLE dbo.admin(
	staff_id varchar(10) NOT NULL PRIMARY KEY,
	family_name varchar(500) NULL,
	middle_name varchar(500) NULL,
	given_name varchar(500) NULL,
	gender varchar(1) NOT NULL,
	email varchar(500) NULL,
	active bit NULL
	)
CREATE TABLE dbo.account_type(
	account_type_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	account_type varchar(500) NOT NULL,
	active bit NULL
	)
CREATE TABLE dbo.account(
	account_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	user_name varchar(10) NOT NULL,
	password varchar(500) NOT NULL,
	active bit NULL,
	account_type_id int NOT NULL FOREIGN KEY REFERENCES dbo.account_type(account_type_id)
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
values ('super_admin', 1)
insert into account_type
values ('admin', 2)
insert into account_type
values ('Senior Lecturer', 3)
insert into account_type
values ('Lecturer', 4)
insert into account_type
values ('student', 5)
insert into account
VALUES ('v00000', '1234', 1, 1)
insert into [dbo].[admin]
values ('v00000', 'Vo', 'Ngoc', 'Diep', 'M', 's3246051@rmit.edu.vn', 1)
insert into semester
values ('2011C', '2011-10-17', '2012-01-21', 1)
insert into semester
values ('2012A', '2012-02-20', '2012-05-30', 1)
insert into course
values ('ISYS2132', 'Capstone Project', 12, 'Bachelor', 1)
insert into course
values ('BAFI3184', 'Business Finance', 12, 'Bachelor', 1)
insert into lecturer
values ('v12345', 'Nelson', '', 'Leung', 'M', 's3246051@rmit.edu.vn', 1)
insert into lecturer
values ('v11111', 'James', '', 'Murphy', 'M', 's3246051@rmit.edu.vn', 1)
insert into lecturer
values ('v22222', 'Pierre', '', 'Rostan', 'M', 's3246051@rmit.edu.vn', 1)
insert into account
VALUES ('v12345', '1234', 1, 3)
insert into account
VALUES ('v11111', '1234', 1, 3)
insert into account
VALUES ('v22222', '1234', 1, 4)
insert into [dbo].[group]
values ('1', 2, 1, 'ISYS2132', '2012A', 'v12345')
insert into [dbo].[group]
values ('1', 2, 1, 'BAFI3184', '2012A', 'v11111')
insert into [dbo].[group]
values ('2', 2, 1, 'BAFI3184', '2012A', 'v22222')
insert into [dbo].[group]
values ('1', 1, 1, 'BAFI3184', '2011C', 'v22222')
insert into group_day
values ('10:00:00', '13:00:00', 'both', 1, 1, 3)
insert into group_day
values ('09:00:00', '10:30:00', 'lecture', 1, 2, 1)
insert into group_day
values ('09:00:00', '10:30:00', 'tutorial',1, 2, 4)
insert into group_day
values ('15:00:00', '16:30:00', 'lecture', 1, 3, 1)
insert into group_day
values ('15:00:00', '16:30:00', 'tutorial',1, 3, 5)
insert into group_day
values ('15:00:00', '18:00:00', 'both', 1, 4, 1)
insert into student
values ('s3220658', 'Nguyen', 'Ly', 'Nam', 'M', 's3220658@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s3220670', 'Nguyen', 'Tran Dang', 'Khoa', 'M', 's3220670@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s3220677', 'Ha', 'Hong', 'Truong', 'M', 's3220677@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s3231181', 'Nguyen', 'Duc Hai', 'Duong', 'M', 's3231181@rmit.edu.vn', 'BP138', '', 1)
insert into student
values ('s3246051', 'Vo', 'Ngoc', 'Diep', 'M', 's3246051@rmit.edu.vn', 'BP181', 'M', 1)
insert into account
VALUES ('s3220658', '1234', 1, 5)
insert into account
VALUES ('s3220670', '1234', 1, 5)
insert into account
VALUES ('s3220677', '1234', 1, 5)
insert into account
VALUES ('s3231181', '1234', 1, 5)
insert into account
VALUES ('s3246051', '1234', 1, 5)
insert into student_group
values (NULL, NULL, NULL, 1, 1, 's3220658')
insert into student_group
values (NULL, NULL, NULL, 1, 1, 's3220670')
insert into student_group
values (NULL, NULL, NULL, 1, 2, 's3220658')
insert into student_group
values (NULL, NULL, NULL, 1, 3, 's3220677')
insert into student_group
values (NULL, NULL, NULL, 1, 2, 's3231181')
insert into student_group
values (NULL, NULL, NULL, 1, 3, 's3246051')
insert into student_group
values (NULL, NULL, NULL, 1, 4, 's3246051')
insert into schedule
values ('2011-10-17', 1, 4)
insert into schedule
values ('2011-10-24', 1, 4)
insert into schedule
values ('2011-10-31', 1, 4)
insert into schedule
values ('2011-11-07', 1, 4)
insert into schedule
values ('2011-11-14', 1, 4)
insert into schedule
values ('2011-11-21', 1, 4)
insert into schedule
values ('2011-11-28', 1, 4)
insert into schedule
values ('2011-12-05', 1, 4)
insert into schedule
values ('2011-12-12', 1, 4)
insert into schedule
values ('2011-12-19', 1, 4)
insert into schedule
values ('2011-12-26', 1, 4)
insert into schedule
values ('2012-01-02', 1, 4)
insert into student_schedule
values ('present', 1, 1, 's3246051')
insert into student_schedule
values ('present', 1, 2, 's3246051')
insert into student_schedule
values ('present', 1, 3, 's3246051')
insert into student_schedule
values ('absent', 1, 4, 's3246051')
insert into student_schedule
values ('present', 1, 5, 's3246051')
insert into student_schedule
values ('present', 1, 6, 's3246051')
insert into student_schedule
values ('absent', 1, 7, 's3246051')
insert into student_schedule
values ('present', 1, 8, 's3246051')
insert into student_schedule
values ('absent', 1, 9, 's3246051')
insert into student_schedule
values ('present', 1, 10, 's3246051')
insert into student_schedule
values ('absent', 1, 11, 's3246051')
insert into student_schedule
values ('present', 1, 12, 's3246051')
insert into schedule
values ('2012-02-22', 1, 1)
insert into schedule
values ('2012-02-29', 1, 1)
insert into schedule
values ('2012-03-07', 1, 1)
insert into schedule
values ('2012-03-14', 1, 1)
insert into schedule
values ('2012-03-21', 1, 1)
insert into schedule
values ('2012-03-28', 1, 1)
insert into schedule
values ('2012-04-04', 1, 1)
insert into schedule
values ('2012-04-11', 1, 1)
insert into schedule
values ('2012-04-18', 1, 1)
insert into schedule
values ('2012-04-25', 1, 1)
insert into schedule
values ('2012-05-02', 1, 1)
insert into schedule
values ('2012-05-09', 1, 1)
insert into student_schedule
values ('present', 1, 13, 's3220658')
insert into student_schedule
values ('present', 1, 14, 's3220658')
insert into student_schedule
values ('present', 1, 15, 's3220658')
insert into student_schedule
values ('absent', 1, 16, 's3220658')
insert into student_schedule
values ('present', 1, 17, 's3220658')


insert into student_schedule
values ('present', 1, 13, 's3220670')
insert into student_schedule
values ('present', 1, 14, 's3220670')
insert into student_schedule
values ('present', 1, 15, 's3220670')
insert into student_schedule
values ('present', 1, 16, 's3220670')
insert into student_schedule
values ('present', 1, 17, 's3220670')



insert into account
VALUES ('v00001', '1234', 1, 2)
insert into [dbo].[admin]
values ('v00001', 'Truong', 'Vo', 'Ky', 'M', 's3246051@rmit.edu.vn', 1)
insert into account
VALUES ('v00002', '1234', 1, 2)
insert into [dbo].[admin]
values ('v00002', 'Trinh', 'Cong', 'Son', 'M', 's3246051@rmit.edu.vn', 1)