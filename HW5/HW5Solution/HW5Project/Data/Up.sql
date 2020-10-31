Create Table Assignments
(
	ID	Integer Not Null Primary Key IDENTITY(1,1),
	IMPORTANCE Integer Not Null,
	DUE DATETIME Not Null,
	COURSE NVARCHAR(10) Not Null,
	TITLE NVARCHAR(50) Not Null,
	NOTES NVARCHAR(250) Not Null
);