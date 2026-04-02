USE [ECommerceMSNotificationDb];
GO

-- ─────────────────────────────────────────────
-- Notification Logs
-- ─────────────────────────────────────────────
INSERT INTO [NotificationLogs] (
    [Id], [Channel], [Recipient], [Subject], [Message],
    [IsSuccess], [ErrorMessage], [CreatedAt]
)
VALUES

-- ── Registration Emails ───────────────────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Welcome to E-Commerce Platform!',
 '<h2>Hi Amit!</h2><p>Thank you for registering. Start shopping now!</p>',
 1, NULL, DATEADD(DAY, -20, GETUTCDATE())),

(NEWID(), 'Email', 'sneha@gmail.com',
 'Welcome to E-Commerce Platform!',
 '<h2>Hi Sneha!</h2><p>Thank you for registering. Explore our products now!</p>',
 1, NULL, DATEADD(DAY, -18, GETUTCDATE())),

(NEWID(), 'Email', 'ravi@gmail.com',
 'Welcome to E-Commerce Platform!',
 '<h2>Hi Ravi!</h2><p>Welcome aboard! Shop the best deals today.</p>',
 1, NULL, DATEADD(DAY, -12, GETUTCDATE())),

-- ── OTP Notifications ─────────────────────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Your OTP - MFA',
 '<h2>Your OTP is: <strong>482910</strong></h2><p>Valid for 10 minutes.</p>',
 1, NULL, DATEADD(DAY, -10, GETUTCDATE())),

(NEWID(), 'SMS', '+917063531548',
 'OTP Verification',
 'Your OTP is: 739201. Valid for 10 minutes. Do not share with anyone. - E-Commerce',
 1, NULL, DATEADD(DAY, -8, GETUTCDATE())),

(NEWID(), 'WhatsApp', '+917063531548',
 'OTP via WhatsApp',
 'Your OTP is: 556734. Valid for 10 minutes. Do not share with anyone. - E-Commerce Platform',
 1, NULL, DATEADD(DAY, -6, GETUTCDATE())),

-- ── Order Confirmation Notifications ─────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Order Confirmed - TRK-AMT001',
 '<h2>Order Confirmed!</h2><p>Your order #TRK-AMT001 has been confirmed. Total: ₹1,34,997</p>',
 1, NULL, DATEADD(DAY, -15, GETUTCDATE())),

(NEWID(), 'WhatsApp', '+917063531548',
 'Order Confirmation',
 'Hi Amit! Your order #TRK-AMT001 is confirmed. Total: ₹1,34,997. Track: TRK-AMT001. - E-Commerce',
 1, NULL, DATEADD(DAY, -15, GETUTCDATE())),

(NEWID(), 'Email', 'sneha@gmail.com',
 'Order Confirmed - TRK-SNH001',
 '<h2>Order Confirmed!</h2><p>Your order #TRK-SNH001 has been placed. Total: ₹8,497</p>',
 1, NULL, DATEADD(DAY, -2, GETUTCDATE())),

(NEWID(), 'SMS', '+917063531548',
 'Order Confirmation',
 'Hi Sneha! Order #TRK-SNH001 confirmed. Total: Rs.8,497. Track your order on our app. - ECommerce',
 1, NULL, DATEADD(DAY, -2, GETUTCDATE())),

-- ── Payment Notifications ─────────────────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Payment Successful - ₹1,34,997',
 '<h2>Payment Received!</h2><p>Payment of ₹1,34,997 for Order #TRK-AMT001 was successful via Card.</p>',
 1, NULL, DATEADD(DAY, -15, GETUTCDATE())),

(NEWID(), 'WhatsApp', '+917063531548',
 'Payment Successful',
 'Payment of ₹1,34,997 received for Order #TRK-AMT001. Payment ID: pay_rzp_test_001. Thank you! - E-Commerce',
 1, NULL, DATEADD(DAY, -15, GETUTCDATE())),

-- ── Shipping Notifications ─────────────────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Your Order is Shipped - TRK-AMT002',
 '<h2>Order Shipped!</h2><p>Order #TRK-AMT002 has been shipped. Expected delivery in 2-3 days.</p>',
 1, NULL, DATEADD(DAY, -3, GETUTCDATE())),

(NEWID(), 'SMS', '+917063531548',
 'Order Shipped',
 'Hi Amit! Order #TRK-AMT002 has been shipped. Expected delivery: 2 days. Track: TRK-AMT002',
 1, NULL, DATEADD(DAY, -3, GETUTCDATE())),

-- ── Delivery Notifications ─────────────────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Order Delivered - TRK-AMT001',
 '<h2>Order Delivered!</h2><p>Your order #TRK-AMT001 has been delivered. Enjoy your purchase!</p>',
 1, NULL, DATEADD(DAY, -8, GETUTCDATE())),

(NEWID(), 'WhatsApp', '+917063531548',
 'Order Delivered',
 'Great news Amit! Order #TRK-AMT001 has been delivered. Rate your experience on our app! - E-Commerce',
 1, NULL, DATEADD(DAY, -8, GETUTCDATE())),

-- ── Invoice Notifications ──────────────────────────────────────────────────
(NEWID(), 'Email', 'amit@gmail.com',
 'Invoice for Order #TRK-AMT001',
 '<h2>Invoice Ready</h2><p>Your invoice for Order #TRK-AMT001 is ready. Download: http://localhost:5040/api/v1/orders/E1000000-0000-0000-0000-000000000001/invoice</p>',
 1, NULL, DATEADD(DAY, -8, GETUTCDATE())),

-- ── Cancellation Notification ──────────────────────────────────────────────
(NEWID(), 'Email', 'ravi@gmail.com',
 'Order Cancelled - TRK-RVI002',
 '<h2>Order Cancelled</h2><p>Your order #TRK-RVI002 has been cancelled. Refund will be processed in 5-7 business days.</p>',
 1, NULL, DATEADD(DAY, -9, GETUTCDATE())),

(NEWID(), 'SMS', '+917063531548',
 'Order Cancellation',
 'Hi Ravi! Order #TRK-RVI002 cancelled. Refund of Rs.649 will be credited in 5-7 days. - ECommerce',
 1, NULL, DATEADD(DAY, -9, GETUTCDATE())),

-- ── Failed Notification (for testing error handling) ──────────────────────
(NEWID(), 'SMS', '+917063531548',
 'Failed SMS Test',
 'Test message that failed due to invalid number format.',
 0, 'Twilio Error: Invalid phone number format. Use E.164 format (+91XXXXXXXXXX).', DATEADD(DAY, -1, GETUTCDATE()));

GO

-- ─────────────────────────────────────────────
-- VERIFY
-- ─────────────────────────────────────────────
SELECT
    [Channel],
    [Recipient],
    [Subject],
    [IsSuccess],
    [ErrorMessage],
    [CreatedAt]
FROM [NotificationLogs]
ORDER BY [CreatedAt] DESC;

-- Summary by Channel
SELECT
    [Channel],
    COUNT(*)                             AS TotalSent,
    SUM(CASE WHEN [IsSuccess] = 1 THEN 1 ELSE 0 END) AS Successful,
    SUM(CASE WHEN [IsSuccess] = 0 THEN 1 ELSE 0 END) AS Failed
FROM [NotificationLogs]
GROUP BY [Channel]
ORDER BY [Channel];