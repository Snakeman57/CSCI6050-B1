DROP TABLE IF EXISTS `seat`;
CREATE TABLE `seat` (
  `numRow` int NOT NULL,
  `row` int NOT NULL,
  PRIMARY KEY (`numRow`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
LOCK TABLES `seat` WRITE;