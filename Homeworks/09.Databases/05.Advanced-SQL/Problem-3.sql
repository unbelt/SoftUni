SELECT FirstName, LastName, Salary,
(SELECT Name FROM Departments WHERE DepartmentID = e.DepartmentID) AS [Department Name]
FROM Employees e
WHERE Salary = (SELECT MIN(Salary) FROM Employees WHERE DepartmentID = e.DepartmentID)