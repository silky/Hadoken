CREATE PROC dbo.spGetElement

AS

SELECT
	[ID],
	[GroupID],
	[AtomicNumber],
	[Symbol],
	[Name],
	[Period],
	[AtomicWeight],
	[Density],
	[DateCreatedUtc],
	[DateUpdatedUtc]
FROM 
	[dbo].[Element]
