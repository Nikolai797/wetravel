CREATE database TravelAgency;
CREATE TABLE Customers (
    CustomerID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    PhoneNumber VARCHAR(15),
    RegistrationDate DATE
);

CREATE TABLE Countries (
    CountryID INT AUTO_INCREMENT PRIMARY KEY,
    CountryName VARCHAR(100) NOT NULL
);

CREATE TABLE Guides (
    GuideID INT AUTO_INCREMENT PRIMARY KEY,
    GuideName VARCHAR(100) NOT NULL,
    PhoneNumber VARCHAR(15),
    ExperienceYears INT
);

CREATE TABLE Tours (
    TourID INT AUTO_INCREMENT PRIMARY KEY,
    TourName VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL,
    DurationDays INT NOT NULL,
    GuideID INT,
    FOREIGN KEY (GuideID) REFERENCES Guides(GuideID)
);

CREATE TABLE Destinations (
    DestinationID INT AUTO_INCREMENT PRIMARY KEY,
    DestinationName VARCHAR(100) NOT NULL,
    CountryID INT NOT NULL,
    FOREIGN KEY (CountryID) REFERENCES Countries(CountryID)
);

CREATE TABLE Bookings (
    BookingID INT AUTO_INCREMENT PRIMARY KEY,
    CustomerID INT NOT NULL,
    TourID INT NOT NULL,
    BookingDate DATE NOT NULL,
    NumberOfPeople INT NOT NULL,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (TourID) REFERENCES Tours(TourID)
);

CREATE TABLE TourDestinations (
    TourID INT NOT NULL,
    DestinationID INT NOT NULL,
    PRIMARY KEY (TourID, DestinationID),
    FOREIGN KEY (TourID) REFERENCES Tours(TourID),
    FOREIGN KEY (DestinationID) REFERENCES Destinations(DestinationID)
);

CREATE TABLE CustomerDestinations (
    CustomerID INT NOT NULL,
    DestinationID INT NOT NULL,
    VisitDate DATE NOT NULL,
    PRIMARY KEY (CustomerID, DestinationID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
    FOREIGN KEY (DestinationID) REFERENCES Destinations(DestinationID)
);



INSERT INTO Customers (Name, Email, PhoneNumber, RegistrationDate)
VALUES
('Ivan Ivanov', 'ivan@example.com', '123456789', '2024-01-10'),
('Maria Petrova', 'maria@example.com', '987654321', '2024-01-12'),
('Georgi Georgiev', 'georgi@example.com', '555666777', '2024-01-15');


INSERT INTO Guides (GuideName, PhoneNumber, ExperienceYears)
VALUES
('Peter Petrov', '111222333', 5),
('Anna Dimitrova', '444555666', 7);

INSERT INTO Countries (CountryName)
VALUES
('France'),
('Italy'),
('Indonesia');


INSERT INTO Tours (TourName, Price, DurationDays, GuideID)
VALUES
('Paris Adventure', 1200.50, 5, 1),
('Rome Getaway', 950.00, 4, 2),
('Bali Escape', 2100.75, 10, 1);


INSERT INTO Destinations (DestinationName, CountryID)
VALUES
('Eiffel Tower', 1),
('Colosseum', 2),
('Ubud', 3);


INSERT INTO Bookings (CustomerID, TourID, BookingDate, NumberOfPeople)
VALUES
(1, 1, '2024-02-01', 2),
(2, 2, '2024-02-15', 4),
(3, 3, '2024-03-10', 1);


INSERT INTO TourDestinations (TourID, DestinationID)
VALUES
(1, 1), 
(2, 2), 
(3, 3); 


INSERT INTO CustomerDestinations (CustomerID, DestinationID, VisitDate)
VALUES
(1, 1, '2024-01-20'), 
(2, 2, '2024-01-25'), 
(3, 3, '2024-02-15'); 



SELECT * FROM Customers;


SELECT TourName, Price FROM Tours;


SELECT d.DestinationName, c.CountryName 
FROM Destinations d
JOIN Countries c ON d.CountryID = c.CountryID;

SELECT b.BookingID, c.Name AS CustomerName, t.TourName, b.NumberOfPeople, b.BookingDate
FROM Bookings b
JOIN Customers c ON b.CustomerID = c.CustomerID
JOIN Tours t ON b.TourID = t.TourID;


SELECT t.TourName, d.DestinationName
FROM Tours t
JOIN TourDestinations td ON t.TourID = td.TourID
JOIN Destinations d ON td.DestinationID = d.DestinationID;


SELECT t.TourName, COUNT(b.CustomerID) AS TotalCustomers
FROM Tours t
LEFT JOIN Bookings b ON t.TourID = b.TourID
GROUP BY t.TourID;

SELECT t.TourName, SUM(b.NumberOfPeople * t.Price) AS TotalRevenue
FROM Tours t
JOIN Bookings b ON t.TourID = b.TourID
GROUP BY t.TourID;


SELECT GuideName, ExperienceYears FROM Guides;


SELECT c.Name AS CustomerName, d.DestinationName, cd.VisitDate
FROM CustomerDestinations cd
JOIN Customers c ON cd.CustomerID = c.CustomerID
JOIN Destinations d ON cd.DestinationID = d.DestinationID;


SELECT d.DestinationName, d.CountryID, cd.VisitDate
FROM CustomerDestinations cd
JOIN Destinations d ON cd.DestinationID = d.DestinationID
WHERE cd.CustomerID = 1;
