INSERT dbo.Environment
(
    Oxygen,
    Nitrogen,
    CarbonDioxide,
    Methane,
    UserId,
    Humidity,
    Temperatur,
    datetimeL
)
VALUES
(   2,        -- Oxygen - int
    3,        -- Nitrogen - int
    6,        -- CarbonDioxide - int
    8,        -- Methane - int
    61,        -- UserId - int
    44,        -- Humidity - int
    77,        -- Temperatur - int
    '2016-04-22 12:12:12' -- DateTime - datetime
    )