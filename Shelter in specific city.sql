SELECT ShelterName, OperatingHours
FROM Shelter
JOIN Location ON Shelter.LocationID = Location.LocationID
WHERE City = 'Auckland';