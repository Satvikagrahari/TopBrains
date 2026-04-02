USE [ECommerceMSUserDb];
GO

-- ─────────────────────────────────────────────
-- STEP 1: Ensure Roles exist
-- ─────────────────────────────────────────────
IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [Name] = 'Admin')
    INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'Admin', 'ADMIN', NEWID());

IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [Name] = 'StoreManager')
    INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'StoreManager', 'STOREMANAGER', NEWID());

IF NOT EXISTS (SELECT 1 FROM [AspNetRoles] WHERE [Name] = 'Customer')
    INSERT INTO [AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp])
    VALUES (NEWID(), 'Customer', 'CUSTOMER', NEWID());

GO

-- ─────────────────────────────────────────────
-- STEP 2: Declare User IDs (fixed GUIDs for FK use)
-- ─────────────────────────────────────────────
DECLARE @AdminId     NVARCHAR(450) = 'A1000000-0000-0000-0000-000000000001';
DECLARE @ManagerId   NVARCHAR(450) = 'A2000000-0000-0000-0000-000000000002';
DECLARE @Customer1Id NVARCHAR(450) = 'A3000000-0000-0000-0000-000000000003';
DECLARE @Customer2Id NVARCHAR(450) = 'A4000000-0000-0000-0000-000000000004';
DECLARE @Customer3Id NVARCHAR(450) = 'A5000000-0000-0000-0000-000000000005';

-- ─────────────────────────────────────────────
-- STEP 3: Insert Users
-- Password hash below = "Admin@123" hashed via ASP.NET Identity PBKDF2-SHA256
-- All users share same password: Admin@123
-- ─────────────────────────────────────────────

-- 👤 Admin User
IF NOT EXISTS (SELECT 1 FROM [AspNetUsers] WHERE [Id] = @AdminId)
INSERT INTO [AspNetUsers] (
    [Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail],
    [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
    [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
    [LockoutEnabled], [AccessFailedCount],
    [FirstName], [LastName], [IsActive], [IsMfaEnabled], [CreatedAt]
)
VALUES (
    @AdminId,
    'admin@ecommerce.com', 'ADMIN@ECOMMERCE.COM',
    'admin@ecommerce.com', 'ADMIN@ECOMMERCE.COM',
    1,
    'AQAAAAIAAYagAAAAELwHmGz3P5v6bLMPMZRL3pAh7UgEcXHF4+U1mXKaR/P3Nq9hS3kNVbSwCIbIlDN+xA==',
    NEWID(), NEWID(),
    '+917063531548', 1, 0,
    1, 0,
    'Rajesh', 'Admin',
    1, 0, GETUTCDATE()
);

-- 👤 Store Manager
IF NOT EXISTS (SELECT 1 FROM [AspNetUsers] WHERE [Id] = @ManagerId)
INSERT INTO [AspNetUsers] (
    [Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail],
    [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
    [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
    [LockoutEnabled], [AccessFailedCount],
    [FirstName], [LastName], [IsActive], [IsMfaEnabled], [CreatedAt]
)
VALUES (
    @ManagerId,
    'manager@ecommerce.com', 'MANAGER@ECOMMERCE.COM',
    'manager@ecommerce.com', 'MANAGER@ECOMMERCE.COM',
    1,
    'AQAAAAIAAYagAAAAELwHmGz3P5v6bLMPMZRL3pAh7UgEcXHF4+U1mXKaR/P3Nq9hS3kNVbSwCIbIlDN+xA==',
    NEWID(), NEWID(),
    '+917063531548', 1, 0,
    1, 0,
    'Priya', 'Sharma',
    1, 0, GETUTCDATE()
);

-- 👤 Customer 1
IF NOT EXISTS (SELECT 1 FROM [AspNetUsers] WHERE [Id] = @Customer1Id)
INSERT INTO [AspNetUsers] (
    [Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail],
    [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
    [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
    [LockoutEnabled], [AccessFailedCount],
    [FirstName], [LastName], [IsActive], [IsMfaEnabled], [CreatedAt]
)
VALUES (
    @Customer1Id,
    'amit@gmail.com', 'AMIT@GMAIL.COM',
    'amit@gmail.com', 'AMIT@GMAIL.COM',
    1,
    'AQAAAAIAAYagAAAAELwHmGz3P5v6bLMPMZRL3pAh7UgEcXHF4+U1mXKaR/P3Nq9hS3kNVbSwCIbIlDN+xA==',
    NEWID(), NEWID(),
    '+917063531548', 1, 0,
    1, 0,
    'Amit', 'Kumar',
    1, 0, GETUTCDATE()
);

-- 👤 Customer 2
IF NOT EXISTS (SELECT 1 FROM [AspNetUsers] WHERE [Id] = @Customer2Id)
INSERT INTO [AspNetUsers] (
    [Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail],
    [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
    [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
    [LockoutEnabled], [AccessFailedCount],
    [FirstName], [LastName], [IsActive], [IsMfaEnabled], [CreatedAt]
)
VALUES (
    @Customer2Id,
    'sneha@gmail.com', 'SNEHA@GMAIL.COM',
    'sneha@gmail.com', 'SNEHA@GMAIL.COM',
    1,
    'AQAAAAIAAYagAAAAELwHmGz3P5v6bLMPMZRL3pAh7UgEcXHF4+U1mXKaR/P3Nq9hS3kNVbSwCIbIlDN+xA==',
    NEWID(), NEWID(),
    '+917063531548', 1, 0,
    1, 0,
    'Sneha', 'Patel',
    1, 0, GETUTCDATE()
);

-- 👤 Customer 3
IF NOT EXISTS (SELECT 1 FROM [AspNetUsers] WHERE [Id] = @Customer3Id)
INSERT INTO [AspNetUsers] (
    [Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail],
    [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp],
    [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled],
    [LockoutEnabled], [AccessFailedCount],
    [FirstName], [LastName], [IsActive], [IsMfaEnabled], [CreatedAt]
)
VALUES (
    @Customer3Id,
    'ravi@gmail.com', 'RAVI@GMAIL.COM',
    'ravi@gmail.com', 'RAVI@GMAIL.COM',
    1,
    'AQAAAAIAAYagAAAAELwHmGz3P5v6bLMPMZRL3pAh7UgEcXHF4+U1mXKaR/P3Nq9hS3kNVbSwCIbIlDN+xA==',
    NEWID(), NEWID(),
    '+917063531548', 1, 0,
    1, 0,
    'Ravi', 'Singh',
    1, 0, GETUTCDATE()
);

GO

-- ─────────────────────────────────────────────
-- STEP 4: Assign Roles to Users
-- ─────────────────────────────────────────────
DECLARE @AdminId     NVARCHAR(450) = 'A1000000-0000-0000-0000-000000000001';
DECLARE @ManagerId   NVARCHAR(450) = 'A2000000-0000-0000-0000-000000000002';
DECLARE @Customer1Id NVARCHAR(450) = 'A3000000-0000-0000-0000-000000000003';
DECLARE @Customer2Id NVARCHAR(450) = 'A4000000-0000-0000-0000-000000000004';
DECLARE @Customer3Id NVARCHAR(450) = 'A5000000-0000-0000-0000-000000000005';

DECLARE @AdminRoleId    NVARCHAR(450) = (SELECT [Id] FROM [AspNetRoles] WHERE [Name] = 'Admin');
DECLARE @ManagerRoleId  NVARCHAR(450) = (SELECT [Id] FROM [AspNetRoles] WHERE [Name] = 'StoreManager');
DECLARE @CustomerRoleId NVARCHAR(450) = (SELECT [Id] FROM [AspNetRoles] WHERE [Name] = 'Customer');

-- Admin role
IF NOT EXISTS (SELECT 1 FROM [AspNetUserRoles] WHERE [UserId] = @AdminId AND [RoleId] = @AdminRoleId)
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (@AdminId, @AdminRoleId);

-- StoreManager role
IF NOT EXISTS (SELECT 1 FROM [AspNetUserRoles] WHERE [UserId] = @ManagerId AND [RoleId] = @ManagerRoleId)
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (@ManagerId, @ManagerRoleId);

-- Customer roles
IF NOT EXISTS (SELECT 1 FROM [AspNetUserRoles] WHERE [UserId] = @Customer1Id AND [RoleId] = @CustomerRoleId)
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (@Customer1Id, @CustomerRoleId);

IF NOT EXISTS (SELECT 1 FROM [AspNetUserRoles] WHERE [UserId] = @Customer2Id AND [RoleId] = @CustomerRoleId)
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (@Customer2Id, @CustomerRoleId);

IF NOT EXISTS (SELECT 1 FROM [AspNetUserRoles] WHERE [UserId] = @Customer3Id AND [RoleId] = @CustomerRoleId)
    INSERT INTO [AspNetUserRoles] ([UserId], [RoleId]) VALUES (@Customer3Id, @CustomerRoleId);

GO

-- ─────────────────────────────────────────────
-- STEP 5: Sample OTP Records
-- ─────────────────────────────────────────────
INSERT INTO [OtpRecords] ([Id], [UserId], [OtpCode], [Purpose], [Channel], [ExpiresAt], [IsUsed], [CreatedAt])
VALUES
(NEWID(), 'A3000000-0000-0000-0000-000000000003', '482910', 'EmailVerification', 'Email',
 DATEADD(MINUTE, 10, GETUTCDATE()), 0, GETUTCDATE()),

(NEWID(), 'A4000000-0000-0000-0000-000000000004', '739201', 'MFA', 'SMS',
 DATEADD(MINUTE, 10, GETUTCDATE()), 0, GETUTCDATE()),

(NEWID(), 'A5000000-0000-0000-0000-000000000005', '556734', 'PasswordReset', 'WhatsApp',
 DATEADD(MINUTE, -5, GETUTCDATE()), 1, GETUTCDATE()); -- already expired & used

GO

-- ─────────────────────────────────────────────
-- VERIFY
-- ─────────────────────────────────────────────
SELECT u.[FirstName], u.[LastName], u.[Email], u.[PhoneNumber], r.[Name] AS [Role], u.[IsActive]
FROM   [AspNetUsers] u
JOIN   [AspNetUserRoles] ur ON u.[Id] = ur.[UserId]
JOIN   [AspNetRoles] r      ON r.[Id] = ur.[RoleId]
ORDER BY r.[Name];

SELECT * FROM [OtpRecords];
```

---

# ⚠️ Password Hash Note

The hash in the script above is a **placeholder**. Because ASP.NET Identity uses a salt + PBKDF2-SHA256 that changes every time, you have **two clean options**:

**Option A (Recommended — Easiest):** Register all users via the Swagger API first, then run only Steps 4 and 5 from the SQL above to assign roles and add OTP records.

**Option B:** After inserting with the placeholder hash, call this endpoint in Swagger:
```
POST /api/v1/auth/login
{ "email": "admin@ecommerce.com", "password": "Admin@123" }