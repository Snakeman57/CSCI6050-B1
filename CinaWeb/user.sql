CREATE TABLE `user` (
    `id` bigint(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `fname` varchar(50) NOT NULL,
    `lname` varchar(50) NOT NULL,
    `username` varchar(50) NOT NULL,
    `email` varchar(70) NOT NULL,
    `password` varchar(60) NOT NULL,
    `timemodified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE = InnoDB DEFAULT CHARSET = utf8;