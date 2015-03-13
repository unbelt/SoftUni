SELECT e.FirstName + ' ' + e.LastName AS [Full Name]
FROM Employees e
WHERE (SELECT COUNT(EmployeeID)
FROM Employees emp WHERE emp.ManagerID = e.EmployeeID) = 5