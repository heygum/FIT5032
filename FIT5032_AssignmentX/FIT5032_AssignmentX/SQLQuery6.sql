
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/14/2020 19:04:53
-- Generated from EDMX file: C:\Users\CJ\Source\Repos\FIT5032_AssignmentX\FIT5032_AssignmentX\Models\Map.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [defaultDB];
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

-- Creating table 'MapLocations'
CREATE TABLE [dbo].[MapLocations] (
    [LocationId] int IDENTITY(1,1) NOT NULL,
    [LocationName] nvarchar(max)  NOT NULL,
    [longitude] nvarchar(max)  NOT NULL,
    [Latitude] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [LocationId] in table 'MapLocations'
ALTER TABLE [dbo].[MapLocations]
ADD CONSTRAINT [PK_MapLocations]
    PRIMARY KEY CLUSTERED ([LocationId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------