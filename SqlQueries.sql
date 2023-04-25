

CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[Team] [nvarchar](50) NULL,
	[joinedAt] [datetime] NULL,
	[avatar] [nvarchar](max) NULL,
	[email] [nvarchar](250) NULL,
	[password] [nvarchar](300) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

insert into Users(name,Team,joinedAt,avatar,email,password)
values('Yonatan','Developers','2023-04-25','https://avatarfiles.alphacoders.com/164/thumb-164632.jpg','t@t.com','Q1qwerty')


CREATE TABLE [dbo].[Projects](
	[id] [nvarchar](100) NOT NULL,
	[userId] [int] NULL,
	[name] [nvarchar](50) NULL,
	[score] [int] NULL,
	[durationInDays] [int] NULL,
	[bugsCount] [int] NULL,
	[madeDadeline] [bit] NULL,
 CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

