SELECT TOP 1 * FROM (SELECT t.Name, COUNT(*) AS [EmployeeCount] FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY t.Name) ec
ORDER BY ec.EmployeeCount DESC