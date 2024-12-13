--  Update Existing Ability
UPDATE Abilities SET AbilityType = 'MeleeAbility', Damage = 1, value = 5 WHERE Id = 1;



--  Seed more Abliities
INSERT INTO Abilities (Name,  AbilityType, Damage, Distance, Value)
VALUES
    ('Jab', 'MeleeAbility', 5, 1, 10),
    ('Upper Cut', 'MeleeAbility', 10, 5, 80),
    ('Hay Maker', 'MeleeAbility', 15, 5, 120),
    ('Fury Punches', 'MeleeAbility', 25, 10, 250),
    ('Low Kick', 'MeleeAbility', 12, 2, 155),
    ('High Kick', 'MeleeAbility', 17, 8, 205),
    ('Head Kick', 'MeleeAbility', 20, 8, 225),
    ('Fury Kicks', 'MeleeAbility', 35, 12, 260);
