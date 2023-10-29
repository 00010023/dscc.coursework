-- Create the database
CREATE DATABASE Blog;
GO

USE Blog;
GO

-- Create the Authors table
CREATE TABLE Authors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Biography NVARCHAR(MAX) NULL
);
GO

-- Create the Posts table
CREATE TABLE Posts (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    AuthorId INT NOT NULL,
);
GO
