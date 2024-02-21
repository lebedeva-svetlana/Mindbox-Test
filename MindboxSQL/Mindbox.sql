CREATE DATABASE [Mindbox];

GO

USE [Mindbox];

CREATE TABLE [Categories] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1), 
  [Name] NVARCHAR(100)
);

CREATE TABLE [Products] (
  [Id] INT PRIMARY KEY IDENTITY(1, 1), 
  [Name] NVARCHAR(100)
);

CREATE TABLE [ProductCategories] (
  [ProductId] INT FOREIGN KEY REFERENCES Products(Id), 
  [CategoryId] INT FOREIGN KEY REFERENCES Categories(Id), 
  PRIMARY KEY (ProductId, CategoryId)
);

GO

INSERT INTO [Products] ([Name])
VALUES 
  ('Table'), 
  ('Apple'), 
  ('Chair'), 
  ('Dress');

INSERT INTO [Categories] ([Name])
VALUES 
  ('Furniture'), 
  ('Food'), 
  ('Fruits');

INSERT INTO [ProductCategories] 
VALUES 
  (1, 1), 
  (2, 2), 
  (2, 3), 
  (3, 1);

SELECT 
  [P].[Name], 
  [C].[Name] 
FROM 
  [Products] [P] 
  LEFT JOIN [ProductCategories] [PC] ON [P].[Id] = [PC].[ProductId] 
  LEFT JOIN [Categories] [C] ON [PC].[CategoryId] = [C].[Id];
