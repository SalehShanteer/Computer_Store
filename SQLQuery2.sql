------------------------------Tables------------------------------

CREATE TABLE Users
(
	UserID INT PRIMARY KEY IDENTITY(1, 1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(320) NOT NULL UNIQUE,
	Phone NVARCHAR(15) NOT NULL UNIQUE,
	Password NVARCHAR(65) NOT NULL,
	Role TINYINT NOT NULL -- 0 ==> Customer, 1 ==> Admin
)
---------------------

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY(1, 1),
	UserID INT NOT NULL,
	TotalAmount SMALLMONEY NOT NULL,
	OrderDate DATETIME NOT NULL,
	Status TINYINT NOT NULL -- 0 => canceled, 1 => pending, 2 => processing, 3 => delivered

	FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
---------------------

CREATE TABLE PaymentMethods
(
	PaymentMethodID INT PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(50) NOT NULL UNIQUE
)
---------------------

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY IDENTITY(1, 1),
	OrderID INT NOT NULL UNIQUE,
	Amount SMALLMONEY NOT NULL,
	PaymentMethodID INT NOT NULL,
	TransactionDate DATETIME NOT NULL

	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	FOREIGN KEY (PaymentMethodID) REFERENCES PaymentMethods(PaymentMethodID)
)
--------------------

CREATE TABLE Shippings
(
	ShippingID INT PRIMARY KEY IDENTITY(1, 1),
	OrderID INT NOT NULL,
	CarrierName NVARCHAR(50) NOT NULL,
	TrackingNumber AS (CarrierName + '-' + CAST(ShippingID AS NVARCHAR(7))) PERSISTED,
	ShippingCost SMALLMONEY NOT NULL,
	ShippingAddress NVARCHAR(255) NOT NULL,
	EstimatedDeliveryDate DateTime NOT NULL,
	ActualDeliveryDate DateTime NULL,
	Status TINYINT NOT NULL -- 0 => canceled, 1 => pending, 2 => processing, 3 => delivered

	FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
)
--------------------

CREATE TABLE Categories
(
	CategoryID INT PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(255) NOT NULL UNIQUE
)

--------------------

CREATE TABLE Subcategories (
    SubcategoryID INT PRIMARY KEY IDENTITY(1, 1),
    Name VARCHAR(50) NOT NULL,
    CategoryID INT,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
--------------------

CREATE TABLE Brands
(
	BrandID INT PRIMARY KEY IDENTITY(1, 1),
	Name NVARCHAR(50) NOT NULL UNIQUE,
	ImagePath NVARCHAR(500) NULL
)
---------------------

CREATE TABLE Products
(
	ProductID INT PRIMARY KEY IDENTITY(1, 1),
	ProductName NVARCHAR(100) NOT NULL,
	Description NVARCHAR(MAX) NOT NULL,
	Price SMALLMONEY NOT NULL,
	QuantityInStock SmallInt NOT NULL,
	CategoryID int NOT NULL,
	SubcategoryID INT NULL,
	BrandID int NULL,
	Rating DECIMAL(3, 2) NULL,
	ReleaseDate DATETIME NULL

	FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID),
	FOREIGN KEY (SubcategoryID) REFERENCES Subcategories(SubcategoryID),
	FOREIGN KEY (BrandID) REFERENCES Brands(BrandID)
)
---------------------

CREATE TABLE OrderItems
(
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    Quantity INT NOT NULL,
    Price SMALLMONEY NOT NULL,
    TotalItemsPrice AS CAST(Price * Quantity AS SMALLMONEY) PERSISTED,

    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)
----------------------

CREATE TABLE Reviews
(
    ReviewID INT PRIMARY KEY IDENTITY(1, 1),
    ProductID INT NOT NULL,
    UserID INT NOT NULL,
    ReviewText NVARCHAR(500) NOT NULL,
	Rating TINYINT NOT NULL,
	ReviewDate DATETIME NOT NULL

    FOREIGN KEY (UserID) REFERENCES Users(UserID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)
---------------------

CREATE TABLE LoginRecords
(
	LoginRecordID INT PRIMARY KEY IDENTITY(1, 1),
	UserID INT NOT NULL,
	LoginTime DATETIME NOT NULL,
	LoginStatus BIT NOT NULL,
	FailureReason NVARCHAR(100) NULL,

	FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
----------------------

CREATE TABLE ProductImages
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	ImagePath NVARCHAR(500) NOT NULL,
	ProductID INT NOT NULL,
	ImageOrder TINYINT NOT NULL

	FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
)

