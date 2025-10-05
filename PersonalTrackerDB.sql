CREATE DATABASE PersonalTrackerDB
GO
USE PersonalTrackerDB
GO
CREATE TABLE Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(80) NOT NULL,
    Email NVARCHAR(80) NOT NULL,
    Balance DECIMAL(18,2) NOT NULL
);
GO
CREATE TABLE Visa (
    Code INT IDENTITY(1,1) PRIMARY KEY,
    Password INT NOT NULL,
    User_id INT NOT NULL,
    FOREIGN KEY (User_id) REFERENCES Users(Id)
);
GO
INSERT INTO Users (Name, Email, Balance)
VALUES 
('Mido', 'mido@email.com', 1500.00),  
('Ahmed', 'ahmed@email.com', 2500.00),
('Omar', 'omar@email.com', 1000.50);
GO
INSERT INTO Visa (Password, User_id)
VALUES
(1234, 1),
(5678, 2),
(9999, 3);
GO

SELECT * FROM Users
SELECT * FROM Visa