SELECT ShelterName, AvailableBeds, OccupiedBeds,
       CAST(OccupiedBeds AS FLOAT) / (AvailableBeds + OccupiedBeds) * 100 AS OccupancyRate
FROM Shelter
WHERE (CAST(OccupiedBeds AS FLOAT) / (AvailableBeds + OccupiedBeds)) > 0.8;
