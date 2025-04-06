SELECT f.FranchiseName, s.AvailableBeds
FROM Franchise f
JOIN Shelter s ON f.FranchiseID = s.FranchiseID
WHERE s.AvailableBeds > 10;