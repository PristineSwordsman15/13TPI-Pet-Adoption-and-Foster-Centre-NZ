﻿SELECT PetGroupID, COUNT(*) AS PetCount
FROM Pet
GROUP BY PetGroupID;