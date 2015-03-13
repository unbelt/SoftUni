SELECT t.Name, COUNT(*) FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID
JOIN Towns t ON t.TownID = a.TownID
WHERE e.ManagerID IS NULL
GROUP BY t.Name