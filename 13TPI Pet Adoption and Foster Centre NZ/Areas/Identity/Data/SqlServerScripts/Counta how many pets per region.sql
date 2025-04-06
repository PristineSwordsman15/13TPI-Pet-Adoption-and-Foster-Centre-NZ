SELECT l.Region, COUNT(p.PetID) AS TotalPets
FROM Pet p
JOIN PetGroup pg ON p.PetGroupID = pg.PetGroupID
JOIN Coordinator c ON pg.PetGroupID = c.PetGroupID
JOIN Franchise f ON c.FranchiseID = f.FranchiseID
JOIN Location l ON f.LocationID = l.LocationID
GROUP BY l.Region;