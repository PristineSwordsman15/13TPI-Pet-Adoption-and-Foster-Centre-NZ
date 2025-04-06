SELECT p.PaymentID, p.Amount, p.PaymentDate, p.PaymentMethod, u.Email
FROM Payment p
JOIN [User] u ON p.UserID = u.UserID;