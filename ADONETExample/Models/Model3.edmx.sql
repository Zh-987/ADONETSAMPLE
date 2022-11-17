
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/17/2022 21:52:52
-- Generated from EDMX file: C:\Users\assai\source\repos\ADONETExample\ADONETExample\Models\Model3.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Logins'
CREATE TABLE [dbo].[Logins] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Property1] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Entity1'
CREATE TABLE [dbo].[Entity1] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Logins'
ALTER TABLE [dbo].[Logins]
ADD CONSTRAINT [PK_Logins]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Entity1'
ALTER TABLE [dbo].[Entity1]
ADD CONSTRAINT [PK_Entity1]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Login_Id] in table 'Entity1'
ALTER TABLE [dbo].[Entity1]
ADD CONSTRAINT [FK_LoginEntity1]
    FOREIGN KEY ([Login_Id])
    REFERENCES [dbo].[Logins]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoginEntity1'
CREATE INDEX [IX_FK_LoginEntity1]
ON [dbo].[Entity1]
    ([Login_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------