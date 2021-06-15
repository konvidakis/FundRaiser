USE [FundRaiser]
GO

DELETE FROM Transactions;
DBCC CHECKIDENT ('Transactions', RESEED, 0)
DELETE FROM Rewards;
DBCC CHECKIDENT ('Rewards', RESEED, 0)
DELETE FROM ProjectPosts;
DBCC CHECKIDENT ('ProjectPosts', RESEED, 0)
DELETE FROM Projects;
DBCC CHECKIDENT ('Projects', RESEED, 0)
DELETE FROM Users;
DBCC CHECKIDENT ('Users', RESEED, 0)


INSERT INTO [dbo].[Users] ([FirstName],[LastName],[Email]) VALUES ('Faith','Poole','faith.poole@gmail.com')
INSERT INTO [dbo].[Users] ([FirstName],[LastName],[Email]) VALUES ('Eric','Nolan','eric.nolan@gmail.com')
INSERT INTO [dbo].[Users] ([FirstName],[LastName],[Email]) VALUES ('Maria','Randall','maria.randall@gmail.com')
INSERT INTO [dbo].[Users] ([FirstName],[LastName],[Email]) VALUES ('Irene','Bell','irene.bell@gmail.com')
INSERT INTO [dbo].[Users] ([FirstName],[LastName],[Email]) VALUES ('Gabrielle','Thomson','gabrielle.thomson@gmail.com')

INSERT INTO [dbo].[Projects] ([Category],[Title],[Logo],[TimeStamp],[Description],[SetGoal],[AmountPledged],[StartDate],[EndDate],[UserId]) VALUES (0,'ProjectByFaith','projectLogo1.jpg','2019-02-23 20:00','Art is fun','100','20','2018-02-23 20:00','2021-02-23 20:00',1)
INSERT INTO [dbo].[Projects] ([Category],[Title],[Logo],[TimeStamp],[Description],[SetGoal],[AmountPledged],[StartDate],[EndDate],[UserId]) VALUES (1,'ProjectByEric','projectLogo2.png','2019-02-24 20:00','Enviroment is fun','100','80','2018-02-24 20:00','2021-02-24 20:00',2)
INSERT INTO [dbo].[Projects] ([Category],[Title],[Logo],[TimeStamp],[Description],[SetGoal],[AmountPledged],[StartDate],[EndDate],[UserId]) VALUES (2,'ProjectByMaria','projectLogo3.png','2019-02-25 20:00','Games is fun','100','0','2018-02-25 20:00','2021-02-25 20:00',3)
INSERT INTO [dbo].[Projects] ([Category],[Title],[Logo],[TimeStamp],[Description],[SetGoal],[AmountPledged],[StartDate],[EndDate],[UserId]) VALUES (3,'ProjectByIrene','projectLogo4.jpg','2019-02-26 20:00','Tech is fun','100','30','2018-02-26 20:00','2021-02-26 20:00',4)
INSERT INTO [dbo].[Projects] ([Category],[Title],[Logo],[TimeStamp],[Description],[SetGoal],[AmountPledged],[StartDate],[EndDate],[UserId]) VALUES (4,'ProjectByGabrielle','projectLogo5.jpg','2019-02-27 20:00','Music is fun','100','0','2018-02-27 20:00','2021-02-27 20:00',5)

INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product','You get the product with this reward.','20',1)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product + T-Shirt','You get the product with this reward.','30',1)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product','You get the product with this reward.','20',2)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product + T-Shirt','You get the product with this reward.','30',2)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product','You get the product with this reward.','20',3)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product + T-Shirt','You get the product with this reward.','30',3)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product','You get the product with this reward.','20',4)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product + T-Shirt','You get the product with this reward.','30',4)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product','You get the product with this reward.','20',5)
INSERT INTO [dbo].[Rewards] ([Title],[Description],[AmountRequired],[ProjectId]) VALUES ('Product + T-Shirt','You get the product with this reward.','30',5)

INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('Thank you everyone! The project is doing great','projectPostImage1.jpg','2020-02-3 20:00',1)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('New Project Post! Thank you everyone for supporting this project','projectPostImage2.jpg','2020-02-10 20:00',1)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('Thank you everyone! The project is doing great','projectPostImage1.jpg','2020-02-3 20:00',2)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('New Project Post! Thank you everyone for supporting this project','projectPostImage2.jpg','2020-02-10 20:00',2)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('Thank you everyone! The project is doing great','projectPostImage1.jpg','2020-02-3 20:00',3)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('New Project Post! Thank you everyone for supporting this project','projectPostImage2.jpg','2020-02-10 20:00',3)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('Thank you everyone! The project is doing great','projectPostImage1.jpg','2020-02-3 20:00',4)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('New Project Post! Thank you everyone for supporting this project','projectPostImage2.jpg','2020-02-10 20:00',4)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('Thank you everyone! The project is doing great','projectPostImage1.jpg','2020-02-3 20:00',5)
INSERT INTO [dbo].[ProjectPosts] ([Text],[Multimedia],[TimeStamp],[ProjectId]) VALUES ('New Project Post! Thank you everyone for supporting this project','projectPostImage2.jpg','2020-02-10 20:00',5)


INSERT INTO [dbo].[Transactions] ([Amount],[TimeStamp],[RewardId],[UserId],[ProjectId]) VALUES ('20','2020-02-10 20:00',3,1,2)
INSERT INTO [dbo].[Transactions] ([Amount],[TimeStamp],[RewardId],[UserId],[ProjectId]) VALUES ('30','2020-02-10 20:00',8,1,4)

INSERT INTO [dbo].[Transactions] ([Amount],[TimeStamp],[RewardId],[UserId],[ProjectId]) VALUES ('30','2020-02-10 20:00',4,4,2)

INSERT INTO [dbo].[Transactions] ([Amount],[TimeStamp],[RewardId],[UserId],[ProjectId]) VALUES ('20','2020-02-10 20:00',1,3,1)
INSERT INTO [dbo].[Transactions] ([Amount],[TimeStamp],[RewardId],[UserId],[ProjectId]) VALUES ('30','2020-02-10 20:00',4,3,2)

GO


