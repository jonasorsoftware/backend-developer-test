
/****** Object:  Table [dbo].[Address]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[Type] [int] NOT NULL,
	[ZipCode] [varchar](20) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[District] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](25) NOT NULL,
	[Cellphone] [varchar](25) NULL,
	[DateCreation] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Order]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Order](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](150) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[PhoneNumber] [varchar](25) NOT NULL,
	[ZipCode] [varchar](20) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[District] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Shipping] [decimal](10, 2) NOT NULL,
	[CurrentStatus] [int] NOT NULL,
	[Integrated] [bit] NOT NULL
	[DateCreation] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
	[AddressType] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](100) NOT NULL,
	[LastName] [varchar](150) NOT NULL,
	[Gender] [int] NOT NULL,
	[DocumentId] [varchar](30) NOT NULL,
	[Email] [varchar](150) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Integrated] [bit] NOT NULL,
	[DateCreation] [datetime] NOT NULL,
	[DateModified] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User]    Script Date: 28/12/2015 22:19:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_1]    Script Date: 28/12/2015 22:19:04 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_1] ON [dbo].[User]
(
	[DocumentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_User]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
/****** Object:  StoredProcedure [dbo].[AddAddress]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CRATE PROCEDURE [dbo].[AddAddress]	
	@UserId int
	,@Type int
	,@ZipCode varchar(20)
	,@Address varchar(250)
	,@District varchar(50)
	,@City varchar(50)
	,@State varchar(50)
	,@Country varchar(50)
	,@PhoneNumber varchar(25)
	,@Cellphone varchar(25)
AS
BEGIN

	INSERT INTO [Address]	
			(UserId
			,[Type]
			,ZipCode
			,[Address]
			,District
			,City
			,[State]
			,Country
			,PhoneNumber
			,Cellphone
			,DateCreation
			,DateModified)
		VALUES		
			(@UserId
			,@Type
			,@ZipCode
			,@Address
			,@District
			,@City
			,@State
			,@Country
			,@PhoneNumber
			,@Cellphone
			,GETDATE()
			,GETDATA())

	UPDATE [User] 
		SET [Integrated] = 0 
		WHERE Id = @UserId

END


GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser]	
	@FirstName varchar(100)
	,@LastName varchar(150)
	,@Gender int
	,@DocumentId varchar(30)
	,@Email varchar(150)
	,@Password varchar(50)
AS
BEGIN

	INSERT INTO [User]	
			(FirstName
			,LastName
			,Gender
			,DocumentId
			,Email
			,[Password]
			,[Integrated]
			,DateCreation
			,DateModified)
			VALUES		
				(@FirstName
				,@LastName
				,@Gender
				,@DocumentId
				,@Email
				,@Password
				,0
				,GETDATE()
				,GETDATE())

	SELECT SCOPE_IDENTITY() AS 'Id'

END

GO
/****** Object:  StoredProcedure [dbo].[GetAddresses]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAddresses]	
	@Id int = 0
AS
BEGIN

	SELECT * 
		FROM [Address] 
		WHERE @Id = 0 OR Id = @Id

END


GO
/****** Object:  StoredProcedure [dbo].[GetOrders]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetOrders]	
	@Id int = 0
AS
BEGIN

	SELECT * 
		FROM [Order] 
		WHERE @Id = 0 OR Id = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[GetUsers]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUsers]	
	@Id int = 0,
	@Email varchar(150) = NULL,
	@DocumentId varchar(30) = NULL
AS
BEGIN

	SELECT * 
		FROM [User] 
		WHERE	(@Id = 0 OR Id = @Id) AND (@DocumentId IS NULL OR DocumentId = @DocumentId) AND (@Email IS NULL OR Email = @Email)

	IF @Id > 0
	BEGIN
		SELECT * 
			FROM [Address] 
			WHERE UserId = @Id	
	END

END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAddress]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateAddress]	
	@Id int
	,@UserId int
	,@Type int
	,@ZipCode varchar(20)
	,@Address varchar(250)
	,@District varchar(50)
	,@City varchar(50)
	,@State varchar(50)
	,@Country varchar(50)
	,@PhoneNumber varchar(25)
	,@Cellphone varchar(25)
AS
BEGIN

	UPDATE [Address] 
		SET
			[Type] = @Type
			,ZipCode = @ZipCode
			,[Address] = @Address
			,District = @District
			,City = @City
			,[State] = @State
			,Country = @Country
			,PhoneNumber = @PhoneNumber
			,Cellphone = @Cellphone
			,DateModified = GETDATE()
		WHERE
			Id = @Id

	UPDATE [User] 
		SET [Integrated] = 0 
		WHERE Id = @UserId

END


GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 28/12/2015 22:19:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]	
	@Id int
	,@FirstName varchar(100)
	,@LastName varchar(150)
	,@Gender int
AS
BEGIN

	UPDATE [User] SET
			FirstName = @FirstName
			,LastName = @LastName
			,Gender = @Gender
			,[Integrated] = 0
			,DateModified = GETDATE()
	WHERE
		Id = @Id

END

/****** Object:  StoredProcedure [dbo].[DelteUser]    Script Date: 04/01/2016 23:47:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteUser]	
	@Id int
AS
BEGIN

	DELETE FROM [User] WHERE Id = @Id 			

END