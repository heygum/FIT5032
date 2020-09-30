
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/30/2020 09:14:48
-- Generated from EDMX file: C:\Users\CJ\Source\Repos\FIT5032_AssignmentX\FIT5032_AssignmentX\Models\Recipe.edmx
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

IF OBJECT_ID(N'[dbo].[Recipes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Recipes];
GO
IF OBJECT_ID(N'[dbo].[RecipePlans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RecipePlans];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Recipes'
CREATE TABLE [dbo].[Recipes] (
    [RecipeID] int IDENTITY(1,1) NOT NULL,
    [RecipeName] nvarchar(max)  NOT NULL,
    [Calorie] float  NOT NULL
);
GO

-- Creating table 'RecipePlans'
CREATE TABLE [dbo].[RecipePlans] (
    [PlanID] int IDENTITY(1,1) NOT NULL,
    [ReciName] nvarchar(max)  NOT NULL,
    [Calorie] float  NOT NULL,
    [Quantity] smallint  NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [UserID] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [RecipeID] in table 'Recipes'
ALTER TABLE [dbo].[Recipes]
ADD CONSTRAINT [PK_Recipes]
    PRIMARY KEY CLUSTERED ([RecipeID] ASC);
GO

-- Creating primary key on [PlanID] in table 'RecipePlans'
ALTER TABLE [dbo].[RecipePlans]
ADD CONSTRAINT [PK_RecipePlans]
    PRIMARY KEY CLUSTERED ([PlanID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------