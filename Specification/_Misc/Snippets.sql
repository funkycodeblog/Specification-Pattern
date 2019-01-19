  select C.Name, Count(A.Balance), Sum(A.Balance) from Customers C 
  join Accounts A on C.Id = A.CustomerId
  group by C.Name
  having Count(A.Balance) > 10 and Sum(A.Balance) > 30000