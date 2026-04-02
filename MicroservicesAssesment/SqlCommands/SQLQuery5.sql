USE [ECommerceMSPaymentDb];
GO

-- ─────────────────────────────────────────────
-- Payments — linked to Order IDs from OrderDb
-- ─────────────────────────────────────────────
-- PaymentStatus Enum:
-- 0=Pending, 1=Completed, 2=Failed, 3=Refunded

DECLARE @Order1 UNIQUEIDENTIFIER = 'E1000000-0000-0000-0000-000000000001'; -- Delivered → Completed
DECLARE @Order2 UNIQUEIDENTIFIER = 'E2000000-0000-0000-0000-000000000002'; -- Shipped  → Completed
DECLARE @Order3 UNIQUEIDENTIFIER = 'E3000000-0000-0000-0000-000000000003'; -- Confirmed → Completed (UPI)
DECLARE @Order4 UNIQUEIDENTIFIER = 'E4000000-0000-0000-0000-000000000004'; -- Pending  → Pending (COD)
DECLARE @Order5 UNIQUEIDENTIFIER = 'E5000000-0000-0000-0000-000000000005'; -- Cancelled → Refunded

DECLARE @User1 NVARCHAR(450) = 'A3000000-0000-0000-0000-000000000003'; -- Amit
DECLARE @User2 NVARCHAR(450) = 'A4000000-0000-0000-0000-000000000004'; -- Sneha
DECLARE @User3 NVARCHAR(450) = 'A5000000-0000-0000-0000-000000000005'; -- Ravi

INSERT INTO [Payments] (
    [Id], [OrderId], [UserId], [Amount], [Currency], [Method],
    [Status], [RazorpayOrderId], [RazorpayPaymentId], [RazorpaySignature],
    [PaidAt], [CreatedAt], [UpdatedAt]
)
VALUES

-- Payment 1: Amit — Card — Completed (Razorpay)
(NEWID(), @Order1, @User1, 134997.00, 'INR', 'Card',
 1,
 'order_rzp_test_001',
 'pay_rzp_test_001',
 'signature_rzp_hash_001',
 DATEADD(DAY, -15, GETUTCDATE()),
 DATEADD(DAY, -15, GETUTCDATE()),
 DATEADD(DAY, -15, GETUTCDATE())),

-- Payment 2: Amit — UPI — Completed (Razorpay)
(NEWID(), @Order2, @User1, 1148.00, 'INR', 'UPI',
 1,
 'order_rzp_test_002',
 'pay_rzp_test_002',
 'signature_rzp_hash_002',
 DATEADD(DAY, -5, GETUTCDATE()),
 DATEADD(DAY, -5, GETUTCDATE()),
 DATEADD(DAY, -5, GETUTCDATE())),

-- Payment 3: Sneha — UPI — Completed
(NEWID(), @Order3, @User2, 8497.00, 'INR', 'UPI',
 1,
 'order_rzp_test_003',
 'pay_rzp_test_003',
 'signature_rzp_hash_003',
 DATEADD(DAY, -2, GETUTCDATE()),
 DATEADD(DAY, -2, GETUTCDATE()),
 DATEADD(DAY, -2, GETUTCDATE())),

-- Payment 4: Ravi — COD — Pending (no razorpay)
(NEWID(), @Order4, @User3, 3197.00, 'INR', 'COD',
 0,
 NULL, NULL, NULL,
 NULL,
 GETUTCDATE(),
 NULL),

-- Payment 5: Ravi — Card — Refunded (cancelled order)
(NEWID(), @Order5, @User3, 649.00, 'INR', 'Card',
 3,
 'order_rzp_test_005',
 'pay_rzp_test_005',
 'signature_rzp_hash_005',
 DATEADD(DAY, -10, GETUTCDATE()),
 DATEADD(DAY, -10, GETUTCDATE()),
 DATEADD(DAY, -9, GETUTCDATE()));

GO

-- ─────────────────────────────────────────────
-- VERIFY
-- ─────────────────────────────────────────────
SELECT
    p.[OrderId],
    p.[UserId],
    p.[Amount],
    p.[Method],
    CASE p.[Status]
        WHEN 0 THEN 'Pending'
        WHEN 1 THEN 'Completed'
        WHEN 2 THEN 'Failed'
        WHEN 3 THEN 'Refunded'
    END AS StatusName,
    p.[RazorpayOrderId],
    p.[PaidAt],
    p.[CreatedAt]
FROM [Payments] p
ORDER BY p.[CreatedAt] DESC;