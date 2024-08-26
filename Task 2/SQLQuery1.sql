Create database Task; 
use Task;
create TABLE Categories (
    ID int primary key Identity,
    CategoryName nvarchar(MAX), 
    CategoryImage nvarchar(MAX)
);
create TABLE Products (
    ID int primary key Identity,
    ProductName nvarchar(MAX),
    [Description] nvarchar(MAX), 
    Price bigint,
    CategoryID int references Categories(ID),
    ProductImage nvarchar(MAX) 
);
CREATE TABLE Users (
    ID int PRIMARY KEY IDENTITY,
    Username nvarchar(MAX),
    [Password] nvarchar(MAX),
    Email nvarchar(MAX)
);
CREATE TABLE Orders (
    ID int PRIMARY KEY IDENTITY,
    UserID int REFERENCES Users(ID),
    OrderDate date
);
truncate  table Categories
truncate  table Products
truncate table Orders
truncate table Users


INSERT INTO Categories (CategoryName, CategoryImage)
VALUES 
('Electronics', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Books', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Clothing', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Home Appliances', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Sports', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Toys', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Furniture', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Beauty Products', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Automobiles', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Groceries', 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww');
INSERT INTO Products (ProductName, [Description], Price, CategoryID, ProductImage)
VALUES 
('Smartphone', 'A high-end smartphone with great features.', 69999, 1, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Laptop', 'A powerful laptop for work and gaming.', 119999, 1, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHwwg'),
('Novel', 'A best-selling fiction novel.', 999, 2, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Textbook', 'An essential textbook for students.', 1999, 2, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('T-shirt', 'A comfortable cotton t-shirt.', 499, 3, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Jeans', 'Stylish denim jeans.', 1499, 3, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Microwave', 'A high-efficiency microwave oven.', 7999, 4, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Refrigerator', 'A large double-door refrigerator.', 24999, 4, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Football', 'A standard size football for sports.', 699, 5, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww'),
('Cricket Bat', 'A professional cricket bat.', 1599, 5, 'https://plus.unsplash.com/premium_photo-1667689956673-8737a299aa8c?fm=jpg&q=60&w=3000&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8MXx8c2t5fGVufDB8fDB8fHww');

-- Insert data into the Users table
INSERT INTO Users (Username, [Password], Email)
VALUES 
('JohnDoe', 'password123', 'john.doe@example.com'),
('JaneSmith', 'securepass', 'jane.smith@example.com'),
('MichaelBrown', 'mike123', 'michael.brown@example.com'),
('EmilyDavis', 'emilysecure', 'emily.davis@example.com'),
('DavidWilson', 'davidpass', 'david.wilson@example.com');

-- Insert data into the Orders table with ProductID and Quantity
INSERT INTO Orders (UserID, ProductID, OrderDate, Quantity)
VALUES 
(1, 1, '2023-08-01', 1),   -- Smartphone
(2, 2, '2023-08-02', 1),   -- Laptop
(1, 3, '2023-08-03', 2),   -- Novel
(3, 4, '2023-08-04', 1),   -- Textbook
(4, 5, '2023-08-05', 3),   -- T-shirt
(5, 6, '2023-08-06', 1),   -- Jeans
(2, 7, '2023-08-07', 1),   -- Microwave
(3, 8, '2023-08-08', 1),   -- Refrigerator
(4, 9, '2023-08-09', 2),   -- Football
(1, 10, '2023-08-10', 1);  -- Cricket Bat

-- Alter the Orders table to add ProductID and Quantity
ALTER TABLE Orders
ADD ProductID int REFERENCES Products(ID),
    Quantity int;
