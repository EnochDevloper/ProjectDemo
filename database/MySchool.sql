use MySchool
go

if Exists (select * from sys.objects where name='Grade')
drop table Grade
go
create table Grade
(
ID uniqueidentifier primary key,
GradeName varchar(50),
GradeCreateDate datetime,
GradeIsDelete bit,
GradeReamrk text,
)
insert into Grade select NEWID(),'一年级',GETDATE(),0,''
union all select NEWID(), '二年级',GETDATE(),0,''
union all select NEWID(),'三年级',GETDATE(),0,''
go


if exists (select * from sys.objects where name='Student')
drop table Student
go
create table Student
(
s_id uniqueidentifier primary key,
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
)
go
insert into Student select NEWID(),N'张楚', N'zhangchu', N'123456', N'重庆', 0, 19, N'13635842365', 0, N'爱耍小聪明', '2017-08-21 15:22:18.753', (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'李阳', N'liyang', N'123456', N'北京', 0, 20, N'13998213628', 0, N'脾气温和的好人','2016-12-22 10:39:52.656', (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'杨涵', N'yanghan', N'123456', N'上海', 0, 21, N'18736522854', 1, N'又是一个富二代', '2016-08-05 09:55:12.354',  (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'周梦飞', N'zhoumf', N'123456', N'南京', 0, 21, N'18998522247', 1, N'刚从国外留学回来', '2017-03-18 08:36:28.567',  (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'余瑶', N'yuyao', N'123456', N'广州', 1, 19, N'13169852364', 0, N'学习成绩比较好，简称学霸', '2015-10-01 00:53:00.214', (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'何汉阳', N'hehanyang', N'123456', N'三亚', 0, 20, N'18954753698', 1, N'外省过来的朋友', '2015-02-03 07:06:47.250',  (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'冷月', N'lengyue', N'123456', N'台北', 1, 22, N'15987463698', 1, N'喜欢游泳，平时喜欢健身','2017-05-29 18:16:57.106',  (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'向勇', N'xiangyong', N'123456', N'天津', 0, 18, N'13336589854', 1, N'校学生会主席', '2017-02-08 09:35:48.687',   (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'范雪', N'fanxue', N'123456', N'深圳', 1, 18, N'13996859742', 0, N'在学校附近租的房子','2015-11-23 23:56:37.548',  (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'刘晴冰', N'liuqingbing', N'123456', N'青岛', 1, 25, N'18998523647', 1, N'比较时尚的一个学生','2016-07-11 15:16:29.354',  (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'张莉', N'zhangli', N'123456', N'福州', 1, 22, N'15963587935', 1, N'有着很强的独立生活性','2016-11-08 12:59:47.876',  (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'秦羽', N'qinyu', N'123456', N'深圳', 0, 22, N'13635248632', 1, N'很喜欢运动的一个学生', '2017-08-12 11:03:22.798', (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'徐梦蝶', N'xumengdie', N'123456', N'杭州', 1, 19, N'18985499635', 1, N'独立 坚强 自学成才', '2018-02-19 01:45:00.320', (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'刘如轩', N'liuruxuan', N'123456', N'重庆', 1, 18, N'13778546952', 1, N'梦想成为一个发明家', '2017-05-23 06:08:19.095', (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'薛如珊', N'xuerushan', N'123456', N'大连', 1, 22, N'13998725642', 0, N'希望能有一家自己的公司','2016-12-26 02:49:58.185',  (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'刘青', N'liuqing', N'123456', N'成都', 1, 26, N'15922593584', 1, N'在电脑方面有很高的天分','2018-05-03 19:02:59.037',   (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'李梦雪', N'limengxue', N'123456', N'郑州', 1, 17, N'13202360485', 1, N'贪玩 玩游戏是一个高手', '2016-02-28 18:28:22.268',  (select ID from Grade where GradeName='一年级')
union all select NEWID(),N'萧别离', N'xiaobieli', N'123456', N'长沙', 0, 25, N'18336599542', 0, N'曾经在少林寺学过武术', '2018-01-15 21:21:30.598',  (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'陈可辛', N'chenkexin', N'123456', N'武汉', 0, 23, N'13436146356', 1, N'喜欢开玩笑的一个人 幽默', '2017-11-08 16:45:19.531',  (select ID from Grade where GradeName='三年级')
union all select NEWID(),N'许如梦', N'xurumeng', N'123456', N'上海', 1, 22, N'13336220354', 1, N'朴树 老实的一个学生', '2018-07-12 09:00:49.359',   (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'张波', N'zhangbo', N'123456', N'被禁', 0, 20, N'13102366357', 1, N'家道中落 奋发图强', '2018-04-05 05:03:37.294',  (select ID from Grade where GradeName='二年级')
union all select NEWID(),N'孟浩', N'menghao', N'123456', N'南京', 0, 21, N'13635843026', 1, N'在外做兼职  自给自足', '2017-06-19 00:26:38.639',   (select ID from Grade where GradeName='二年级')
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
insert into Constellation select N'白羊座', N'白羊座.gif', 0, 0, N''
union all select N'金牛座', N'金牛座.gif', 0, 0, N''
union all select N'双子座', N'双子座.gif', 0, 0, N''
union all select N'巨蟹座', N'巨蟹座.gif', 0, 0, N''
union all select N'狮子座', N'狮子座.gif', 0, 0, N''
union all select N'处女座', N'处女座.gif', 0, 0, N''
union all select N'天秤座', N'天秤座.gif', 0, 0, N''
union all select N'天蝎座', N'天蝎座.gif', 0, 0, N''
union all select N'射手座', N'射手座.gif', 0, 0, N''
union all select N'魔蝎座', N'魔蝎座.gif', 0, 0, N''
union all select N'水瓶座', N'水瓶座.gif', 0, 0, N''
union all select N'双鱼座', N'双鱼座.gif', 0, 0, N''
go

if exists (select * from sys.objects where name='Company')
drop table Company
go
create table Company
(
CompanyID uniqueidentifier primary key,
CompanyName varchar(50),
PId uniqueidentifier,
CreateDate datetime,
IsDelete bit
)
select * from Company
go
insert into Company values(NEWID(),'公司总部','00000000-0000-0000-0000-000000000000',GETDATE(),0)
go
insert into Company values(NEWID(),'北京分部',(select CompanyID from Company where CompanyName='公司总部'),GETDATE(),0)
go
insert into Company values(NEWID(),'上海分部',(select CompanyID from Company where CompanyName='公司总部'),GETDATE(),0)
go
insert into Company values(NEWID(),'重庆分部',(select CompanyID from Company where CompanyName='公司总部'),GETDATE(),0)
go
insert into Company values(NEWID(),'策划部',(select CompanyID from Company where CompanyName='上海分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'销售部',(select CompanyID from Company where CompanyName='上海分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'统筹部',(select CompanyID from Company where CompanyName='上海分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'人事部',(select CompanyID from Company where CompanyName='北京分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'IT部',(select CompanyID from Company where CompanyName='北京分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'营销部',(select CompanyID from Company where CompanyName='北京分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'工程部',(select CompanyID from Company where CompanyName='重庆分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'财务部',(select CompanyID from Company where CompanyName='重庆分部'),GETDATE(),0)
go
insert into Company values(NEWID(),'行政部',(select CompanyID from Company where CompanyName='重庆分部'),GETDATE(),0)
go

select * from Student
go

select * from Company
go

select* from Constellation
go

select * from Grade
go

--truncate table Student
go
select * from Student
go


