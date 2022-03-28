DROP TABLE IF EXISTS `Customer`;
CREATE TABLE `Customer` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `password` varchar(45) NOT NULL,
  `firstName` varchar(45) NOT NULL,
  `lastName` varchar(45) NOT NULL,
  `email` varchar(45) NOT NULL,
  `paymentCard` varchar(45),
  `state` varchar(45),
  `booking` varchar(45),
  PRIMARY KEY (`UserID`,`password`),
  UNIQUE KEY `UserID_UNIQUE` (`UserID`),
  UNIQUE KEY `paymentCard_UNIQUE` (`paymentCard`),
  UNIQUE KEY `booking_UNIQUE` (`booking`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `Customer` WRITE;