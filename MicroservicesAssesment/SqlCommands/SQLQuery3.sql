USE [ECommerceMSCartDb];
GO

-- ─────────────────────────────────────────────
-- Carts (one per customer)
-- Same User IDs as UserDb
-- ─────────────────────────────────────────────
DECLARE @Cart1 UNIQUEIDENTIFIER = 'D1000000-0000-0000-0000-000000000001';
DECLARE @Cart2 UNIQUEIDENTIFIER = 'D2000000-0000-0000-0000-000000000002';
DECLARE @Cart3 UNIQUEIDENTIFIER = 'D3000000-0000-0000-0000-000000000003';

DECLARE @User1 NVARCHAR(450) = 'A3000000-0000-0000-0000-000000000003'; -- Amit Kumar
DECLARE @User2 NVARCHAR(450) = 'A4000000-0000-0000-0000-000000000004'; -- Sneha Patel
DECLARE @User3 NVARCHAR(450) = 'A5000000-0000-0000-0000-000000000005'; -- Ravi Singh

-- Product IDs & names from ProductDb
DECLARE @Prod1  UNIQUEIDENTIFIER = 'C1000000-0000-0000-0000-000000000001'; -- Samsung S24 Ultra
DECLARE @Prod2  UNIQUEIDENTIFIER = 'C2000000-0000-0000-0000-000000000002'; -- MacBook Air M3
DECLARE @Prod3  UNIQUEIDENTIFIER = 'C3000000-0000-0000-0000-000000000003'; -- Sony Headphones
DECLARE @Prod6  UNIQUEIDENTIFIER = 'C6000000-0000-0000-0000-000000000006'; -- Levis Jeans
DECLARE @Prod9  UNIQUEIDENTIFIER = 'C9000000-0000-0000-0000-000000000009'; -- Atomic Habits
DECLARE @Prod10 UNIQUEIDENTIFIER = 'CA000000-0000-0000-0000-000000000010'; -- Psychology of Money
DECLARE @Prod14 UNIQUEIDENTIFIER = 'CE000000-0000-0000-0000-000000000014'; -- Dumbbell Set
DECLARE @Prod15 UNIQUEIDENTIFIER = 'CF000000-0000-0000-0000-000000000015'; -- Yoga Mat

-- ── Cart 1: Amit Kumar ───────────────────────
INSERT INTO [Carts] ([Id], [UserId], [CreatedAt])
VALUES (@Cart1, @User1, GETUTCDATE());

INSERT INTO [CartItems] ([Id], [CartId], [ProductId], [ProductName], [UnitPrice], [Quantity], [ImageUrl])
VALUES
(NEWID(), @Cart1, @Prod1, 'Samsung Galaxy S24 Ultra', 109999.00, 1, '/uploads/products/samsung-s24.jpg'),
(NEWID(), @Cart1, @Prod3, 'Sony WH-1000XM5 Headphones', 24999.00, 1, '/uploads/products/sony-headphones.jpg'),
(NEWID(), @Cart1, @Prod9, 'Atomic Habits by James Clear', 349.00,  2, '/uploads/products/atomic-habits.jpg');

-- ── Cart 2: Sneha Patel ──────────────────────
INSERT INTO [Carts] ([Id], [UserId], [CreatedAt])
VALUES (@Cart2, @User2, GETUTCDATE());

INSERT INTO [CartItems] ([Id], [CartId], [ProductId], [ProductName], [UnitPrice], [Quantity], [ImageUrl])
VALUES
(NEWID(), @Cart2, @Prod6,  'Levis 511 Slim Fit Jeans',    2799.00, 2, '/uploads/products/levis-jeans.jpg'),
(NEWID(), @Cart2, @Prod10, 'The Psychology of Money',      299.00,  1, '/uploads/products/psychology-money.jpg');

-- ── Cart 3: Ravi Singh ───────────────────────
INSERT INTO [Carts] ([Id], [UserId], [CreatedAt])
VALUES (@Cart3, @User3, GETUTCDATE());

INSERT INTO [CartItems] ([Id], [CartId], [ProductId], [ProductName], [UnitPrice], [Quantity], [ImageUrl])
VALUES
(NEWID(), @Cart3, @Prod14, 'Boldfit Adjustable Dumbbell Set 20KG', 1999.00, 1, '/uploads/products/dumbbell-set.jpg'),
(NEWID(), @Cart3, @Prod15, 'Cosco Yoga Mat 6mm',                   599.00,  2, '/uploads/products/yoga-mat.jpg'),
(NEWID(), @Cart3, @Prod2,  'Apple MacBook Air M3',                 109999.00, 1, '/uploads/products/macbook-air.jpg');

GO

-- ─────────────────────────────────────────────
-- VERIFY
-- ─────────────────────────────────────────────
SELECT
    c.[UserId],
    ci.[ProductName],
    ci.[UnitPrice],
    ci.[Quantity],
    (ci.[UnitPrice] * ci.[Quantity]) AS SubTotal
FROM [Carts] c
JOIN [CartItems] ci ON ci.[CartId] = c.[Id]
ORDER BY c.[UserId];