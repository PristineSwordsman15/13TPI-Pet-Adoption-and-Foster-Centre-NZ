SELECT p.PetName, m.VaccinationStatus, l.City, l.Region
FROM Pet p
JOIN MedicalRecord m ON p.PetID = m.PetID
JOIN PetGroup pg ON p.PetGroupID = pg.PetGroupID
JOIN Coordinator c ON c.PetGroupID = pg.PetGroupID
JOIN Franchise f ON c.FranchiseID = f.FranchiseID
JOIN Location l ON f.LocationID = l.LocationID
WHERE m.VaccinationStatus = 'Fully Vaccinated';