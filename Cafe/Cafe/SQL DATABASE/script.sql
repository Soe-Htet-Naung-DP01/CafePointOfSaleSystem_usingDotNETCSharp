USE [master]
GO
/****** Object:  Database [Cafe]    Script Date: 7/15/2018 7:39:06 PM ******/
CREATE DATABASE [Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cafe_dat', FILENAME = N'D:\Cafe\SQL DATABASE\Cafe.mdf' , SIZE = 12288KB , MAXSIZE = 102400KB , FILEGROWTH = 2048KB )
 LOG ON 
( NAME = N'Cafe_log', FILENAME = N'D:\Cafe\SQL DATABASE\Cafe.ldf' , SIZE = 4096KB , MAXSIZE = 51200KB , FILEGROWTH = 2048KB )
GO
ALTER DATABASE [Cafe] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Cafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cafe] SET RECOVERY FULL 
GO
ALTER DATABASE [Cafe] SET  MULTI_USER 
GO
ALTER DATABASE [Cafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cafe] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Cafe', N'ON'
GO
USE [Cafe]
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Customer]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Insert_Customer]

@CustomerID			int					=0,
@CustomerName		nvarchar(50)		='',
@CustomerAddress	nvarchar(70)		='',
@CustomerPhone		nvarchar(50)		='',
@action				int					=0

as begin

if @action = 0
	Insert into Customer Values(@CustomerName, @CustomerAddress, @CustomerPhone)

if @action = 1
	Update Customer set CustomerName = @CustomerName, CustomerAddress = @CustomerAddress, CustomerPhone = @CustomerPhone Where CustomerID = @CustomerID

if @action = 2
	Delete from Customer where CustomerID = @CustomerID

end

GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_DeliveryMan]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Insert_DeliveryMan]

@DeliveryManID		int					=0,
@DeliveryManName	nvarchar(30)		='',
@DeliveryManPhone	nvarchar(30)		='',
@DeliveryManNRC		nvarchar(30)		='',
@DeliveryManAddress	nvarchar(60)		='',
@action				int					=0

as begin

if @action = 0
	Insert into DeliveryMan Values(@DeliveryManName, @DeliveryManPhone, @DeliveryManNRC, @DeliveryManAddress)

if @action = 1
	Update DeliveryMan set DeliveryManName = @DeliveryManName, DeliveryManPhone = @DeliveryManPhone, DeliveryManAddress = @DeliveryManAddress where DeliveryManID = @DeliveryManID

if @action = 2
	Delete from DeliveryMan where DeliveryManID = @DeliveryManID

end

GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Menu]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Insert_Menu]
@MenuID int = 0,
@MenuName nvarchar(150) = '',
@Qty int = 0,
@Price int = 0,
@UpdateDate nvarchar(10) = '',
@action int = 0
as
begin
if @action = 0
	insert into Menu Values(@MenuName, @Qty, @Price, @UpdateDate)

if @action = 1
	Update Menu set MenuName = @MenuName, Qty = @Qty, Price =@Price, UpdateDate = @UpdateDate where MenuID = @MenuID

if @action = 2
	delete from Menu where MenuID = @MenuID

if @action = 3
	Update Menu set Qty = Qty+ @Qty, Price = (@Price *0.05) + @Price where MenuID = @MenuID

if @action = 4
	Update Menu Set Qty = Qty-@Qty Where MenuID = @MenuID  
end


GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_OrderVoucher]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Insert_OrderVoucher]

@OrderVoucherID		int					=0,
@OrderDate			nvarchar(10)		='',
@OrderTotalAmount	int					=0,
@OrderTax			int					=0,
@OrderGrandTotal	int					=0,
@UserID				int					=0,
@DeliveryFees		int					=0,
@action				int					=0

as begin

if @action = 0
	Insert into OrderVoucher Values(@OrderDate, @OrderTotalAmount, @OrderTax, @OrderGrandTotal, @UserID, @DeliveryFees)

end

GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Purchase]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Insert_Purchase]
@PurchaseID			int				=0,
@PurchaseDate		nvarchar(10)	='',
@SupplierID			int				=0,
@TotalAmount		int				=0,
@UserID				int				=0,
@action				int				=0

as begin

If @action = 0
		Insert Into Purchase Values(@PurchaseDate,@SupplierID,@TotalAmount,@UserID)


end



GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_PurchaseDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Insert_PurchaseDetail]
@PurchaseID			int				=0,
@MenuID				int				=0,
@PurchaseQty		int				=0,
@PurchasePrice		int				=0,
@action				int				=0

as begin

If @action = 0
		Insert Into PurchaseDetail Values(@PurchaseID,@MenuID,@PurchaseQty,@PurchasePrice)


end




GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Sale]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Insert_Sale]
@SaleID				int				=0,
@Voucher			varchar(16)		='',
@SaleDate			nvarchar(10)	='',
@TotalAmount		int				=0,
@Tax				int				=0,
@GrandTotal			int				=0,
@UserID				int				=0,
@action				int				=0

as begin

If @action = 0
		Insert Into Sale Values(@Voucher,@SaleDate,@TotalAmount,@Tax,@GrandTotal,@UserID)



end


GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_SaleDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Insert_SaleDetail]
@SaleID				nvarchar(16)	='',
@MenuID				int				=0,
@SaleQty			int				=0,
@SalePrice			int				=0,
@action				int				=0

as begin

If @action = 0
		Insert Into SaleDetail Values(@SaleID,@MenuID,@SaleQty,@SalePrice)

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_Supplier]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Insert_Supplier]
@SupplierID			int				=0,
@SupplierName		nvarchar(30)	='',
@Address			nvarchar(100)	='',
@Phone				nvarchar(20)	='',
@UpdateDate			nvarchar(10)	='',
@action				int				=0

as begin

If @action = 0
		Insert Into Supplier Values(@SupplierName,@Address,@Phone,@UpdateDate)
If @action = 1
		Update Supplier set SupplierName = @SupplierName, Address=@Address, Phone = @Phone, UpdateDate = @UpdateDate Where SupplierID = @SupplierID
If @action = 2
		Delete From Supplier Where SupplierID = @SupplierID

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_UserSetting]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Insert_UserSetting]
@UserID				int				=0,
@UserName			nvarchar(30)	='',
@Password			nvarchar(15)	='',
@UserLevel			nvarchar(Max)	='',
@UpdateDate			nvarchar(10)	='',
@action				int				=0

as begin

If @action = 0
		Insert Into UserSetting(UserName,Password,UserLevel,UpdateDate) Values(@UserName,@Password,@UserLevel,@UpdateDate)
If @action = 1
		Update UserSetting set UserName = @UserName, Password=@Password, UserLevel = @UserLevel, UpdateDate = @UpdateDate Where UserID = @UserID
If @action = 2
		Delete From UserSetting Where UserID = @UserID

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Customer]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Select_Customer]

@para1				nvarchar(max)		='',
@para2				nvarchar(max)		='',
@action				int					=0

as begin

if @action = 0
	select row_number() Over(Order by CustomerID) as No, * from Customer order by CustomerName

If @action = 1
	select ROW_NUMBER() Over(Order by CustomerID) AS NO, * From Customer

end

GO
/****** Object:  StoredProcedure [dbo].[SP_Select_DeliveryMan]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Select_DeliveryMan]

@para1				nvarchar(max)		='',
@para2				nvarchar(max)		='',
@action				int					=0

as begin

if @action = 0
	select row_number() Over(Order by DeliveryManID) as No, * from DeliveryMan Order by DeliveryManName

end

GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Menu]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Select_Menu]
@para1			nvarchar(150)		='',
@para2			nvarchar(150)		='',
@action			int					=0

as begin
If @action = 0 
	Select ROW_NUMBER() Over(Order by MenuName)	As No, * from Menu Order By MenuName
If @action = 1
	Select * from Menu Where MenuName = @para1
If @action = 2 
	Select ROW_NUMBER() Over(Order by MenuName)	As No, * from Menu Where MenuName Like @para1 + '%' Order By MenuName
If @action = 3
	Select ROW_NUMBER() Over(Order by MenuName)	As No, * from Menu Where Qty Like @para1 + '%' Order By MenuName
If @action = 4
	Select ROW_NUMBER() Over(Order by MenuName)	As No, * from Menu Where Price Like @para1 + '%' Order By MenuName
If @action = 5
	Select ROW_NUMBER() Over(Order by MenuName)	As No, * from Menu Where Qty>0 Order By MenuName
If @action = 6
	Select ROW_NUMBER() Over(Order by MenuName)	As No, * from Menu Where Qty>0 and MenuName=@para1 Order By MenuName
If @action = 7
	select ROW_NUMBER() Over(Order by MenuID DESC) AS NO, * From Menu

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_OrderVoucher]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[SP_Select_OrderVoucher]

@para1				nvarchar(max)		='',
@para2				nvarchar(max)		='',
@action				int					=0

as begin

if @action = 0
	select row_number() Over(Order by OrderDate DESC) as No, * from vi_OrderVoucher Order by OrderDate Desc

if @action = 1
	select OrderVoucherID AS OrderVoucher from OrderVoucher where OrderDate = @para1

if @action = 2
	select DATEDIFF(D,GetDate(), @para1) as No

if @action = 3
	select Max(OrderVoucherID) as OrderVoucherID from OrderVoucher

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_ProfitLoss]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_ProfitLoss]
@para1			nvarchar(150)		='',
@para2			nvarchar(150)		='',
@para3			nvarchar(150)		='',
@action			int					=0

as begin
If @action = 0
	select MenuName, Sum(PurchaseQty*PurchasePrice) as PurchaseTotal from vi_Purchase_PL where MenuName like @para1 + '%' and PurchaseDate between @para2 and @para3 group by MenuName order by MenuName
if @action = 1
	select  MenuName, Sum(SaleQty*SalePrice) as SaleTotal from vi_Sale_PL where MenuName like @para1 + '%' and SaleDate between @para2 and @para3 group by MenuName order by MenuName
if @action =2
	select DATEDIFF(d,@para1,@para2) as no
end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Purchase]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_Purchase]
@para1			nvarchar(16)		='',
@para2			nvarchar(16)		='',
@action			int					=0

as begin
If @action = 0
	Select ROW_NUMBER() Over(Order by PurchaseDate DESC) As No, * from vi_Purchase Order By PurchaseDate DESC
If @action = 1
	Select Max(PurchaseID) as PurchaseID from Purchase
If @action = 2 
	Select DateDiff(D, GetDate(), @para1) as No
If @action = 3
	select ROW_NUMBER() Over(Order by PurchaseDate DESC) AS NO, * From vi_Purchase Where PurchaseDate like @para1 + '%' Order by PurchaseDate DESC
If @action = 4
	select ROW_NUMBER() Over(Order by PurchaseDate DESC) AS NO, * From vi_Purchase Where SupplierName like @para1 + '%' Order by PurchaseDate DESC
If @action = 5
	select ROW_NUMBER() Over(Order by PurchaseDate DESC) AS NO, * From vi_Purchase Where UserName like @para1 + '%' Order by PurchaseDate DESC

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_PurchaseDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_PurchaseDetail]
@para1			nvarchar(16)		='',
@para2			nvarchar(16)		='',
@action			int					=0

as begin
If @action = 0
	Select * from vi_PurchaseDetail where PurchaseID = @para1 order by MenuName
end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_PurchaseReport]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_PurchaseReport]
@para1			nvarchar(16)		='',
@para2			nvarchar(16)		='',
@action			int					=0

as begin
If @action = 0
	select ROW_NUMBER() Over(Order by PurchaseDate DESC) AS NO, * From vi_PurchaseReport Where PurchaseDate like @para1 + '%' Order by PurchaseDate DESC
If @action = 1
	select ROW_NUMBER() Over(Order by PurchaseDate DESC) AS NO, * From vi_PurchaseReport Where SupplierName like @para1 + '%' Order by PurchaseDate DESC
If @action = 2
	select ROW_NUMBER() Over(Order by PurchaseDate DESC) AS NO, * From vi_PurchaseReport Where UserName like @para1 + '%' Order by PurchaseDate DESC

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Sale]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_Sale]
@para1			nvarchar(16)		='',
@para2			nvarchar(16)		='',
@action			int					=0

as begin
If @action = 0
	select ROW_NUMBER() Over(Order by SaleDate DESC) AS NO, * From vi_Sale Order by SaleDate DESC
If @action = 1
	select Max (SUBSTRING(Voucher,2,3)) as voucher from sale where SaleDate = @para1
If @action = 2
	select DATEDIFF(D,GETDATE(),@para1) as no 
If @action = 3
	select Max (SaleID) as SaleID from Sale
If @action = 4
	select ROW_NUMBER() Over(Order by SaleDate DESC) AS NO, * From vi_Sale where SaleDate like @para1 + '%' Order by SaleDate DESC
If @action = 5
	select ROW_NUMBER() Over(Order by SaleDate DESC) AS NO, * From vi_Sale where UserName like @para1 + '%' Order by SaleDate DESC
end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_SaleDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_SaleDetail]
@para1			nvarchar(16)		='',
@para2			nvarchar(16)		='',
@action			int					=0

as begin
If @action = 0
	select * from vi_SaleDetail where SaleID = @para1
end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_SaleReport]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_SaleReport]
@para1			nvarchar(16)		='',
@para2			nvarchar(16)		='',
@action			int					=0

as begin
If @action = 0
	select top 1 with ties * From vi_SaleReport order by SaleID DESC
If @action = 1
	select ROW_NUMBER() Over(Order by SaleDate DESC) AS NO, * From vi_SaleReport where SaleDate like @para1 + '%' Order by SaleDate DESC
If @action = 2
	select ROW_NUMBER() Over(Order by SaleDate DESC) AS NO, * From vi_SaleReport where UserName like @para1 + '%' Order by SaleDate DESC

end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_Supplier]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_Supplier]
@para1			nvarchar(100)		='',
@para2			nvarchar(100)		='',
@action			int					=0

as begin
If @action = 0 
	Select ROW_NUMBER() Over(Order by SupplierName)	As No, * from Supplier Order By SupplierName
If @action = 1
	Select * from Supplier Where SupplierName = @para1 and Address = @para2
If @action = 2 
	Select ROW_NUMBER() Over(Order by SupplierName)	As No, * from Supplier Where SupplierName Like @para1 + '%' Order By SupplierName
If @action = 3
	Select ROW_NUMBER() Over(Order by SupplierName)	As No, * from Supplier Where Phone Like @para1 + '%' Order By SupplierName
If @action = 4
	Select ROW_NUMBER() Over(Order by SupplierName)	As No, * from Supplier Where Address Like @para1 + '%' Order By SupplierName
end


GO
/****** Object:  StoredProcedure [dbo].[SP_Select_UserSetting]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_Select_UserSetting]
@para1			nvarchar(max)		='',
@para2			nvarchar(max)		='',
@action			int					=0

as begin
If @action = 0
	Select ROW_NUMBER() Over(Order by UserName)	As No, * from UserSetting Order By UserName
If @action = 1
	Select * from UserSetting Where UserName = @para1 and Password = @para2
If @action = 2 
	Select ROW_NUMBER() Over(Order by UserName)	As No, * from UserSetting Where UserName Like @para1 + '%' Order By UserName
end


GO
/****** Object:  Table [dbo].[Customer]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[CustomerAddress] [nvarchar](70) NULL,
	[CustomerPhone] [nvarchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DeliveryMan]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeliveryMan](
	[DeliveryManID] [int] IDENTITY(1,1) NOT NULL,
	[DeliveryManName] [nvarchar](30) NULL,
	[DeliveryManPhone] [nvarchar](30) NULL,
	[DeliveryManNRC] [nvarchar](30) NULL,
	[DeliveryManAddress] [nvarchar](60) NULL,
 CONSTRAINT [PK_DeliveryMan] PRIMARY KEY CLUSTERED 
(
	[DeliveryManID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Menu]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[MenuName] [nvarchar](150) NULL,
	[Qty] [int] NULL,
	[Price] [int] NULL,
	[UpdateDate] [nvarchar](10) NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderVoucher]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderVoucher](
	[OrderVoucherID] [int] IDENTITY(1,1) NOT NULL,
	[OrderDate] [nvarchar](10) NULL,
	[OrderTotalAmount] [int] NULL,
	[OrderTax] [int] NULL,
	[OrderGrandTotal] [int] NULL,
	[UserID] [int] NULL,
	[DeliveryFees] [int] NULL,
 CONSTRAINT [PK_OrderVoucher] PRIMARY KEY CLUSTERED 
(
	[OrderVoucherID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderVoucherDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderVoucherDetail](
	[OrderVoucherID] [int] IDENTITY(1,1) NOT NULL,
	[MenuID] [int] NOT NULL,
	[OrderQty] [int] NULL,
	[OrderPrice] [int] NULL,
 CONSTRAINT [PK_OrderVoucherDetail] PRIMARY KEY CLUSTERED 
(
	[OrderVoucherID] ASC,
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProfitLoss]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProfitLoss](
	[ItemName] [nvarchar](150) NULL,
	[OnHandQty] [int] NULL,
	[PurchaseTotal] [int] NULL,
	[SaleTotal] [int] NULL,
	[Profit/Loss] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[PurchaseID] [int] IDENTITY(1,1) NOT NULL,
	[PurchaseDate] [nvarchar](10) NULL,
	[SupplierID] [int] NULL,
	[TotalAmount] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[PurchaseID] [int] NOT NULL,
	[MenuID] [int] NOT NULL,
	[PurchaseQty] [int] NULL,
	[PurchasePrice] [int] NULL,
 CONSTRAINT [pkpid] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC,
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sale]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sale](
	[SaleID] [int] IDENTITY(1,1) NOT NULL,
	[Voucher] [nvarchar](16) NULL,
	[SaleDate] [nvarchar](10) NULL,
	[TotalAmount] [int] NULL,
	[Tax] [int] NULL,
	[GrandTotal] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_Sale] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleDetail](
	[SaleID] [int] NOT NULL,
	[MenuID] [int] NOT NULL,
	[SaleQty] [int] NULL,
	[SalePrice] [int] NULL,
 CONSTRAINT [PK_SaleDetail] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC,
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](30) NULL,
	[Address] [nvarchar](100) NULL,
	[Phone] [nvarchar](20) NULL,
	[UpdateDate] [nvarchar](10) NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSetting]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSetting](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](30) NULL,
	[Password] [nvarchar](15) NULL,
	[UserLevel] [nvarchar](max) NULL,
	[UpdateDate] [nvarchar](10) NULL,
 CONSTRAINT [PK_UserSetting] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  View [dbo].[vi_OrderVoucher]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_OrderVoucher]
AS
SELECT        dbo.Customer.CustomerID, dbo.Customer.CustomerName, dbo.Customer.CustomerAddress, dbo.Customer.CustomerPhone, dbo.DeliveryMan.DeliveryManName, dbo.OrderVoucherDetail.MenuID, dbo.Menu.MenuName, 
                         dbo.OrderVoucherDetail.OrderQty, dbo.OrderVoucherDetail.OrderPrice, dbo.OrderVoucher.OrderDate, dbo.OrderVoucher.OrderTotalAmount, dbo.OrderVoucher.OrderTax, dbo.OrderVoucher.OrderGrandTotal, 
                         dbo.OrderVoucher.UserID, dbo.OrderVoucher.DeliveryFees
FROM            dbo.OrderVoucherDetail INNER JOIN
                         dbo.Menu ON dbo.OrderVoucherDetail.MenuID = dbo.Menu.MenuID CROSS JOIN
                         dbo.OrderVoucher CROSS JOIN
                         dbo.Customer CROSS JOIN
                         dbo.DeliveryMan

GO
/****** Object:  View [dbo].[vi_Purchase]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Purchase]
AS
SELECT        dbo.Purchase.PurchaseID, dbo.Purchase.PurchaseDate, dbo.Purchase.SupplierID, dbo.Supplier.SupplierName, dbo.Purchase.UserID, dbo.UserSetting.UserName, 
                         dbo.Purchase.TotalAmount
FROM            dbo.Purchase INNER JOIN
                         dbo.Supplier ON dbo.Purchase.SupplierID = dbo.Supplier.SupplierID INNER JOIN
                         dbo.UserSetting ON dbo.Purchase.UserID = dbo.UserSetting.UserID



GO
/****** Object:  View [dbo].[vi_Purchase_PL]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Purchase_PL]
AS
SELECT        dbo.Purchase.PurchaseDate, dbo.PurchaseDetail.MenuID, dbo.Menu.MenuName, dbo.PurchaseDetail.PurchaseQty, dbo.PurchaseDetail.PurchasePrice
FROM            dbo.Purchase INNER JOIN
                         dbo.PurchaseDetail ON dbo.Purchase.PurchaseID = dbo.PurchaseDetail.PurchaseID INNER JOIN
                         dbo.Menu ON dbo.PurchaseDetail.MenuID = dbo.Menu.MenuID



GO
/****** Object:  View [dbo].[vi_PurchaseDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_PurchaseDetail]
AS
SELECT        dbo.PurchaseDetail.PurchaseID, dbo.PurchaseDetail.MenuID, dbo.Menu.MenuName, dbo.PurchaseDetail.PurchaseQty, dbo.PurchaseDetail.PurchasePrice
FROM            dbo.PurchaseDetail INNER JOIN
                         dbo.Menu ON dbo.PurchaseDetail.MenuID = dbo.Menu.MenuID



GO
/****** Object:  View [dbo].[vi_PurchaseReport]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_PurchaseReport]
AS
SELECT        dbo.Purchase.PurchaseDate, dbo.Supplier.SupplierName, dbo.UserSetting.UserName, dbo.Purchase.TotalAmount, dbo.Menu.MenuName, 
                         dbo.PurchaseDetail.PurchaseQty, dbo.PurchaseDetail.PurchasePrice
FROM            dbo.PurchaseDetail INNER JOIN
                         dbo.Menu ON dbo.PurchaseDetail.MenuID = dbo.Menu.MenuID CROSS JOIN
                         dbo.Purchase INNER JOIN
                         dbo.Supplier ON dbo.Purchase.SupplierID = dbo.Supplier.SupplierID INNER JOIN
                         dbo.UserSetting ON dbo.Purchase.UserID = dbo.UserSetting.UserID



GO
/****** Object:  View [dbo].[vi_Sale]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Sale]
AS
SELECT        dbo.Sale.SaleID, dbo.Sale.Voucher, dbo.Sale.SaleDate, dbo.Sale.UserID, dbo.UserSetting.UserName, dbo.Sale.TotalAmount, dbo.Sale.GrandTotal
FROM            dbo.Sale INNER JOIN
                         dbo.UserSetting ON dbo.Sale.UserID = dbo.UserSetting.UserID



GO
/****** Object:  View [dbo].[vi_Sale_PL]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_Sale_PL]
AS
SELECT        dbo.Sale.SaleDate, dbo.SaleDetail.MenuID, dbo.Menu.MenuName, dbo.SaleDetail.SaleQty, dbo.SaleDetail.SalePrice
FROM            dbo.Sale INNER JOIN
                         dbo.SaleDetail ON dbo.Sale.SaleID = dbo.SaleDetail.SaleID INNER JOIN
                         dbo.Menu ON dbo.SaleDetail.MenuID = dbo.Menu.MenuID



GO
/****** Object:  View [dbo].[vi_SaleDetail]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_SaleDetail]
AS
SELECT        dbo.SaleDetail.SaleID, dbo.SaleDetail.MenuID, dbo.Menu.MenuName, dbo.SaleDetail.SaleQty, dbo.SaleDetail.SalePrice
FROM            dbo.SaleDetail INNER JOIN
                         dbo.Menu ON dbo.SaleDetail.MenuID = dbo.Menu.MenuID



GO
/****** Object:  View [dbo].[vi_SaleReport]    Script Date: 7/15/2018 7:39:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vi_SaleReport]
AS
SELECT        dbo.Sale.SaleID, dbo.Sale.Voucher, dbo.Sale.SaleDate, dbo.UserSetting.UserName, dbo.Sale.TotalAmount, dbo.Sale.Tax, dbo.Sale.GrandTotal, 
                         dbo.Menu.MenuName, dbo.SaleDetail.SaleQty, dbo.SaleDetail.SalePrice
FROM            dbo.Sale INNER JOIN
                         dbo.UserSetting ON dbo.Sale.UserID = dbo.UserSetting.UserID INNER JOIN
                         dbo.SaleDetail ON dbo.Sale.SaleID = dbo.SaleDetail.SaleID CROSS JOIN
                         dbo.Menu



GO
SET IDENTITY_INSERT [dbo].[Customer] ON 

INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [CustomerAddress], [CustomerPhone]) VALUES (12, N'dd', N'dd', N'dd')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [CustomerAddress], [CustomerPhone]) VALUES (13, N'fgj', N'kh', N'thd')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [CustomerAddress], [CustomerPhone]) VALUES (14, N'SFduj', N'653', N'mgkhhjd')
INSERT [dbo].[Customer] ([CustomerID], [CustomerName], [CustomerAddress], [CustomerPhone]) VALUES (15, N'fgfg', N'ggggf', N'ffff')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([MenuID], [MenuName], [Qty], [Price], [UpdateDate]) VALUES (2, N'Espresso', 7, 2000, N'06/24/2018')
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Qty], [Price], [UpdateDate]) VALUES (3, N'Coffee', 0, 1050, N'06/24/2018')
INSERT [dbo].[Menu] ([MenuID], [MenuName], [Qty], [Price], [UpdateDate]) VALUES (7, N'Capuccino', 200, 1575, N'07/01/2018')
SET IDENTITY_INSERT [dbo].[Menu] OFF
SET IDENTITY_INSERT [dbo].[Purchase] ON 

INSERT [dbo].[Purchase] ([PurchaseID], [PurchaseDate], [SupplierID], [TotalAmount], [UserID]) VALUES (1, N'6/30/2018', 2, 1000, 1)
INSERT [dbo].[Purchase] ([PurchaseID], [PurchaseDate], [SupplierID], [TotalAmount], [UserID]) VALUES (2, N'7/1/2018', 2, 150000, 5)
INSERT [dbo].[Purchase] ([PurchaseID], [PurchaseDate], [SupplierID], [TotalAmount], [UserID]) VALUES (3, N'7/1/2018', 1, 150000, 5)
SET IDENTITY_INSERT [dbo].[Purchase] OFF
INSERT [dbo].[PurchaseDetail] ([PurchaseID], [MenuID], [PurchaseQty], [PurchasePrice]) VALUES (1, 3, 1, 1000)
INSERT [dbo].[PurchaseDetail] ([PurchaseID], [MenuID], [PurchaseQty], [PurchasePrice]) VALUES (2, 7, 100, 1500)
INSERT [dbo].[PurchaseDetail] ([PurchaseID], [MenuID], [PurchaseQty], [PurchasePrice]) VALUES (3, 7, 100, 1500)
SET IDENTITY_INSERT [dbo].[Sale] ON 

INSERT [dbo].[Sale] ([SaleID], [Voucher], [SaleDate], [TotalAmount], [Tax], [GrandTotal], [UserID]) VALUES (1, N'S001-6/30/2018', N'6/30/2018', 3050, 100, 3150, 4)
INSERT [dbo].[Sale] ([SaleID], [Voucher], [SaleDate], [TotalAmount], [Tax], [GrandTotal], [UserID]) VALUES (2, N'S002-6/30/2018', N'6/30/2018', 3050, 100, 3150, 4)
INSERT [dbo].[Sale] ([SaleID], [Voucher], [SaleDate], [TotalAmount], [Tax], [GrandTotal], [UserID]) VALUES (3, N'S001-7/1/2018', N'7/1/2018', 15750, 500, 16250, 5)
INSERT [dbo].[Sale] ([SaleID], [Voucher], [SaleDate], [TotalAmount], [Tax], [GrandTotal], [UserID]) VALUES (4, N'S002-7/1/2018', N'7/1/2018', 2000, 50, 2050, 5)
SET IDENTITY_INSERT [dbo].[Sale] OFF
INSERT [dbo].[SaleDetail] ([SaleID], [MenuID], [SaleQty], [SalePrice]) VALUES (1, 2, 1, 2000)
INSERT [dbo].[SaleDetail] ([SaleID], [MenuID], [SaleQty], [SalePrice]) VALUES (1, 3, 1, 1050)
INSERT [dbo].[SaleDetail] ([SaleID], [MenuID], [SaleQty], [SalePrice]) VALUES (2, 2, 1, 2000)
INSERT [dbo].[SaleDetail] ([SaleID], [MenuID], [SaleQty], [SalePrice]) VALUES (2, 3, 1, 1050)
INSERT [dbo].[SaleDetail] ([SaleID], [MenuID], [SaleQty], [SalePrice]) VALUES (3, 7, 10, 1575)
INSERT [dbo].[SaleDetail] ([SaleID], [MenuID], [SaleQty], [SalePrice]) VALUES (4, 2, 1, 2000)
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [UpdateDate]) VALUES (1, N'gg', N'somewhere', N'39489384', N'06/24/2018')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [UpdateDate]) VALUES (2, N'dd', N'lol', N'4635324546', N'06/24/2018')
INSERT [dbo].[Supplier] ([SupplierID], [SupplierName], [Address], [Phone], [UpdateDate]) VALUES (3, N'a', N'a', N'a', N'07/01/2018')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
SET IDENTITY_INSERT [dbo].[UserSetting] ON 

INSERT [dbo].[UserSetting] ([UserID], [UserName], [Password], [UserLevel], [UpdateDate]) VALUES (5, N'bffgf', N'b', N'Menu,Supplier,User,Purchase,Sale,ProfitLoss,', N'07/15/2018')
INSERT [dbo].[UserSetting] ([UserID], [UserName], [Password], [UserLevel], [UpdateDate]) VALUES (6, N'Ryuu', N'risa', N'Menu,Supplier,User,Purchase,Sale,ProfitLoss,', N'07/14/2018')
SET IDENTITY_INSERT [dbo].[UserSetting] OFF
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Qty]  DEFAULT ((0)) FOR [Qty]
GO
ALTER TABLE [dbo].[Menu] ADD  CONSTRAINT [DF_Menu_Price]  DEFAULT ((0)) FOR [Price]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [fkmid] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [fkmid]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[7] 4[81] 2[5] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Customer"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 221
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "DeliveryMan"
            Begin Extent = 
               Top = 6
               Left = 259
               Bottom = 136
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 494
               Bottom = 136
               Right = 664
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "OrderVoucher"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "OrderVoucherDetail"
            Begin Extent = 
               Top = 138
               Left = 266
               Bottom = 268
               Right = 440
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1890
         Alias = 900
         Table = 2010
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_OrderVoucher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_OrderVoucher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_OrderVoucher'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Purchase"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserSetting"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Purchase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Purchase'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Purchase"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PurchaseDetail"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Purchase_PL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Purchase_PL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PurchaseDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_PurchaseDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_PurchaseDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Purchase"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Supplier"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserSetting"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 135
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PurchaseDetail"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 267
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_PurchaseReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_PurchaseReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_PurchaseReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Sale"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserSetting"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Sale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Sale'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Sale"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SaleDetail"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Sale_PL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_Sale_PL'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "SaleDetail"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_SaleDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_SaleDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Sale"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "UserSetting"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 135
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Menu"
            Begin Extent = 
               Top = 6
               Left = 454
               Bottom = 135
               Right = 624
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SaleDetail"
            Begin Extent = 
               Top = 6
               Left = 662
               Bottom = 135
               Right = 832
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_SaleReport'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vi_SaleReport'
GO
USE [master]
GO
ALTER DATABASE [Cafe] SET  READ_WRITE 
GO
