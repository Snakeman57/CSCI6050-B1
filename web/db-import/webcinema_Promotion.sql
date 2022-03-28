DROP TABLE IF EXISTS `promotion`;
CREATE TABLE `promotion` (
  `movieID` int NOT NULL AUTO_INCREMENT,
  `ticketTypeID` varchar(45) NOT NULL,
  `startDate` datetime NOT NULL,
  `endDate` datetime NOT NULL,
  `startTime` datetime NOT NULL,
  `endTime` datetime NOT NULL,
  `movieCategory` varchar(45) NOT NULL,
  `directorName` varchar(45) NOT NULL,
  PRIMARY KEY (`movieID`,`ticketTypeID`),
  UNIQUE KEY `movieID_UNIQUE` (`movieID`),
  UNIQUE KEY `ticketTypeID_UNIQUE` (`ticketTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `promotion` WRITE;