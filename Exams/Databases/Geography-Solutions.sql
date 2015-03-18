USE Geography
GO

-- 1. All Mountain Peaks
SELECT p.PeakName FROM Peaks p
ORDER BY p.PeakName
GO


-- 2. Biggest Countries by Population
SELECT TOP(30) c.CountryName, c.Population FROM Countries c
WHERE c.ContinentCode = 'EU'
ORDER BY c.Population DESC
GO


-- 3. Countries and Currency
SELECT c.CountryName, c.CountryCode,
CASE WHEN c.CurrencyCode = 'EUR' THEN 'Euro' ELSE 'Not Euro' END AS [Currency]
FROM Countries c
ORDER BY c.CountryName
GO


-- 4. Countries Holding 'A' 3 or More Times
SELECT c.CountryName AS [Country Name], c.IsoCode AS [ISO Code] FROM Countries c
WHERE LEN(c.CountryName) - LEN(REPLACE(c.CountryName, 'a', '')) >= 3
ORDER BY c.IsoCode
GO


-- 5. Peaks and Mountains
SELECT p.PeakName, m.MountainRange AS [Mountain], p.Elevation FROM Mountains m
LEFT JOIN Peaks p
ON p.MountainId = m.Id
WHERE p.MountainId IS NOT NULL
ORDER BY p.Elevation DESC, p.PeakName
GO


-- 6. Peaks & Mountain, Country, Continent
SELECT p.PeakName, m.MountainRange AS [Mountain], c.CountryName, c1.ContinentName FROM Peaks p
JOIN Mountains m
ON m.Id = p.MountainId
JOIN MountainsCountries mc
ON mc.MountainId = p.MountainId
JOIN Countries c
ON c.CountryCode = mc.CountryCode
JOIN Continents c1
ON c1.ContinentCode = c.ContinentCode
ORDER BY p.PeakName



-- 7. Rivers in 3 or More Countries
SELECT r.RiverName AS [River], COUNT(cr.RiverId) AS [Countries Count] FROM Countries c
JOIN CountriesRivers cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
ON r.Id = cr.RiverId
GROUP BY r.RiverName
HAVING COUNT(cr.RiverId) >= 3
ORDER BY r.RiverName



-- 8. Highest, Lowest & Avg Peak
SELECT MAX(p.Elevation) AS [MaxElevation], MIN(p.Elevation) AS [MinElevation], AVG(p.Elevation) AS [AverageElevation] FROM Peaks p
GO


-- 9. Rivers by Country
SELECT c.CountryName, c1.ContinentName, COUNT(cr.RiverId) AS [RiversCount], ISNULL(SUM(r.Length), 0) AS [TotalLength] FROM Countries c
JOIN Continents c1
ON c1.ContinentCode = c.ContinentCode
LEFT JOIN CountriesRivers cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
ON r.Id = cr.RiverId
GROUP BY c.CountryName, c1.ContinentName
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName
GO


-- 10. Count of Countries by Currency - TODO
SELECT c.CurrencyCode, c1.Description AS [Currency], COUNT(c.CountryCode) AS [NumberOfCountries] FROM Countries c
JOIN Currencies c1
ON c1.CurrencyCode = c.CurrencyCode
GROUP BY c.CurrencyCode,  c1.Description
ORDER BY [NumberOfCountries] DESC, c1.Description
GO


-- 11. Population and Area by Continent - TODO
SELECT c.ContinentName, SUM(c1.AreaInSqKm) AS [CountriesArea], SUM(CAST(c1.Population AS BIGINT)) AS [CountriesPopulation] FROM Continents c
JOIN Countries c1
ON c1.ContinentCode = c.ContinentCode
GROUP BY c.ContinentName, c1.Population
ORDER BY c1.Population DESC



-- 12. Highest Peak & Longest River
SELECT c.CountryName, MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.Length) AS [LongestRiverLength] FROM Countries c
LEFT JOIN MountainsCountries mc
ON mc.CountryCode = c.CountryCode
LEFT JOIN Peaks p
ON mc.MountainId = p.MountainId
LEFT JOIN CountriesRivers cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName



-- 13. Mix of Peak and River Names
SELECT p.PeakName, r.RiverName, LOWER(p.PeakName + RIGHT(r.RiverName, LEN(r.RiverName) - 1)) AS [Mix] FROM Peaks p, Rivers r
WHERE LOWER(SUBSTRING(p.PeakName, LEN(p.PeakName), 1)) = LOWER(SUBSTRING(r.RiverName, 1, 1))
ORDER BY [Mix]



-- 14. Highest Peak & Elevation by Country - TODO
SELECT c.CountryName,
ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
ISNULL(m.MountainRange, '(no mountain)') AS [Mountain]
FROM Countries c
LEFT JOIN MountainsCountries mc
ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m
ON m.Id = mc.MountainId
LEFT JOIN Peaks p
ON p.MountainId = mc.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange
ORDER BY c.CountryName, p.PeakName



-- 15. Monasteries by Country
CREATE TABLE Monasteries(Id INT PRIMARY KEY IDENTITY, Name NVARCHAR(50), CountryCode CHAR(2))
GO

ALTER TABLE Monasteries ADD
 CONSTRAINT FK_Monasteries_Countries FOREIGN KEY (CountryCode) REFERENCES Countries (CountryCode)
GO

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')
GO

ALTER TABLE Countries
ADD IsDeleted BIT DEFAULT 0
GO


UPDATE Countries
SET IsDeleted = 1
WHERE CountryName IN (SELECT c.CountryName FROM Countries c
JOIN CountriesRivers cr
ON cr.CountryCode = c.CountryCode
LEFT JOIN Rivers r
ON r.Id = cr.RiverId
GROUP BY c.CountryName
HAVING COUNT(cr.RiverId) > 3)
GO


SELECT m.Name AS [Monastery], c.CountryName AS [Country] FROM Monasteries m
LEFT JOIN Countries c
ON c.CountryCode = m.CountryCode
WHERE c.IsDeleted IS NULL
ORDER BY m.Name


-- 16. Monasteries by Continents / Countries

UPDATE Countries
SET CountryName = 'Burma'
WHERE CountryName = (SELECT c.CountryName FROM Countries c
WHERE c.CountryName = 'Myanmar')
GO

INSERT INTO Monasteries(Name, CountryCode)
VALUES
('Hanga Abbey', (SELECT c.CountryCode FROM Countries c WHERE c.CountryName = 'Tanzania')),
('Myin-Tin-Daik', (SELECT c.CountryCode FROM Countries c WHERE c.CountryName = 'Myanmar'));
GO

SELECT c1.ContinentName, c.CountryName, COUNT(m.Id) AS [MonasteriesCount] FROM Countries c
LEFT JOIN Monasteries m
ON m.CountryCode = c.CountryCode
LEFT JOIN Continents c1
ON c1.ContinentCode = c.ContinentCode
WHERE c.IsDeleted IS FALSE
GROUP BY c1.ContinentName, c.CountryName
ORDER BY [MonasteriesCount] DESC, c.CountryName
GO