CREATE TABLE `user` (
    `id` bigint(11) NOT NULL PRIMARY KEY AUTO_INCREMENT,
    `firstName` varchar(50) NOT NULL,
    `lastName` varchar(50) NOT NULL,
    `userName` varchar(50) NOT NULL,
    `email` varchar(70) NOT NULL,
    `password` varchar(60) NOT NULL,
    `favMovieTheater` varchar(60) NOT NULL,
    `zipCode` int(6) NOT NULL,
    `phoneNumber` int(10) NOT NULL,
    `birthday` timestamp(60) NOT NULL,

    `timemodified` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE = InnoDB DEFAULT CHARSET = utf8;