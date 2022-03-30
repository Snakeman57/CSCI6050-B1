<?php
  if(isset($_GET['msg'])){
    echo "<script>
      alert(\"Account created successfully. Please check your email for a verification link. Verify at verify.php?email=" . $_GET['msg'] . "\")
      window.location.replace(\"login.php\")
    </script>";
  }
  else{
    echo "<script>
      alert(\"Account created successfully. Please check your email for a verification link.\")
      window.location.replace(\"login.php\")
    </script>";
  }
 ?>