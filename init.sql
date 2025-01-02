-- Création de la base de données
CREATE DATABASE TiExamen20232024;
GO

-- Utilisation de la base de données 'TiExamen20232024'
USE TiExamen20232024;
GO

-- Création des tables
CREATE TABLE Users (
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    Pseudo NVARCHAR(50) NOT NULL UNIQUE,
    Role NVARCHAR(20) NOT NULL
);
GO

CREATE TABLE Invitations (
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    UserSenderId INT NOT NULL,
    UserInvitedId INT NOT NULL,
    Status NVARCHAR(20) NOT NULL,
    FOREIGN KEY (UserSenderId) REFERENCES Users(Id) ON DELETE NO ACTION,
    FOREIGN KEY (UserInvitedId) REFERENCES Users(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Publications (
    Id INT IDENTITY PRIMARY KEY NOT NULL,
    CreatedByUserId INT NOT NULL,
    Title NVARCHAR(30) NOT NULL,
    Content NVARCHAR(200) NOT NULL,
    CreatedAt DATETIME NOT NULL,
    FOREIGN KEY (CreatedByUserId) REFERENCES Users(Id) ON DELETE CASCADE
);
GO

-- Insertion des données
INSERT INTO Users (Pseudo, Role) VALUES ('User 1', 'User');
INSERT INTO Users (Pseudo, Role) VALUES ('User 2', 'User');
INSERT INTO Users (Pseudo, Role) VALUES ('User 3', 'User');
INSERT INTO Users (Pseudo, Role) VALUES ('User 4', 'User');
INSERT INTO Users (Pseudo, Role) VALUES ('User 5', 'User');
GO
