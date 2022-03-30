<?php include "server.php" ?>
<?php
  if (isset($_GET['email'])) {
    $email = trim($_GET['email']);
    $stmt = $con->prepare("SELECT * FROM customer WHERE email = ? AND password = ?");
    $stmt->bind_param("ss", $email, $password);
    $stmt->execute();
    $result = $stmt->get_result();
    $stmt->close();
    if($result->num_rows > 0){
      $updt = "UPDATE customer SET state = \"active\" WHERE customer.email = ?";
      $stmt = $con->prepare($updt);
      $stmt->bind_param("s", $email);
      //var_dump($stmt);
      $stmt->execute();
      $stmt->close();
      $delta = true;
      echo "<script>
        alert(\"Account verified successfully!\")
        window.location.replace(\"login.php\")
      </script>";
    }
    else{
    echo "<script>
      alert(\"Verification Failed! (invalid email address)\")
      window.location.replace(\"login.php\")
    </script>";
    }
  }
  else{
    echo "<script>
      alert(\"Verification Failed! (No email address provided)\")
      window.location.replace(\"login.php\")
    </script>";
  }
?>