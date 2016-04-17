
--
-- 資料庫: `MessageBoard`
--

-- --------------------------------------------------------

--
-- 資料表結構 `login`
-- 欄位說明: id 識別唯一值
-- 欄位說明: Account 帳號
-- 欄位說明: Passwd 密碼(MD5格式)
-- 欄位說明: CreateTime 建立時間
--


CREATE TABLE  login (
  [ID][int]IDENTITY(1,1) NOT  NULL  PRIMARY KEY,
  [Account] varchar(255) DEFAULT NULL,
  [Passwd] varchar(600) DEFAULT NULL,
  [UserName] varchar(255) DEFAULT NULL,
  [CreateTime] [datetime] NOT NULL DEFAULT  GETDATE()
) 


-- --------------------------------------------------------

--
-- 資料表結構 `message`
-- 欄位說明: id 識別唯一值
-- 欄位說明: Account 帳號
-- 欄位說明: CreateTime 建立時間
--

CREATE TABLE  message (
  [ID][int]IDENTITY(1,1) NOT  NULL  PRIMARY KEY,
  [Message] text,
  [Account] varchar(255) DEFAULT NULL,
  [UpdateTime] [datetime] NULL  DEFAULT GETDATE()
) 

--
-- 資料表結構 `ReMessage`
-- 欄位說明: id 識別唯一值
-- 欄位說明: Re_Id 回覆的ID
-- 欄位說明: Message 回覆的留言
-- 欄位說明: Account 帳號
-- 欄位說明: CreateTime 建立時間
--

CREATE TABLE  ReMessage (
  [ID][int]IDENTITY(1,1) NOT  NULL  PRIMARY KEY,
  [Re_Id] int  NOT NULL,
  [Account] varchar(255) NOT NULL,
  [Message] varchar(255) NOT NULL,
  [UpdateTime] [datetime] NULL  DEFAULT GETDATE()
) 
