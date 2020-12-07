Select depN.Name as Department, emp.[Name] as Employee, emp.Salary as Salary from Employee as emp inner join
(select Department.Id, Max(Salary) as maxs from Employee 
inner join Department on Employee.DepartmentId = Department.Id
group by Department.Id) sals on emp.DepartmentId = sals.Id
inner join Department depN on depN.Id = emp.DepartmentId
where emp.Salary >= sals.maxs