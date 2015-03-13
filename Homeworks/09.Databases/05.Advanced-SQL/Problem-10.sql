SELECT d.Name AS [Department], t.Name AS [Town], COUNT(e.EmployeeID) AS [Employees Count] FROM Departments d
JOIN Employees e ON d.DepartmentID = e.DepartmentID
JOIN Addresses a ON a.AddressID = e.AddressID
JOIN Towns t ON t.TownID = a.TownID
GROUP BY d.Name, t.Name
ORDER BY d.Name