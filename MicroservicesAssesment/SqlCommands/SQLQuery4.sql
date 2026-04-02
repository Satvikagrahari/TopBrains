USE [ECommerceMSOrderDb];
GO

-- ─────────────────────────────────────────────
-- Fixed Order IDs (referenced in PaymentDb)
-- ─────────────────────────────────────────────
DECLARE @Order1 UNIQUEIDENTIFIER = 'E1000000-0000-0000-0000-000000000001';
DECLARE @Order2 UNIQUEIDENTIFIER = 'E2000000-0000-0000-0000-000000000002';
DECLARE @Order3 UNIQUEIDENTIFIER = 'E3000000-0000-0000-0000-000000000003';
DECLARE @Order4 UNIQUEIDENTIFIER = 'E4000000-0000-0000-0000-000000000004';
DECLARE @Order5 UNIQUEIDENTIFIER = 'E5000000-0000-0000-0000-000000000005';

-- User IDs
DECLARE @User1 NVARCHAR(450) = 'A3000000-0000-0000-0000-000000000003'; -- Amit Kumar
DECLARE @User2 NVARCHAR(450) = 'A4000000-0000-0000-0000-000000000004'; -- Sneha Patel
DECLARE @User3 NVARCHAR(450) = 'A5000000-0000-0000-0000-000000000005'; -- Ravi Singh

-- Product IDs
DECLARE @Prod1  UNIQUEIDENTIFIER = 'C1000000-0000-0000-0000-000000000001';
DECLARE @Prod2  UNIQUEIDENTIFIER = 'C2000000-0000-0000-0000-000000000002';
DECLARE @Prod3  UNIQUEIDENTIFIER = 'C3000000-0000-0000-0000-000000000003';
DECLARE @Prod6  UNIQUEIDENTIFIER = 'C6000000-0000-0000-0000-000000000006';
DECLARE @Prod7  UNIQUEIDENTIFIER = 'C7000000-0000-0000-0000-000000000007';
DECLARE @Prod9  UNIQUEIDENTIFIER = 'C9000000-0000-0000-0000-000000000009';
DECLARE @Prod10 UNIQUEIDENTIFIER = 'CA000000-0000-0000-0000-000000000010';
DECLARE @Prod11 UNIQUEIDENTIFIER = 'CB000000-0000-0000-0000-000000000011';
DECLARE @Prod14 UNIQUEIDENTIFIER = 'CE000000-0000-0000-0000-000000000014';
DECLARE @Prod15 UNIQUEIDENTIFIER = 'CF000000-0000-0000-0000-000000000015';

-- OrderStatus Enum:
-- 0=Pending, 1=Confirmed, 2=Processing, 3=Shipped, 4=Delivered, 5=Cancelled, 6=Refunded

-- ── Order 1: Amit — Delivered ────────────────
INSERT INTO [Orders] (
    [Id], [UserId], [CustomerName], [CustomerEmail], [CustomerPhone],
    [BillingAddress], [BillingCity], [BillingState], [BillingPinCode],
    [TrackingId], [Status], [TotalAmount], [PaymentId], [CreatedAt], [UpdatedAt]
)
VALUES (
    @Order1, @User1, 'Amit Kumar', 'amit@gmail.com', '+917063531548',
    '45, MG Road, Koramangala', 'Bangalore', 'Karnataka', '560034',
    'TRK-AMT001', 4, 134997.00, 'PAY-RZP-001', DATEADD(DAY, -15, GETUTCDATE()), DATEADD(DAY, -8, GETUTCDATE())
);

INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [UnitPrice], [Quantity])
VALUES
(NEWID(), @Order1, @Prod1, 'Samsung Galaxy S24 Ultra',   109999.00, 1),
(NEWID(), @Order1, @Prod3, 'Sony WH-1000XM5 Headphones', 24999.00,  1);

-- ── Order 2: Amit — Shipped ──────────────────
INSERT INTO [Orders] (
    [Id], [UserId], [CustomerName], [CustomerEmail], [CustomerPhone],
    [BillingAddress], [BillingCity], [BillingState], [BillingPinCode],
    [TrackingId], [Status], [TotalAmount], [CreatedAt], [UpdatedAt]
)
VALUES (
    @Order2, @User1, 'Amit Kumar', 'amit@gmail.com', '+917063531548',
    '45, MG Road, Koramangala', 'Bangalore', 'Karnataka', '560034',
    'TRK-AMT002', 3, 1148.00, DATEADD(DAY, -5, GETUTCDATE()), DATEADD(DAY, -3, GETUTCDATE())
);

INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [UnitPrice], [Quantity])
VALUES
(NEWID(), @Order2, @Prod9,  'Atomic Habits by James Clear', 349.00, 2),
(NEWID(), @Order2, @Prod10, 'The Psychology of Money',      449.00, 1);

-- ── Order 3: Sneha — Confirmed ───────────────
INSERT INTO [Orders] (
    [Id], [UserId], [CustomerName], [CustomerEmail], [CustomerPhone],
    [BillingAddress], [BillingCity], [BillingState], [BillingPinCode],
    [TrackingId], [Status], [TotalAmount], [CreatedAt]
)
VALUES (
    @Order3, @User2, 'Sneha Patel', 'sneha@gmail.com', '+917063531548',
    'B-12, Sector 18, Noida', 'Noida', 'Uttar Pradesh', '201301',
    'TRK-SNH001', 1, 8497.00, DATEADD(DAY, -2, GETUTCDATE())
);

INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [UnitPrice], [Quantity])
VALUES
(NEWID(), @Order3, @Prod6, 'Levis 511 Slim Fit Jeans',    3499.00, 2),
(NEWID(), @Order3, @Prod7, 'Nike Dri-FIT Running T-Shirt', 1999.00, 1);

-- ── Order 4: Ravi — Pending ──────────────────
INSERT INTO [Orders] (
    [Id], [UserId], [CustomerName], [CustomerEmail], [CustomerPhone],
    [BillingAddress], [BillingCity], [BillingState], [BillingPinCode],
    [TrackingId], [Status], [TotalAmount], [CreatedAt]
)
VALUES (
    @Order4, @User3, 'Ravi Singh', 'ravi@gmail.com', '+917063531548',
    '23, Park Street, Salt Lake', 'Kolkata', 'West Bengal', '700091',
    'TRK-RVI001', 0, 3197.00, GETUTCDATE()
);

INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [UnitPrice], [Quantity])
VALUES
(NEWID(), @Order4, @Prod14, 'Boldfit Adjustable Dumbbell Set 20KG', 2499.00, 1),
(NEWID(), @Order4, @Prod15, 'Cosco Yoga Mat 6mm',                   699.00,  1);  -- full price (not discounted)

-- ── Order 5: Ravi — Cancelled ────────────────
INSERT INTO [Orders] (
    [Id], [UserId], [CustomerName], [CustomerEmail], [CustomerPhone],
    [BillingAddress], [BillingCity], [BillingState], [BillingPinCode],
    [TrackingId], [Status], [TotalAmount], [CreatedAt], [UpdatedAt]
)
VALUES (
    @Order5, @User3, 'Ravi Singh', 'ravi@gmail.com', '+917063531548',
    '23, Park Street, Salt Lake', 'Kolkata', 'West Bengal', '700091',
    'TRK-RVI002', 5, 649.00, DATEADD(DAY, -10, GETUTCDATE()), DATEADD(DAY, -9, GETUTCDATE())
);

INSERT INTO [OrderItems] ([Id], [OrderId], [ProductId], [ProductName], [UnitPrice], [Quantity])
VALUES
(NEWID(), @Order5, @Prod11, 'Clean Code by Robert C. Martin', 649.00, 1);

GO

-- ─────────────────────────────────────────────
-- VERIFY
-- ─────────────────────────────────────────────
SELECT
    o.[TrackingId],
    o.[CustomerName],
    o.[CustomerEmail],
    CASE o.[Status]
        WHEN 0 THEN 'Pending'
        WHEN 1 THEN 'Confirmed'
        WHEN 2 THEN 'Processing'
        WHEN 3 THEN 'Shipped'
        WHEN 4 THEN 'Delivered'
        WHEN 5 THEN 'Cancelled'
        WHEN 6 THEN 'Refunded'
    END AS StatusName,
    o.[TotalAmount],
    o.[BillingCity],
    o.[CreatedAt]
FROM [Orders] o
ORDER BY o.[CreatedAt] DESC;

SELECT
    o.[TrackingId],
    oi.[ProductName],
    oi.[UnitPrice],
    oi.[Quantity],
    (oi.[UnitPrice] * oi.[Quantity]) AS SubTotal
FROM [Orders] o
JOIN [OrderItems] oi ON oi.[OrderId] = o.[Id]
ORDER BY o.[TrackingId];