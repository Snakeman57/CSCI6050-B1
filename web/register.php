<?php include "server.php"; error_reporting(E_ERROR); ?>
<?php
  function redirect($msg){
    if($msg != ''){
      header("Location: register-success.php?msg=" . $msg);
    }
    else{
      header("Location: register-success.php");
    }
    die();
  }
?>

<!DOCTYPE html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <!-- Ensures proper rendering and touch zooming for all devices -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Required Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <!-- Custom CSS -->
    <link href="style.css" rel="stylesheet" />
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
    <!-- Handle Optionals -->
    <script src="register.js"></script>
    <?php
    $message = "";
    //class pay{
    //  public $num;
    //  public $addr;
    //  public $exp;
    //  function _makeAddr($str, $city, $state, $zip){
    //    $this->addr = array($str, $city, $state, $zip);
    //  }
    //  function _construct($num, $str, $city, $state, $zip, $exp){
    //    $this->num = 
    //    $this->addr = 
    //    $this->addr = 
    //  }
    //}
    // Register user
    if (isset($_POST['create'])) {
      $firstName = trim($_POST['firstName']);
      $lastName = trim($_POST['lastName']);
      //$userName = trim($_POST['userName']);
      $email = trim($_POST['email']);
      $password = trim($_POST['password']);
      $confirmpassword = trim($_POST['confirmpassword']);
      $secq = trim($_POST['secq']);
      $promo = trim($_POST['promo']);
      
      $isValid = true;
  
      // Check fields are empty or not
      if ($firstName == '' || $lastName == '' || $secq = ''|| $email == '' || $password == '' || $confirmpassword == '') {
          $isValid = false;
          $message = "Please fill all required fields.";
      }
      // Check if confirm password matching or not
      if ($isValid && ($password != $confirmpassword)) {
          $isValid = false;
          $message = "Passwords do not match";
      }
      // Check if Email-ID is valid or not
      if ($isValid && !filter_var($email, FILTER_VALIDATE_EMAIL)) {
          $isValid = false;
          $message = "Invalid Email Address.";
      }
      if ($isValid) {
        // Check if Email-ID already exists
        $stmt = $con->prepare("SELECT * FROM customer WHERE email = ?");
        $stmt->bind_param("s", $email);
        $stmt->execute();
        $result = $stmt->get_result();
        $stmt->close();
        if ($result->num_rows > 0) {
            $isValid = false;
            $message = "Email Address already in use.";
        }
      }
      // Check payment cards
      $pay1 = trim($_POST['pay1']);
      if($pay1){
        $p1no = trim($_POST['pay1-num']);
        $p1a1 = trim($_POST['pay1-addr-str']);
        $p1a2 = trim($_POST['pay1-addr-city']);
        $p1a3 = trim($_POST['pay1-addr-state']);
        $p1a4 = trim($_POST['pay1-addr-zip']);
        $p1ex = trim($_POST['pay1-ex']);
        if ($p1no == '' || $p1a1 == '' || $p1a2 = ''|| $p1a3 == '' || $p1a4 == '' || $p1ex == '') { // Check fields are empty or not
            $isValid = false;
            $message = "Please fill all fields for selected payment cards.";
        }
        if ($isValid) { // Check if card already exists
          $stmt = $con->prepare("SELECT * FROM paymentcard WHERE number = ?");
          $stmt->bind_param("s", $p1no);
          $stmt->execute();
          $result = $stmt->get_result();
          $stmt->close();
          if ($result->num_rows > 0) {
              $isValid = false;
              $message = "Card 1 already in use.";
          }
        }
      }
      $pay2 = trim($_POST['pay2']);
      if($pay2){
        $p2no = trim($_POST['pay2-num']);
        $p2a1 = trim($_POST['pay2-addr-str']);
        $p2a2 = trim($_POST['pay2-addr-city']);
        $p2a3 = trim($_POST['pay2-addr-state']);
        $p2a4 = trim($_POST['pay2-addr-zip']);
        $p2ex = trim($_POST['pay2-ex']);
        if ($p2no == '' || $p2a1 == '' || $p2a2 = ''|| $p2a3 == '' || $p2a4 == '' || $p2ex == '') { // Check fields are empty or not
            $isValid = false;
            $message = "Please fill all fields for selected payment cards.";
        }
        if ($isValid) { // Check if card already exists
          $stmt = $con->prepare("SELECT * FROM paymentcard WHERE number = ?");
          $stmt->bind_param("s", $p2no);
          $stmt->execute();
          $result = $stmt->get_result();
          $stmt->close();
          if ($result->num_rows > 0) {
              $isValid = false;
              $message = "Card 2 already in use.";
          }
        }
      }
      $pay3 = trim($_POST['pay3']);
      if($pay3){
        $p3no = trim($_POST['pay3-num']);
        $p3a1 = trim($_POST['pay3-addr-str']);
        $p3a2 = trim($_POST['pay3-addr-city']);
        $p3a3 = trim($_POST['pay3-addr-state']);
        $p3a4 = trim($_POST['pay3-addr-zip']);
        $p3ex = trim($_POST['pay3-ex']);
        if ($p3no == '' || $p3a1 == '' || $p3a2 = ''|| $p3a3 == '' || $p3a4 == '' || $p3ex == '') { // Check fields are empty or not
            $isValid = false;
            $message = "Please fill all fields for selected payment cards.";
        }
        if ($isValid) { // Check if card already exists
          $stmt = $con->prepare("SELECT * FROM paymentcard WHERE number = ?");
          $stmt->bind_param("s", $p3no);
          $stmt->execute();
          $result = $stmt->get_result();
          $stmt->close();
          if ($result->num_rows > 0) {
              $isValid = false;
              $message = "Card 3 already in use.";
          }
        }
      }
      // Insert records
      if ($isValid) {
        $insertSQL = "INSERT INTO customer (password, firstName, lastName, email, promo, sqAnswer) values(?,?,?,?,?,?)";
        $stmt = $con->prepare($insertSQL);
        $stmt->bind_param("ssssss", password_hash($password, PASSWORD_DEFAULT), $firstName, $lastName, $email, $promo, $secq);
        var_dump($stmt);
        $stmt->execute();
        $stmt->close();
        
        if($pay1){
          $updt = "UPDATE customer SET paymentCard = ? WHERE customer.email = ?";
          $stmt = $con->prepare($updt);
          $stmt->bind_param("ss", $p1no, $email);
          var_dump($stmt);
          $stmt->execute();
          $stmt->close();
          $ins = "INSERT INTO paymentcard (number, street, city, state, zip, expireDate) values(?,?,?,?,?,?)";
          $stmt = $con->prepare($ins);
          $stmt->bind_param("ssssss", $p1no, $p1a1, $p1a2, $p1a3, $p1a4, $p1ex);
          var_dump($stmt);
          $stmt->execute();
          $stmt->close();
        }
        if($pay2){
          $updt = "UPDATE customer SET paymentCard = ? WHERE customer.email = ?";
          $stmt = $con->prepare($updt);
          $stmt->bind_param("ss", $p2no, $email);
          var_dump($stmt);
          $stmt->execute();
          $stmt->close();
          $ins = "INSERT INTO paymentcard (number, street, city, state, zip, expireDate) values(?,?,?,?,?,?)";
          $stmt = $con->prepare($ins);
          $stmt->bind_param("ssssss", $p1no, $p2a1, $p2a2, $p2a3, $p2a4, $p2ex);
          var_dump($stmt);
          $stmt->execute();
          $stmt->close();
        }
        if($pay3){
          $updt = "UPDATE customer SET paymentCard = ? WHERE customer.email = ?";
          $stmt = $con->prepare($updt);
          $stmt->bind_param("ss", $p3no, $email);
          var_dump($stmt);
          $stmt->execute();
          $stmt->close();
          $ins = "INSERT INTO paymentcard (number, street, city, state, zip, expireDate) values(?,?,?,?,?,?)";
          $stmt = $con->prepare($ins);
          $stmt->bind_param("ssssss", $p3no, $p3a1, $p3a2, $p3a3, $p3a4, $p3ex);
          var_dump($stmt);
          $stmt->execute();
          $stmt->close();
        }
        ini_set("SMTP","ssl://smtp.gmail.com");
        ini_set("smtp_port","587");
        if(mail($email, "Account Verification", "localhost/web/verify.php?email=" . $email, "From: no-reply@B1Cinemas.com")){
          redirect('');
        }
        else{
          redirect($email);
        }
      }
    }
    ?>
    <title>B1 Cinemas</title>
  </head>
  <body>
    <!-- Navbar component -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a href="index.php" class="navbar-brand">Cinemaster</a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="index.php" class="nav-item nav-link active">Home</a>
                    <a href="#" class="nav-item nav-link">Showtimes</a>
                    <a href="#" class="nav-item nav-link">Promotions</a>
                    <a href="#" class="nav-item nav-link">Contact</a>
                </div>
                <!-- Searh Bar -->
                <div class="navbar-nav ms-auto">
                    <a href="register.php" class="nav-item nav-link">Register</a>
                    <a href="login.php" class="nav-item nav-link">Login</a>
                    <a class="btn btn-outline-success mx-2" data-bs-toggle="collapse" href="#collapseSearch" role="button" aria-expanded="false" aria-controls="collapseSearch">
                        Search
                    </a>
                </div>
                <!-- Search Bar -->
            </div>
        </div>
    </nav>
    <div class="collapse" id="collapseSearch">
        <div class="card card-body">
            <form class="d-flex">
                <input class="form-control me-2" type="search" placeholder="Search Movies" aria-label="Search">
                <button class="btn btn-outline-success" type="submit">Search</button>
            </form>
        </div>
    </div>
    <div class="container border p-3 mt-4 form-horizontal">
        <div class="row">
          <h2 class="text-center">Create an Account!</h2>
          <h5 class="text-muted text-center">Please complete the form below.</h5>
          <br>
          <br>
          <form method="post" action=''>
            <?php if($message != "")echo "<div class=\"alert alert-danger alert-dismissible\" role=\"alert\">". $message . "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div>" ?>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <label><b>Required:</b></label>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
              <label class="form-label" for="firstName">First Name</label>
              <input type="text" class="form-control" id="inputFirstName" placeholder="First Name" name="firstName">
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
              <label class="form-label" for="lastName">Last Name</label>
              <input type="text" class="form-control" id="inputLastName" placeholder="Last Name" name="lastName">
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <label class="form-label" for="inputEmail">Email</label>
              <input type="email" class="form-control" id="inputEmail" placeholder="Email" name="email">
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <label class="form-label" for="inputPassword">Password</label>
              <input type="password" class="form-control" id="inputPassword" placeholder="Password" name="password">
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <label class="form-label" for="confirmPassword">Confirm Password</label>
              <input type="password" class="form-control" id="confirmPassword" placeholder="Confirm Password" name="confirmpassword">
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <label class="form-label" for="secq">Password Recovery</label>
              <label class="form-label" for="secq">Please enter the name of your first pet below</label>
              <input type="text" class="form-control" id="secq" placeholder="Pet Name" name="secq">
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <label><b>Optional:</b></label>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <input type="checkbox" id="pay1" name="pay1" value=1>
              <label class="form-label" for="pay1">Add Payment Card</label>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto" id="pay1-ct" style="display:none">
              <label class="form-label" for="pay1-addr">Card Number</label>    
              <input type="password" class="form-control" id="pay1-num" placeholder="Card Number" name="pay1-num" disabled=true>
              <br/>
              <label class="form-label" for="pay1-addr">Billing Address</label>              
              <input type="text" class="form-control" id="pay1-addr-str" placeholder="Street" name="pay1-addr-str" disabled=true>
              <input type="text" class="form-control" id="pay1-addr-city" placeholder="City" name="pay1-addr-city" disabled=true>
              <input type="text" class="form-control" id="pay1-addr-state" placeholder="State" name="pay1-addr-state" disabled=true>
              <input type="number" class="form-control" id="pay1-addr-zip" placeholder="Zip" name="pay1-addr-zip" disabled=true>
              <br/>
              <label class="form-label" for="pay1-addr">Expiration Date</label>    
              <input type="text" class="form-control" id="pay1-ex" placeholder="Expiration Date" name="pay1-ex" disabled=true>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <input type="checkbox" id="pay2" name="pay2" value=1>
              <label class="form-label" for="pay2">Add Payment Card</label>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto" id="pay2-ct" style="display:none">
              <label class="form-label" for="pay2-addr">Card Number</label>    
              <input type="password" class="form-control" id="pay2-num" placeholder="Card Number" name="pay2-num" disabled=true>
              <br/>
              <label class="form-label" for="pay2-addr">Billing Address</label>              
              <input type="text" class="form-control" id="pay2-addr-str" placeholder="Street" name="pay2-addr-str" disabled=true>
              <input type="text" class="form-control" id="pay2-addr-city" placeholder="City" name="pay2-addr-city" disabled=true>
              <input type="text" class="form-control" id="pay2-addr-state" placeholder="State" name="pay2-addr-state" disabled=true>
              <input type="number" class="form-control" id="pay2-addr-zip" placeholder="Zip" name="pay2-addr-zip" disabled=true>
              <br/>
              <label class="form-label" for="pay2-addr">Expiration Date</label>    
              <input type="text" class="form-control" id="pay2-ex" placeholder="Expiration Date" name="pay2-ex" disabled=true>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <input type="checkbox" id="pay3" name="pay3" value=1>
              <label class="form-label" for="pay3">Add Payment Card</label>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto" id="pay3-ct" style="display:none">
              <label class="form-label" for="pay3-addr">Card Number</label>    
              <input type="password" class="form-control" id="pay3-num" placeholder="Card Number" name="pay3-num" disabled=true>
              <br/>
              <label class="form-label" for="pay3-addr">Billing Address</label>              
              <input type="text" class="form-control" id="pay3-addr-str" placeholder="Street" name="pay3-addr-str" disabled=true>
              <input type="text" class="form-control" id="pay3-addr-city" placeholder="City" name="pay3-addr-city" disabled=true>
              <input type="text" class="form-control" id="pay3-addr-state" placeholder="State" name="pay3-addr-state" disabled=true>
              <input type="number" class="form-control" id="pay3-addr-zip" placeholder="Zip" name="pay3-addr-zip" disabled=true>
              <br/>
              <label class="form-label" for="pay3-addr">Expiration Date</label>    
              <input type="text" class="form-control" id="pay3-ex" placeholder="Expiration Date" name="pay3-ex" disabled=true>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <input type="checkbox" id="promo" name="promo" value=1>
              <label class="form-label" for="promo">Accept Promotional Emails</label>
            </div>
            <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
              <button type="submit" name="create" class="col-12 btn btn-primary mt-3">Submit</button>
            </div>
            <!-- <div class="col-md-6 col-lg-5 col-xl-3 mb-3">
                <img src="images/recaptcha-placeholder.png" style="width: 19rem;"></img>
            </div>                 -->
            <!-- <button type="submit" class="btn btn-primary">Submit</button> -->
          </form>
          <script>startPay();</script>
        </div>
    </div>
    <br>
    <!-- Footer -->
    <footer class="text-center text-lg-start bg-light text-muted">
        <section>
            <div class="container text-center text-md-start">
                <div class="row py-3 t-3">
                    <div class="col-md-4 col-lg-3 col-xl-3 mx-auto text-center mb-md-0 mb-4">
                        <h6 class="text-uppercase fw-bold mb-4">
                            Contact
                        </h6>
                        <p>Athens, GA</p>
                        <p>
                            b1-cinemas@cinemaster.com
                        </p>
                        <p>(123) 555-5555</p>
                    </div>
                </div>
            </div>
        </section>
        <div class="text-center p-4" style="background-color: rgba(0, 0, 0, 0.05);">
            B1 Cinemas © 2022 Copyright
        </div>
    </footer>
    <!-- Footer -->
  
    <!-- Required Bootstrap Bundle with Popper -->
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p" crossorigin="anonymous"></script>
    <script src="index.js"></script>
  </body>
</html>