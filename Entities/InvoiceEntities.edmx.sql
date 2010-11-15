
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 08/15/2010 07:13:48
-- Generated from EDMX file: C:\Progetti\Estro\DesktopClient\EstroManager\EstroEntities\InvoiceEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Test];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_InvoiceCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Invoices] DROP CONSTRAINT [FK_InvoiceCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceInvoiceLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceLines] DROP CONSTRAINT [FK_InvoiceInvoiceLine];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceLineProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceLines] DROP CONSTRAINT [FK_InvoiceLineProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderCustomer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_OrderCustomer];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceOrder_Invoice]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceOrder] DROP CONSTRAINT [FK_InvoiceOrder_Invoice];
GO
IF OBJECT_ID(N'[dbo].[FK_InvoiceOrder_Order]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvoiceOrder] DROP CONSTRAINT [FK_InvoiceOrder_Order];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderLines] DROP CONSTRAINT [FK_OrderOrderLine];
GO
IF OBJECT_ID(N'[dbo].[FK_OrderOrderNote]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrderNotes] DROP CONSTRAINT [FK_OrderOrderNote];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Customers];
GO
IF OBJECT_ID(N'[dbo].[Invoices]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Invoices];
GO
IF OBJECT_ID(N'[dbo].[InvoiceLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceLines];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Orders]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Orders];
GO
IF OBJECT_ID(N'[dbo].[OrderLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderLines];
GO
IF OBJECT_ID(N'[dbo].[OrderNotes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderNotes];
GO
IF OBJECT_ID(N'[dbo].[InvoiceOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvoiceOrder];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [CustomerId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Invoices'
CREATE TABLE [dbo].[Invoices] (
    [InvoiceId] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [CustomerName] nvarchar(max)  NOT NULL,
    [CustomerAddress] nvarchar(max)  NOT NULL,
    [Total] decimal(18,0)  NOT NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'InvoiceLines'
CREATE TABLE [dbo].[InvoiceLines] (
    [InvoiceLineId] int IDENTITY(1,1) NOT NULL,
    [Line] int  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [SmallText] nvarchar(max)  NULL,
    [NumberOfItems] int  NOT NULL,
    [SubTotal] decimal(18,0)  NOT NULL,
    [InvoiceId] int  NOT NULL,
    [ProductId] int  NULL,
    [Quantity] int  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Price] decimal(18,0)  NOT NULL,
    [ValidFrom] datetime  NOT NULL,
    [ValidTo] datetime  NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [OrderId] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [DeliveryDate] datetime  NULL,
    [CustomerId] int  NOT NULL
);
GO

-- Creating table 'OrderLines'
CREATE TABLE [dbo].[OrderLines] (
    [OrderLineId] int IDENTITY(1,1) NOT NULL,
    [Quantity] int  NOT NULL,
    [ProductName] nvarchar(max)  NOT NULL,
    [Line] int  NOT NULL,
    [OrderId] int  NOT NULL,
    [Product_ProductId] int  NOT NULL
);
GO

-- Creating table 'OrderNotes'
CREATE TABLE [dbo].[OrderNotes] (
    [OrderNoteId] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [OrderId] int  NOT NULL
);
GO

-- Creating table 'InvoiceNotes'
CREATE TABLE [dbo].[InvoiceNotes] (
    [InvoiceNoteId] int IDENTITY(1,1) NOT NULL,
    [CreationDate] datetime  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [InvoiceId] int  NOT NULL
);
GO

-- Creating table 'InvoiceOrder'
CREATE TABLE [dbo].[InvoiceOrder] (
    [Invoices_InvoiceId] int  NOT NULL,
    [Orders_OrderId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CustomerId] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([CustomerId] ASC);
GO

-- Creating primary key on [InvoiceId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [PK_Invoices]
    PRIMARY KEY CLUSTERED ([InvoiceId] ASC);
GO

-- Creating primary key on [InvoiceLineId] in table 'InvoiceLines'
ALTER TABLE [dbo].[InvoiceLines]
ADD CONSTRAINT [PK_InvoiceLines]
    PRIMARY KEY CLUSTERED ([InvoiceLineId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [OrderId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([OrderId] ASC);
GO

-- Creating primary key on [OrderLineId] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [PK_OrderLines]
    PRIMARY KEY CLUSTERED ([OrderLineId] ASC);
GO

-- Creating primary key on [OrderNoteId] in table 'OrderNotes'
ALTER TABLE [dbo].[OrderNotes]
ADD CONSTRAINT [PK_OrderNotes]
    PRIMARY KEY CLUSTERED ([OrderNoteId] ASC);
GO

-- Creating primary key on [InvoiceNoteId] in table 'InvoiceNotes'
ALTER TABLE [dbo].[InvoiceNotes]
ADD CONSTRAINT [PK_InvoiceNotes]
    PRIMARY KEY CLUSTERED ([InvoiceNoteId] ASC);
GO

-- Creating primary key on [Invoices_InvoiceId], [Orders_OrderId] in table 'InvoiceOrder'
ALTER TABLE [dbo].[InvoiceOrder]
ADD CONSTRAINT [PK_InvoiceOrder]
    PRIMARY KEY NONCLUSTERED ([Invoices_InvoiceId], [Orders_OrderId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CustomerId] in table 'Invoices'
ALTER TABLE [dbo].[Invoices]
ADD CONSTRAINT [FK_InvoiceCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceCustomer'
CREATE INDEX [IX_FK_InvoiceCustomer]
ON [dbo].[Invoices]
    ([CustomerId]);
GO

-- Creating foreign key on [InvoiceId] in table 'InvoiceLines'
ALTER TABLE [dbo].[InvoiceLines]
ADD CONSTRAINT [FK_InvoiceInvoiceLine]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceInvoiceLine'
CREATE INDEX [IX_FK_InvoiceInvoiceLine]
ON [dbo].[InvoiceLines]
    ([InvoiceId]);
GO

-- Creating foreign key on [ProductId] in table 'InvoiceLines'
ALTER TABLE [dbo].[InvoiceLines]
ADD CONSTRAINT [FK_InvoiceLineProduct]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceLineProduct'
CREATE INDEX [IX_FK_InvoiceLineProduct]
ON [dbo].[InvoiceLines]
    ([ProductId]);
GO

-- Creating foreign key on [CustomerId] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_OrderCustomer]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[Customers]
        ([CustomerId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderCustomer'
CREATE INDEX [IX_FK_OrderCustomer]
ON [dbo].[Orders]
    ([CustomerId]);
GO

-- Creating foreign key on [Invoices_InvoiceId] in table 'InvoiceOrder'
ALTER TABLE [dbo].[InvoiceOrder]
ADD CONSTRAINT [FK_InvoiceOrder_Invoice]
    FOREIGN KEY ([Invoices_InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Orders_OrderId] in table 'InvoiceOrder'
ALTER TABLE [dbo].[InvoiceOrder]
ADD CONSTRAINT [FK_InvoiceOrder_Order]
    FOREIGN KEY ([Orders_OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceOrder_Order'
CREATE INDEX [IX_FK_InvoiceOrder_Order]
ON [dbo].[InvoiceOrder]
    ([Orders_OrderId]);
GO

-- Creating foreign key on [OrderId] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [FK_OrderOrderLine]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderLine'
CREATE INDEX [IX_FK_OrderOrderLine]
ON [dbo].[OrderLines]
    ([OrderId]);
GO

-- Creating foreign key on [OrderId] in table 'OrderNotes'
ALTER TABLE [dbo].[OrderNotes]
ADD CONSTRAINT [FK_OrderOrderNote]
    FOREIGN KEY ([OrderId])
    REFERENCES [dbo].[Orders]
        ([OrderId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderNote'
CREATE INDEX [IX_FK_OrderOrderNote]
ON [dbo].[OrderNotes]
    ([OrderId]);
GO

-- Creating foreign key on [Product_ProductId] in table 'OrderLines'
ALTER TABLE [dbo].[OrderLines]
ADD CONSTRAINT [FK_OrderLineProduct]
    FOREIGN KEY ([Product_ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderLineProduct'
CREATE INDEX [IX_FK_OrderLineProduct]
ON [dbo].[OrderLines]
    ([Product_ProductId]);
GO

-- Creating foreign key on [InvoiceId] in table 'InvoiceNotes'
ALTER TABLE [dbo].[InvoiceNotes]
ADD CONSTRAINT [FK_InvoiceNoteInvoice]
    FOREIGN KEY ([InvoiceId])
    REFERENCES [dbo].[Invoices]
        ([InvoiceId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvoiceNoteInvoice'
CREATE INDEX [IX_FK_InvoiceNoteInvoice]
ON [dbo].[InvoiceNotes]
    ([InvoiceId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------