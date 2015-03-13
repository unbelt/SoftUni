SELECT d.Name AS [Department Name], e.JobTitle, MIN(e.Salary) AS [Minmum Salary], e.FirstName + ' ' + e.LastName AS [Employee Name]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
GROUP BY d.Name, e.JobTitle, e.FirstName, e.LastName
ORDER BY d.Name