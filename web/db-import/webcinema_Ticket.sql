DROP TABLE IF EXISTS `ticket`;
CREATE TABLE `ticket` (
  `typeID` int NOT NULL,
  `num` int NOT NULL,
  `totalPrice` int NOT NULL,
  PRIMARY KEY (`typeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `ticket` WRITE;