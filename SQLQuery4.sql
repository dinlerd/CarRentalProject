CREATE TABLE Customers(
Id int primary key IDENTITY(1,1),
UserId int,
CompanyName nvarchar(50)
Foreign Key (UserId) references Users(Id)
);

CREATE TABLE Rentals (
Id int primary key identity(1,1),
CarId int not null,
CustomerId int not null,
RentDate date,
ReturnDate date,
foreign key (CarId) references Cars(Id),
foreign key (CustomerId) references Customers(Id)
);