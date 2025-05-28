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

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY IDENTITY(1, 1),
	UserID INT NOT NULL,
	TotalAmount SMALLMONEY NOT NULL,
	OrderDate DATETIME NULL,
	Status TINYINT NOT NULL -- 0 => canceled, 1 => Draft, 2 => pending, 3 => processing, 4 => delivered

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


-------------------------Check Constraint----------------------------

ALTER TABLE Reviews
ADD CONSTRAINT CHK_1to5Rating CHECK (Rating >= 1 AND Rating <= 5)
ALTER TABLE Reviews
ADD CONSTRAINT UQ_Reviews_ProductID_UserID UNIQUE (ProductID, UserID)  


-------------------------Triggers----------------------------

CREATE TRIGGER TRG_Reviews_SetProductRating
ON Reviews
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Update the Product rating based on the average rating from Reviews
    UPDATE p
    SET p.Rating = (
        -- Calculate the average rating for the affected ProductID
        SELECT AVG(CAST(r.Rating AS DECIMAL(3,2))) 
        FROM Reviews r
        WHERE r.ProductID = i.ProductID
    )
    FROM Products p
    INNER JOIN (
        -- Get distinct ProductIDs from the inserted rows
        SELECT DISTINCT ProductID
        FROM inserted
    ) i
    ON p.ProductID = i.ProductID;

END;
------------------

ALTER TRIGGER TRG_OrderItems_UpdateOrderTotalAmount
ON OrderItems
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @AffectedRows TABLE (OrderID INT)

	-- For INSERT and UPDATE, get OrderIDs from inserted
	INSERT INTO @AffectedRows (OrderID)
	SELECT DISTINCT OrderID
	FROM inserted
	WHERE OrderID IS NOT NULL

	-- For DELETE and UPDATE, get OrderIDs from inserted
	INSERT INTO @AffectedRows (OrderID)
	SELECT DISTINCT OrderID
	FROM deleted
	WHERE OrderID IS NOT NULL AND OrderID NOT IN (SELECT OrderID FROM @AffectedRows)

	-- Update TotalAmount for each affected OrderID
	UPDATE o
	SET TotalAmount = COALESCE( 
	(SELECT SUM(TotalItemsPrice) FROM OrderItems oi
	WHERE oi.OrderID = o.OrderID)
	, 0)
	FROM Orders o
	INNER JOIN @AffectedRows oa
	ON o.OrderID = oa.OrderID
END


