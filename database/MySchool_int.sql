use MySchool
go

if exists (select * from sys.objects where name='Student')
drop table Student
go
create table Student
(
s_id int primary key identity,
s_name varchar(50),
s_loginName varchar(50),
s_passWord varchar(50),
s_address varchar(200),
s_sex tinyint,
s_age int,
s_phone varchar(20),
s_status tinyint,
s_remark text,
s_createDate datetime,
s_Grade_ID uniqueidentifier,
s_GradeID int
)
go
insert into Student select N'�ų�', N'zhangchu', N'123456', N'����', 0, 19, N'13635842365', 0, N'��ˣС����', '2017-08-21 15:22:18.753', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'����', N'liyang', N'123456', N'����', 0, 20, N'13998213628', 0, N'Ƣ���º͵ĺ���','2016-12-22 10:39:52.656', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'�', N'yanghan', N'123456', N'�Ϻ�', 0, 21, N'18736522854', 1, N'����һ��������', '2016-08-05 09:55:12.354',  N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'���η�', N'zhoumf', N'123456', N'�Ͼ�', 0, 21, N'18998522247', 1, N'�մӹ�����ѧ����', '2017-03-18 08:36:28.567', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'����', N'yuyao', N'123456', N'����', 1, 19, N'13169852364', 0, N'ѧϰ�ɼ��ȽϺã����ѧ��', '2015-10-01 00:53:00.214', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'�κ���', N'hehanyang', N'123456', N'����', 0, 20, N'18954753698', 1, N'��ʡ����������', '2015-02-03 07:06:47.250', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'����', N'lengyue', N'123456', N'̨��', 1, 22, N'15987463698', 1, N'ϲ����Ӿ��ƽʱϲ������','2017-05-29 18:16:57.106', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'����', N'xiangyong', N'123456', N'���', 0, 18, N'13336589854', 1, N'Уѧ������ϯ', '2017-02-08 09:35:48.687', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'��ѩ', N'fanxue', N'123456', N'����', 1, 18, N'13996859742', 0, N'��ѧУ������ķ���','2015-11-23 23:56:37.548', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'�����', N'liuqingbing', N'123456', N'�ൺ', 1, 25, N'18998523647', 1, N'�Ƚ�ʱ�е�һ��ѧ��','2016-07-11 15:16:29.354', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'����', N'zhangli', N'123456', N'����', 1, 22, N'15963587935', 1, N'���ź�ǿ�Ķ���������','2016-11-08 12:59:47.876', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'����', N'qinyu', N'123456', N'����', 0, 22, N'13635248632', 1, N'��ϲ���˶���һ��ѧ��', '2017-08-12 11:03:22.798', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'���ε�', N'xumengdie', N'123456', N'����', 1, 19, N'18985499635', 1, N'���� ��ǿ ��ѧ�ɲ�', '2018-02-19 01:45:00.320', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'������', N'liuruxuan', N'123456', N'����', 1, 18, N'13778546952', 1, N'�����Ϊһ��������', '2017-05-23 06:08:19.095', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'Ѧ��ɺ', N'xuerushan', N'123456', N'����', 1, 22, N'13998725642', 0, N'ϣ������һ���Լ��Ĺ�˾','2016-12-26 02:49:58.185', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'����', N'liuqing', N'123456', N'�ɶ�', 1, 26, N'15922593584', 1, N'�ڵ��Է����кܸߵ����','2018-05-03 19:02:59.037', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'����ѩ', N'limengxue', N'123456', N'֣��', 1, 17, N'13202360485', 1, N'̰�� ����Ϸ��һ������', '2016-02-28 18:28:22.268', N'5d6d773b-e702-44f6-9a17-8653edb750ec', 1
union all select N'������', N'xiaobieli', N'123456', N'��ɳ', 0, 25, N'18336599542', 0, N'������������ѧ������', '2018-01-15 21:21:30.598', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'�¿���', N'chenkexin', N'123456', N'�人', 0, 23, N'13436146356', 1, N'ϲ������Ц��һ���� ��Ĭ', '2017-11-08 16:45:19.531', N'8977c3af-1d71-4553-b431-5da584fdbdc1', 3
union all select N'������', N'xurumeng', N'123456', N'�Ϻ�', 1, 22, N'13336220354', 1, N'���� ��ʵ��һ��ѧ��', '2018-07-12 09:00:49.359', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'�Ų�', N'zhangbo', N'123456', N'����', 0, 20, N'13102366357', 1, N'�ҵ����� �ܷ�ͼǿ', '2018-04-05 05:03:37.294', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
union all select N'�Ϻ�', N'menghao', N'123456', N'�Ͼ�', 0, 21, N'13635843026', 1, N'��������ְ  �Ը�����', '2017-06-19 00:26:38.639', N'b9293e23-8bac-4513-a074-b988cbc498b4', 2
go

if exists (select * from sys.objects where name='Constellation')
drop table Constellation
go
create table Constellation
(
cid int primary key identity,
cname varchar(50),
cimage varchar(100),
cisshow bit,
csort int,
cremark text
)
insert into Constellation select N'������', N'������.gif', 0, 0, N''
union all select N'��ţ��', N'��ţ��.gif', 0, 0, N''
union all select N'˫����', N'˫����.gif', 0, 0, N''
union all select N'��з��', N'��з��.gif', 0, 0, N''
union all select N'ʨ����', N'ʨ����.gif', 0, 0, N''
union all select N'��Ů��', N'��Ů��.gif', 0, 0, N''
union all select N'�����', N'�����.gif', 0, 0, N''
union all select N'��Ы��', N'��Ы��.gif', 0, 0, N''
union all select N'������', N'������.gif', 0, 0, N''
union all select N'ħЫ��', N'ħЫ��.gif', 0, 0, N''
union all select N'ˮƿ��', N'ˮƿ��.gif', 0, 0, N''
union all select N'˫����', N'˫����.gif', 0, 0, N''
go

if Exists (select * from sys.objects where name='Grade')
drop table Grade
go
create table Grade
(
GradeID int primary key identity,
GradeName varchar(50),
GradeCreateDate datetime,
GradeIsDelete bit,
GradeReamrk text,
ID uniqueidentifier
)
insert into Grade select 'һ�꼶',GETDATE(),0,'','5D6D773B-E702-44F6-9A17-8653EDB750EC'
union all select '���꼶',GETDATE(),0,'','B9293E23-8BAC-4513-A074-B988CBC498B4'
union all select '���꼶',GETDATE(),0,'','8977C3AF-1D71-4553-B431-5DA584FDBDC1'
go


if exists (select * from sys.objects where name='Company')
drop table Company
go
create table Company
(
CompanyID int identity primary key,
CompanyName varchar(50),
PId int,
CreateDate datetime,
IsDelete bit
)

insert into Company values('��˾�ܲ�',0,GETDATE(),0)
go
insert into Company values('�����ֲ�',1,GETDATE(),0)
go
insert into Company values('�Ϻ��ֲ�',1,GETDATE(),0)
go
insert into Company values('����ֲ�',1,GETDATE(),0)
go
insert into Company values('�߻���',2,GETDATE(),0)
go
insert into Company values('���۲�',2,GETDATE(),0)
go
insert into Company values('ͳ�ﲿ',2,GETDATE(),0)
go
insert into Company values('���²�',3,GETDATE(),0)
go
insert into Company values('IT��',3,GETDATE(),0)
go
insert into Company values('Ӫ����',3,GETDATE(),0)
go
insert into Company values('���̲�',4,GETDATE(),0)
go
insert into Company values('����',4,GETDATE(),0)
go
insert into Company values('������',4,GETDATE(),0)
go

select * from Student
go

select * from Company
go

select* from Constellation
go

select * from Grade
go

truncate table Student
go
select * from Student
go


