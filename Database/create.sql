-- Create the database
CREATE DATABASE Blog;
GO

USE Blog;
GO

-- Create the Authors table
CREATE TABLE Authors (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(255) NOT NULL,
    Biography NVARCHAR(MAX)
);
GO

-- Create the Posts table
CREATE TABLE Posts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    AuthorId INT FOREIGN KEY REFERENCES Authors(Id)
);
GO
