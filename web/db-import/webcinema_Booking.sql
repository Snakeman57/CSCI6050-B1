DROP TABLE IF EXISTS `Booking`;
CREATE TABLE `Booking` (
  `tickets` int NOT NULL,
  `showID` int NOT NULL,
  `seats` int NOT NULL,
  `appliedPromo` varchar(45) DEFAULT NULL,
  `customer` varchar(45) NOT NULL,
  PRIMARY KEY (`tickets`,`showID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `Booking` WRITE;