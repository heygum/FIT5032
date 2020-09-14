
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/13/2020 22:49:31
-- Generated from EDMX file: C:\Users\CJ\Source\Repos\FIT5032_MyAssignment\FIT5032_MyAssignment\Models\Moves.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Moves];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Moves]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Moves];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Moves'
CREATE TABLE [dbo].[Moves] (
    [MoveID] int IDENTITY(1,1) NOT NULL,
    [MoveName] nvarchar(max)  NOT NULL,
    [Times] smallint  NOT NULL,
    [Rounds] smallint  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MoveID] in table 'Moves'
ALTER TABLE [dbo].[Moves]
ADD CONSTRAINT [PK_Moves]
    PRIMARY KEY CLUSTERED ([MoveID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------