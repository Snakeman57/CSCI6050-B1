<?php

$host = "localhost";    /* Host name */
$user = "root";         /* User */
$password = "";         /* Password */
$dbname = "CinemaWeb";   /* Database name */

// Create connection
$con = mysqli_connect($host, $user, $password,$dbname);

// Check connection
if(!$con){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}
?>