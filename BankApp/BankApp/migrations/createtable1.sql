USE [bank_app]
GO

CREATE TABLE [dbo].[bank_account](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bank_name] [varchar](200) NOT NULL,
	[account_type] [varchar](50) NOT NULL,
	[user_id] [numeric](18, 0) NOT NULL,
	[balance] [numeric](18, 0) NOT NULL,
	[active] [varchar](1) NULL DEFAULT ('Y'),
	[created] [datetime] NULL DEFAULT (getdate())
) ON [PRIMARY]

CREATE TABLE [dbo].[bank_transaction](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[amount] [numeric](18, 0) NULL,
	[transaction_type] [varchar](100) NOT NULL,
	[description] [varchar](100) NULL,
	[transaction_date] [datetime] NOT NULL,
	[bank_account_id] [numeric](18, 0) NOT NULL,
	[ending_balance] [numeric](18, 0) NOT NULL,
	[active] [varchar](1) NULL DEFAULT ('Y'),
	[created] [datetime] NULL DEFAULT (getdate())
) ON [PRIMARY]