SELECT d.Name AS [Department Name], AVG(e.Salary) AS [Average Salary] FROM Departments d
JOIN Employees e ON d.DepartmentID = e.DepartmentID
GROUP BY d.Name