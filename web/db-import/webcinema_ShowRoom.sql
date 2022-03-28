DROP TABLE IF EXISTS `showRoom`;
CREATE TABLE `showRoom` (
  `shows` varchar(45) NOT NULL,
  `numSeats` int NOT NULL,
  PRIMARY KEY (`shows`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `showRoom` WRITE;