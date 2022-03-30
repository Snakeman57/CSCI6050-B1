DROP TABLE IF EXISTS `paymentCard`;
CREATE TABLE `paymentCard` (
  `number` int NOT NULL,
  `billingAddr` varchar(255) NOT NULL,
  `expireDate` datetime NOT NULL,
  PRIMARY KEY (`number`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `paymentCard` WRITE;