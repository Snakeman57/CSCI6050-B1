DROP TABLE IF EXISTS `TicketType`;
CREATE TABLE `TicketType` (
  `typeID` int NOT NULL,
  `typeName` varchar(45) NOT NULL,
  `price` int NOT NULL,
  PRIMARY KEY (`typeID`),
  UNIQUE KEY `typeID_UNIQUE` (`typeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `TicketType` WRITE;
