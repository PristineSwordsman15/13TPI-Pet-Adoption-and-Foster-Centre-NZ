SELECT f.FranchiseName, l.City
FROM Franchise f
JOIN Location l ON f.LocationID = l.LocationID;