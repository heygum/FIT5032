
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/27/2020 20:45:45
-- Generated from EDMX file: C:\Users\CJ\Source\Repos\FIT5032_AssignmentX\FIT5032_AssignmentX\Models\Moves.edmx
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

IF OBJECT_ID(N'[dbo].[Movements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Movements];
GO
IF OBJECT_ID(N'[dbo].[MovePlans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MovePlans];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Movements'
CREATE TABLE [dbo].[Movements] (
    [MovementId] int IDENTITY(1,1) NOT NULL,
    [MovementName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MovePlans'
CREATE TABLE [dbo].[MovePlans] (
    [PlanId] int IDENTITY(1,1) NOT NULL,
    [MoveName] nvarchar(max)  NOT NULL,
    [Time] smallint  NOT NULL,
    [Round] smallint  NOT NULL,
    [Date] datetime  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MovementId] in table 'Movements'
ALTER TABLE [dbo].[Movements]
ADD CONSTRAINT [PK_Movements]
    PRIMARY KEY CLUSTERED ([MovementId] ASC);
GO

-- Creating primary key on [PlanId] in table 'MovePlans'
ALTER TABLE [dbo].[MovePlans]
ADD CONSTRAINT [PK_MovePlans]
    PRIMARY KEY CLUSTERED ([PlanId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------