<?php
  session_start();
  unset($_SESSION["email"]);
  unset($_SESSION["password"]);
  echo "<script>alert(\"Logged out successfully!\");window.location.replace(\"index.php\")</script>"
?>