SELECT TOP 2 Breed, COUNT(*) AS CountPerBreed
FROM Pet
GROUP BY Breed
ORDER BY CountPerBreed DESC;