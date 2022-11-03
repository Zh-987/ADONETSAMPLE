# ADONETSAMPLE
Asp .Net MVC ADO .NET example for the students of the IT Step Academy

NUGET PACKAGES

![image](https://user-images.githubusercontent.com/61219912/199770355-af8e875c-8f2f-4492-bdcc-138727646f0a.png)

![image](https://user-images.githubusercontent.com/61219912/199770568-f0a2ef9e-3d49-4f93-87ed-2dd300e974fd.png)

![image](https://user-images.githubusercontent.com/61219912/199770547-9c3759ea-8837-4693-aed2-8d82b8501a79.png)


DDL of the DB that using in model ADO .NET 


-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/03/2022 21:57:13
-- Generated from EDMX file: C:\Users\assai\source\repos\ADONETExample\ADONETExample\Models\Model2.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyMusicDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Track__AlbumId__5CD6CB2B]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK__Track__AlbumId__5CD6CB2B];
GO
IF OBJECT_ID(N'[dbo].[FK_ArtistId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Album] DROP CONSTRAINT [FK_ArtistId];
GO
IF OBJECT_ID(N'[dbo].[FK_GenreId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Genre] DROP CONSTRAINT [FK_GenreId];
GO
IF OBJECT_ID(N'[dbo].[FK_Track]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Track] DROP CONSTRAINT [FK_Track];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ADONETSAMPLE]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ADONETSAMPLE];
GO
IF OBJECT_ID(N'[dbo].[Album]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Album];
GO
IF OBJECT_ID(N'[dbo].[Artist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Artist];
GO
IF OBJECT_ID(N'[dbo].[Customer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customer];
GO
IF OBJECT_ID(N'[dbo].[Genre]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Genre];
GO
IF OBJECT_ID(N'[dbo].[Track]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Track];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Albums'
CREATE TABLE [dbo].[Albums] (
    [AlbumID] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(160)  NOT NULL,
    [ArtistID] int  NOT NULL
);
GO

-- Creating table 'Artists'
CREATE TABLE [dbo].[Artists] (
    [ArtistID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(120)  NULL,
    [Country] nvarchar(60)  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(40)  NOT NULL,
    [LastName] nvarchar(20)  NOT NULL,
    [Company] nvarchar(80)  NULL,
    [Address] nvarchar(70)  NULL,
    [City] nvarchar(40)  NULL,
    [State] nvarchar(40)  NULL,
    [Country] nvarchar(40)  NULL,
    [PostalCode] nvarchar(10)  NULL,
    [Phone] nvarchar(24)  NULL,
    [Fax] nvarchar(24)  NULL,
    [Email] nvarchar(60)  NOT NULL,
    [SupportRepId] int  NULL
);
GO

-- Creating table 'Genres'
CREATE TABLE [dbo].[Genres] (
    [GenreId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(120)  NULL
);
GO

-- Creating table 'Tracks'
CREATE TABLE [dbo].[Tracks] (
    [TrackId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [AlbumId] int  NULL,
    [MediaTypeId] int  NOT NULL,
    [GenreId] int  NULL,
    [Composer] nvarchar(220)  NULL,
    [Milliseconds] int  NOT NULL,
    [Bytes] int  NULL,
    [UnitPrice] decimal(10,2)  NOT NULL
);
GO

-- Creating table 'ADONETSAMPLEs'
CREATE TABLE [dbo].[ADONETSAMPLEs] (
    [Id] int  NOT NULL,
    [Name] nchar(10)  NULL,
    [Region] nchar(10)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AlbumID] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [PK_Albums]
    PRIMARY KEY CLUSTERED ([AlbumID] ASC);
GO

-- Creating primary key on [ArtistID] in table 'Artists'
ALTER TABLE [dbo].[Artists]
ADD CONSTRAINT [PK_Artists]
    PRIMARY KEY CLUSTERED ([ArtistID] ASC);
GO

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [GenreId] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [PK_Genres]
    PRIMARY KEY CLUSTERED ([GenreId] ASC);
GO

-- Creating primary key on [TrackId] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [PK_Tracks]
    PRIMARY KEY CLUSTERED ([TrackId] ASC);
GO

-- Creating primary key on [Id] in table 'ADONETSAMPLEs'
ALTER TABLE [dbo].[ADONETSAMPLEs]
ADD CONSTRAINT [PK_ADONETSAMPLEs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AlbumId] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [FK__Track__AlbumId__5CD6CB2B]
    FOREIGN KEY ([AlbumId])
    REFERENCES [dbo].[Albums]
        ([AlbumID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Track__AlbumId__5CD6CB2B'
CREATE INDEX [IX_FK__Track__AlbumId__5CD6CB2B]
ON [dbo].[Tracks]
    ([AlbumId]);
GO

-- Creating foreign key on [ArtistID] in table 'Albums'
ALTER TABLE [dbo].[Albums]
ADD CONSTRAINT [FK_ArtistId]
    FOREIGN KEY ([ArtistID])
    REFERENCES [dbo].[Artists]
        ([ArtistID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArtistId'
CREATE INDEX [IX_FK_ArtistId]
ON [dbo].[Albums]
    ([ArtistID]);
GO

-- Creating foreign key on [GenreId] in table 'Genres'
ALTER TABLE [dbo].[Genres]
ADD CONSTRAINT [FK_GenreId]
    FOREIGN KEY ([GenreId])
    REFERENCES [dbo].[Genres]
        ([GenreId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [GenreId] in table 'Tracks'
ALTER TABLE [dbo].[Tracks]
ADD CONSTRAINT [FK_Track]
    FOREIGN KEY ([GenreId])
    REFERENCES [dbo].[Genres]
        ([GenreId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Track'
CREATE INDEX [IX_FK_Track]
ON [dbo].[Tracks]
    ([GenreId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
