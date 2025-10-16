Select OrderID, P.ProductID, ProductName
From Products P
Inner Join [Order Details] OD
ON P.ProductID=OD.ProductID