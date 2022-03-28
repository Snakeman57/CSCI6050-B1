DROP TABLE IF EXISTS `Catalog`;
CREATE TABLE `Catalog` (
  `movies` int NOT NULL,
  `promos` varchar(45) DEFAULT NULL,
  `ticketType` varchar(45) NOT NULL,
  PRIMARY KEY (`movies`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `Catalog` WRITE;
