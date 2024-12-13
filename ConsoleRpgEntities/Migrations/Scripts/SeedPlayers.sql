--  Update Existing Players
UPDATE Players SET Health = 500, Coins = 100, ActiveAbility = 1 WHERE Id = 1;
UPDATE Equipments SET ArmorId = 3, WeaponId = 49 WHERE Id = 1;

-- Seed Equipments
INSERT INTO Equipments (WeaponId, ArmorId )
VALUES
(69, 92),
(53, 66),
(19, 72),
(46, 52),
(114, 22),
(14, 96),
(103, 13),
(44, 11),
(4, 123);

--  Seed more players
INSERT INTO Players (Name, Health, Coins, ActiveAbility, EquipmentId)
VALUES
    ('Sir Robin of Locksley', 500, 100, 1, 2),
    ('William Wallace', 500, 100, 1, 3),
    ('Joan of Arc', 500, 100, 1, 4),
	('Sir Galahad', 500, 100, 1, 5),
	('Galadriel', 500, 100, 1, 6),
	('Legolas', 500, 100, 1,7),
	('Ragnar Lothbrok', 500, 100, 1, 8),
	('Astrid Hofferson', 500, 100, 1, 9),
	('Yennefer of Vengerberg ', 500, 100, 1, 10);

--  Seed Player Abilities
INSERT INTO PlayerAbilities (AbilitiesId, PlayersId)
VAlUES
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(1, 7),
(1, 8),
(1, 9),
(1, 10);
	




