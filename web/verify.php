<?php include "server.php" ?>
<?php
  if (isset($_GET['email'])) {
    $email = trim($_GET['email']);
    $stmt = $con->prepare("SELECT state FROM customer WHERE email = ?");
    $stmt->bind_param("s", $email);
    $stmt->execute();
    $result = $stmt->get_result();
    $stmt->close();
    if($result->num_rows > 0){
      foreach($result as $i){
        $result = $i;
        break;
      }
      if($result['state'] == "inactive"){
        $updt = "UPDATE customer SET state = \"active\" WHERE customer.email = ?";
        $stmt = $con->prepare($updt);
        $stmt->bind_param("s", $email);
        //var_dump($stmt);
        $stmt->execute();
        $stmt->close();
        echo "<script>
          alert(\"Account verified successfully!\")
          window.location.replace(\"login.php\")
        </script>";
      }
      else{
        echo "<script>
          alert(\"Account aldready verified!\")
          window.location.replace(\"login.php\")
        </script>";
      }
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