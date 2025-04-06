SELECT p.PetName, m.VisitDate, m.VetName
FROM Pet p
JOIN MedicalRecord m ON p.PetID = m.PetID;