<?php
require "login.php";

// Database connection
 $conn = new mysqli('nameoncard', 'billingadress', 'state', 'city', 'zipcode', 'cardnumber', 'cvv', 'expiredate');

 $pwd = $_POST['password'];

// hash it with PASSWORD_DEFAULT
$hash = password_hash($pwd,  
          PASSWORD_DEFAULT); 
$username = $_POST['username']; 

$insert ="INSERT into payment (id, username, nameoncard, cardnumber, zipcode) 
 VALUES  ('', '$username', '', '$hash', '')";
if($conn->query($insert)){
  echo 'Data inserted successfully';
}
 else{
  echo 'Error '.$conn->error;  
}
?>