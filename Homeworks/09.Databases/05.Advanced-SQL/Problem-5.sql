SELECT AVG(e.Salary) AS [Average Salary in Sales Department] FROM Employees e
INNER JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE d.Name = 'Sales'