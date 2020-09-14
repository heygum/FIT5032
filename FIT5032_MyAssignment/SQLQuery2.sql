
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/14/2020 04:40:39
-- Generated from EDMX file: C:\Users\CJ\Source\Repos\FIT5032_MyAssignment\FIT5032_MyAssignment\Models\ManageMoves.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ManageMoves];
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

-- Creating table 'Movements'
CREATE TABLE [dbo].[Movements] (
    [MovementID] int IDENTITY(1,1) NOT NULL,
    [MovementName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MovementID] in table 'Movements'
ALTER TABLE [dbo].[Movements]
ADD CONSTRAINT [PK_Movements]
    PRIMARY KEY CLUSTERED ([MovementID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------