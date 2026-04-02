-- Run in ECommerceMSUserDb
USE [ECommerceMSUserDb];
SELECT 'Users'   AS Entity, COUNT(*) AS Count FROM [AspNetUsers]
UNION ALL
SELECT 'Roles',               COUNT(*) FROM [AspNetRoles]
UNION ALL
SELECT 'UserRoles',           COUNT(*) FROM [AspNetUserRoles]
UNION ALL
SELECT 'OtpRecords',          COUNT(*) FROM [OtpRecords];

-- Run in ECommerceMSProductDb
USE [ECommerceMSProductDb];
SELECT 'Categories' AS Entity, COUNT(*) AS Count FROM [Categories]
UNION ALL
SELECT 'Products',             COUNT(*) FROM [Products];

-- Run in ECommerceMSCartDb
USE [ECommerceMSCartDb];
SELECT 'Carts'     AS Entity, COUNT(*) AS Count FROM [Carts]
UNION ALL
SELECT 'CartItems',            COUNT(*) FROM [CartItems];

-- Run in ECommerceMSOrderDb
USE [ECommerceMSOrderDb];
SELECT 'Orders'    AS Entity, COUNT(*) AS Count FROM [Orders]
UNION ALL
SELECT 'OrderItems',           COUNT(*) FROM [OrderItems];

-- Run in ECommerceMSPaymentDb
USE [ECommerceMSPaymentDb];
SELECT 'Payments'  AS Entity, COUNT(*) AS Count FROM [Payments];

-- Run in ECommerceMSNotificationDb
USE [ECommerceMSNotificationDb];
SELECT 'NotificationLogs' AS Entity, COUNT(*) AS Count FROM [NotificationLogs];