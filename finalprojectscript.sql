CREATE TABLE `abilities` (
  `AbilityId` int NOT NULL AUTO_INCREMENT,
  `Ability1` varchar(1000) NOT NULL,
  `Ability2` varchar(1000) NOT NULL,
  `Ability3` varchar(1000) NOT NULL,
  `Ult` varchar(1000) NOT NULL,
  `Innate` varchar(1000) NOT NULL,
  PRIMARY KEY (`AbilityId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci
CREATE TABLE `champions` (
  `ChampionId` int NOT NULL AUTO_INCREMENT,
  `ChampionName` varchar(1000) NOT NULL,
  `ChampionRole` varchar(1000) NOT NULL,
  `Difficulty` int NOT NULL,
  `AbilityId` int DEFAULT NULL,
  PRIMARY KEY (`ChampionId`),
  KEY `FK_ChampionsAbilities` (`AbilityId`),
  CONSTRAINT `FK_ChampionsAbilities` FOREIGN KEY (`AbilityId`) REFERENCES `abilities` (`AbilityId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci