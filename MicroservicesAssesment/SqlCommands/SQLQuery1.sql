
USE [ECommerceMSProductDb];
GO

-- ─────────────────────────────────────────────
-- Categories
-- ─────────────────────────────────────────────
DECLARE @Cat1 UNIQUEIDENTIFIER = 'B1000000-0000-0000-0000-000000000001'; -- Electronics
DECLARE @Cat2 UNIQUEIDENTIFIER = 'B2000000-0000-0000-0000-000000000002'; -- Clothing
DECLARE @Cat3 UNIQUEIDENTIFIER = 'B3000000-0000-0000-0000-000000000003'; -- Books
DECLARE @Cat4 UNIQUEIDENTIFIER = 'B4000000-0000-0000-0000-000000000004'; -- Home & Kitchen
DECLARE @Cat5 UNIQUEIDENTIFIER = 'B5000000-0000-0000-0000-000000000005'; -- Sports & Fitness

INSERT INTO [Categories] ([Id], [Name], [Description], [ImageUrl], [IsActive], [CreatedAt])
VALUES
(@Cat1, 'Electronics',    'Mobiles, Laptops, Accessories, Gadgets',        '/uploads/categories/electronics.jpg',  1, GETUTCDATE()),
(@Cat2, 'Clothing',       'Men, Women, Kids Fashion and Apparel',           '/uploads/categories/clothing.jpg',     1, GETUTCDATE()),
(@Cat3, 'Books',          'Fiction, Non-Fiction, Academic, Self-help',      '/uploads/categories/books.jpg',        1, GETUTCDATE()),
(@Cat4, 'Home & Kitchen', 'Cookware, Furniture, Decor, Appliances',         '/uploads/categories/home.jpg',         1, GETUTCDATE()),
(@Cat5, 'Sports & Fitness','Gym Equipment, Sportswear, Accessories',        '/uploads/categories/sports.jpg',       1, GETUTCDATE());

GO

-- ─────────────────────────────────────────────
-- Products
-- ─────────────────────────────────────────────
DECLARE @Cat1 UNIQUEIDENTIFIER = 'B1000000-0000-0000-0000-000000000001';
DECLARE @Cat2 UNIQUEIDENTIFIER = 'B2000000-0000-0000-0000-000000000002';
DECLARE @Cat3 UNIQUEIDENTIFIER = 'B3000000-0000-0000-0000-000000000003';
DECLARE @Cat4 UNIQUEIDENTIFIER = 'B4000000-0000-0000-0000-000000000004';
DECLARE @Cat5 UNIQUEIDENTIFIER = 'B5000000-0000-0000-0000-000000000005';

-- Fixed Product IDs (needed for Cart & Order sample data)
DECLARE @Prod1  UNIQUEIDENTIFIER = 'C1000000-0000-0000-0000-000000000001';
DECLARE @Prod2  UNIQUEIDENTIFIER = 'C2000000-0000-0000-0000-000000000002';
DECLARE @Prod3  UNIQUEIDENTIFIER = 'C3000000-0000-0000-0000-000000000003';
DECLARE @Prod4  UNIQUEIDENTIFIER = 'C4000000-0000-0000-0000-000000000004';
DECLARE @Prod5  UNIQUEIDENTIFIER = 'C5000000-0000-0000-0000-000000000005';
DECLARE @Prod6  UNIQUEIDENTIFIER = 'C6000000-0000-0000-0000-000000000006';
DECLARE @Prod7  UNIQUEIDENTIFIER = 'C7000000-0000-0000-0000-000000000007';
DECLARE @Prod8  UNIQUEIDENTIFIER = 'C8000000-0000-0000-0000-000000000008';
DECLARE @Prod9  UNIQUEIDENTIFIER = 'C9000000-0000-0000-0000-000000000009';
DECLARE @Prod10 UNIQUEIDENTIFIER = 'CA000000-0000-0000-0000-000000000010';
DECLARE @Prod11 UNIQUEIDENTIFIER = 'CB000000-0000-0000-0000-000000000011';
DECLARE @Prod12 UNIQUEIDENTIFIER = 'CC000000-0000-0000-0000-000000000012';
DECLARE @Prod13 UNIQUEIDENTIFIER = 'CD000000-0000-0000-0000-000000000013';
DECLARE @Prod14 UNIQUEIDENTIFIER = 'CE000000-0000-0000-0000-000000000014';
DECLARE @Prod15 UNIQUEIDENTIFIER = 'CF000000-0000-0000-0000-000000000015';

INSERT INTO [Products] (
    [Id], [Name], [Description], [Price], [DiscountPrice],
    [StockQuantity], [SKU], [ImageUrl], [IsActive], [CategoryId], [CreatedAt]
)
VALUES

-- ── Electronics ──────────────────────────────────────────────────────────
(@Prod1,
 'Samsung Galaxy S24 Ultra',
 'Flagship smartphone with 200MP camera, Snapdragon 8 Gen 3, 5000mAh battery, 12GB RAM, 256GB storage.',
 124999.00, 109999.00, 45,
 'ELEC-SGS24U-001', '/uploads/products/samsung-s24.jpg', 1, @Cat1, GETUTCDATE()),

(@Prod2,
 'Apple MacBook Air M3',
 '13.6-inch Liquid Retina display, Apple M3 chip, 16GB RAM, 512GB SSD, 18-hour battery life.',
 114999.00, 109999.00, 30,
 'ELEC-MBAM3-002', '/uploads/products/macbook-air.jpg', 1, @Cat1, GETUTCDATE()),

(@Prod3,
 'Sony WH-1000XM5 Headphones',
 'Industry-leading noise cancelling wireless headphones, 30-hour battery, multipoint connection.',
 29999.00, 24999.00, 120,
 'ELEC-SNYWH5-003', '/uploads/products/sony-headphones.jpg', 1, @Cat1, GETUTCDATE()),

(@Prod4,
 'Logitech MX Master 3S Mouse',
 'Advanced wireless mouse, MagSpeed scroll wheel, 8000 DPI, ergonomic design, USB-C charging.',
 8999.00, 7499.00, 200,
 'ELEC-LGMXM3-004', '/uploads/products/logitech-mouse.jpg', 1, @Cat1, GETUTCDATE()),

(@Prod5,
 'OnePlus Nord CE 4',
 '6.7-inch AMOLED display, Snapdragon 7s Gen 3, 50MP OIS camera, 100W SUPERVOOC charging.',
 24999.00, 22999.00, 80,
 'ELEC-OPNCE4-005', '/uploads/products/oneplus-nord.jpg', 1, @Cat1, GETUTCDATE()),

-- ── Clothing ──────────────────────────────────────────────────────────────
(@Prod6,
 'Levis 511 Slim Fit Jeans',
 'Classic slim fit jeans in stretch denim. Available in dark indigo wash. 98% Cotton, 2% Elastane.',
 3499.00, 2799.00, 300,
 'CLTH-LV511-006', '/uploads/products/levis-jeans.jpg', 1, @Cat2, GETUTCDATE()),

(@Prod7,
 'Nike Dri-FIT Running T-Shirt',
 'Lightweight, breathable fabric with sweat-wicking technology. Perfect for outdoor and gym workouts.',
 1999.00, 1499.00, 500,
 'CLTH-NKDFT-007', '/uploads/products/nike-tshirt.jpg', 1, @Cat2, GETUTCDATE()),

(@Prod8,
 'Zara Women Floral Kurta Set',
 'Elegant floral printed kurta with matching palazzo. Pure cotton fabric, machine washable.',
 2999.00, 2299.00, 150,
 'CLTH-ZRKRT-008', '/uploads/products/zara-kurta.jpg', 1, @Cat2, GETUTCDATE()),

-- ── Books ──────────────────────────────────────────────────────────────────
(@Prod9,
 'Atomic Habits by James Clear',
 'An easy and proven way to build good habits and break bad ones. Bestseller with 10M+ copies sold.',
 499.00, 349.00, 1000,
 'BOOK-ATMHBT-009', '/uploads/products/atomic-habits.jpg', 1, @Cat3, GETUTCDATE()),

(@Prod10,
 'The Psychology of Money',
 'Timeless lessons on wealth, greed, and happiness by Morgan Housel. 256 pages, Paperback.',
 449.00, 299.00, 750,
 'BOOK-PSYMNY-010', '/uploads/products/psychology-money.jpg', 1, @Cat3, GETUTCDATE()),

(@Prod11,
 'Clean Code by Robert C. Martin',
 'A handbook of Agile Software Craftsmanship. Must-read for every software developer.',
 799.00, 649.00, 400,
 'BOOK-CLNCDE-011', '/uploads/products/clean-code.jpg', 1, @Cat3, GETUTCDATE()),

-- ── Home & Kitchen ──────────────────────────────────────────────────────────
(@Prod12,
 'Prestige Induction Cooktop',
 '2000W induction cooktop with 7 preset menus, feather touch controls, auto voltage regulator.',
 3299.00, 2799.00, 180,
 'HOME-PRGICT-012', '/uploads/products/prestige-induction.jpg', 1, @Cat4, GETUTCDATE()),

(@Prod13,
 'Milton Thermosteel Flask 1L',
 'Double wall insulated stainless steel flask. Keeps hot 24 hours, cold 36 hours. Leak-proof.',
 899.00, 699.00, 600,
 'HOME-MLTFLK-013', '/uploads/products/milton-flask.jpg', 1, @Cat4, GETUTCDATE()),

-- ── Sports & Fitness ──────────────────────────────────────────────────────────
(@Prod14,
 'Boldfit Adjustable Dumbbell Set 20KG',
 'Adjustable dumbbell pair with weight plates. Suitable for home gym. Anti-slip grip handle.',
 2499.00, 1999.00, 90,
 'SPRT-BFADS-014', '/uploads/products/dumbbell-set.jpg', 1, @Cat5, GETUTCDATE()),

(@Prod15,
 'Cosco Yoga Mat 6mm',
 'Anti-slip yoga mat with carrying strap. 183cm x 61cm. Eco-friendly TPE material.',
 799.00, 599.00, 350,
 'SPRT-CSYMT-015', '/uploads/products/yoga-mat.jpg', 1, @Cat5, GETUTCDATE());

GO

-- ─────────────────────────────────────────────
-- VERIFY
-- ─────────────────────────────────────────────
SELECT
    p.[Name]          AS ProductName,
    p.[Price],
    p.[DiscountPrice],
    p.[StockQuantity],
    p.[SKU],
    c.[Name]          AS CategoryName,
    p.[IsActive]
FROM   [Products] p
JOIN   [Categories] c ON c.[Id] = p.[CategoryId]
ORDER BY c.[Name], p.[Name];

SELECT [Name], [IsActive] FROM [Categories] ORDER BY [Name];