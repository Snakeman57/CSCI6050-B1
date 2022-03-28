DROP TABLE IF EXISTS `Movie`;
CREATE TABLE `Movie` (
  `title` varchar(45) NOT NULL,
  `category` varchar(45) NOT NULL,
  `cast` varchar(45) NOT NULL,
  `director` varchar(45) NOT NULL,
  `producer` varchar(45) NOT NULL,
  `sysnopsis` varchar(45) NOT NULL,
  `reviews` varchar(45) NOT NULL,
  `trailerPic` varchar(45) NOT NULL,
  `trailVid` varchar(45) NOT NULL,
  `rating` int NOT NULL,
  `shows` datetime NOT NULL,
  `showID` int NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`showID`),
  UNIQUE KEY `showID_UNIQUE` (`showID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `Movie` WRITE;