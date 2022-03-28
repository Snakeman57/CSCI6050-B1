<?php
require "login.php";

// Database connection
 $conn = new mysqli('username', 'id', 'password', 'databasename');

 $pwd = $_POST['password'];

// hash it with PASSWORD_DEFAULT
$hash = password_hash($pwd,  
          PASSWORD_DEFAULT); 
$username = $_POST['username']; 

$insert ="INSERT into an_users (id, username, password) 
 VALUES  ('', '$username', '$hash')";

if($conn->query($insert)){
  echo 'Data inserted successfully';
}
 else{
  echo 'Error '.$conn->error;  
}
?>