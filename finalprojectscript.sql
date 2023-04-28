CREATE DATABASE leaguechampions;

CREATE TABLE `abilities` (
  `AbilityId` int NOT NULL AUTO_INCREMENT,
  `Ability1` varchar(1000) NOT NULL,
  `Ability2` varchar(1000) NOT NULL,
  `Ability3` varchar(1000) NOT NULL,
  `Ult` varchar(1000) NOT NULL,
  `Innate` varchar(1000) NOT NULL,
  PRIMARY KEY (`AbilityId`)
);

CREATE TABLE `champions` (
  `ChampionId` int NOT NULL AUTO_INCREMENT,
  `ChampionName` varchar(1000) NOT NULL,
  `ChampionRole` varchar(1000) NOT NULL,
  `Difficulty` int NOT NULL,
  `AbilityId` int DEFAULT NULL,
  PRIMARY KEY (`ChampionId`),
  KEY `FK_ChampionsAbilities` (`AbilityId`),
  CONSTRAINT `FK_ChampionsAbilities` FOREIGN KEY (`AbilityId`) REFERENCES `abilities` (`AbilityId`)
)
