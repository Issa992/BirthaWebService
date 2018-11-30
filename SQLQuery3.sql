SELECT * FROM dbo.Environment
INSERT dbo.Environment
(
    Oxygen,
    Nitrogen,
    CarbonDioxide,
    Methane,
    UserId,
    Humidity,
    Temperatur
)
VALUES
(   0,    -- Oxygen - int
    0,    -- Nitrogen - int
    0,    -- CarbonDioxide - int
    0,    -- Methane - int
    0,    -- UserId - int
    NULL, -- Humidity - decimal(5, 2)
    NULL  -- Temperatur - decimal(5, 2)
    )