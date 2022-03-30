<?php include "server.php"; error_reporting(E_ERROR); ?>

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
    <link href="editprofile.css" rel="stylesheet" />
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
    <script src="register.js"></script>
    <title>B1 Cinemas</title>
</head>

<body>
    <!-- Navbar component -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a href="index.html" class="navbar-brand">B1 Cinemas</a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="index.html" class="nav-item nav-link active">Home</a>
                    <a href="#" class="nav-item nav-link">Showtimes</a>
                    <a href="#" class="nav-item nav-link">Promotions</a>
                    <a href="#" class="nav-item nav-link">Contact</a>
                </div>
                <!-- Search Bar -->
                <div class="navbar-nav ms-auto">
                    <a class="btn btn-outline-success mx-2" data-bs-toggle="collapse" href="#collapseSearch" role="button" aria-expanded="false" aria-controls="collapseSearch">
                        Search
                    </a>
                </div>
                <!-- Dropdown -->
                  <?php
                    if(isset($_SESSION['email'])){
                      echo "<div class=\"dropdown\">
                        <button class=\"btn btn-secondary dropdown-toggle\" type=\"button\" id=\"dropdownMenuButton1\"
                          data-bs-toggle=\"dropdown\" aria-expanded=\"false\">
                          Welcome, " . $_SESSION['email'] .
                        "</button>
                        <ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuButton1\">
                          <li><a class=\"dropdown-item\" href=\"logout.php\">Logout</a></li>
                        </ul>
                      </div>";
                    }
                    else{
                      echo "<script>window.location.replace(\"index.php\")</script>";
                    }
                  ?>
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

    <div class="container-xl px-4 mt-4">
        <!-- Account page navigation-->
        <nav class="nav nav-borders">
            <a class="nav-link active ms-0" href="editprofile.html" target="__blank">Profile</a>
        </nav>
        <hr class="mt-0 mb-4">
        <div class="row">
            <!--<div class="col-xl-4">
                <!-- Profile picture card-->
                <!--<div class="card mb-4 mb-xl-0">
                    <div class="card-header">Profile Picture</div>
                    <div class="card-body text-center">
                        <!-- Profile picture image-->
                        <!--<img class="img-account-profile rounded-circle mb-2" src="http://bootdey.com/img/Content/avatar/avatar1.png" alt="">
                        <!-- Profile picture help block-->
                        <!--<div class="small font-italic text-muted mb-4">JPG or PNG no larger than 5 MB</div>
                        <!-- Profile picture upload button-->
                        <!--<button class="btn btn-primary" type="button">Upload new image</button>
                    </div>
                </div>
            </div>-->
            <div class="col-xl-8">
                <!-- Account details card-->
                <div class="card mb-4">
                    <div class="card-header">Account Details</div>
                    <div class="card-body">
                        <form method="post">
                          <?php
                            if(isset($_SESSION['email'])){
                              $stmt = $con->prepare("SELECT firstName, lastName, paymentCard, paymentCard2, paymentCard3, favTheater, phone, birthday, promo FROM customer WHERE email = ?");
                              $stmt->bind_param("s", $_SESSION['email']);
                              $stmt->execute();
                              $result = $stmt->get_result();
                              $stmt->close();
                              $res = mysqli_fetch_all($result, MYSQLI_ASSOC);
                              //print_r($res);
                              foreach($res as $i){
                                $res = $i;
                                break;
                              }
                              $firstName = $res['firstName'];
                              $lastName = $res['lastName'];
                              $pay1 = $res['paymentCard'];
                              $pay2 = $res['paymentCard2'];
                              $pay3 = $res['paymentCard3'];
                              $favMovieTheater = $res['favTheater'];
                              $phoneNumber = $res['phone'];
                              $birthday = $res['birthday'];
                              $promo = $res['promo'];
                            }
                            if (isset($_POST['editProfile'])) {
                              $email = $_SESSION['email'];
                              //$userName = trim($_POST['userName']);
                              $firstName = trim($_POST['firstName']);
                              $lastName = trim($_POST['lastName']);
                              $favMovieTheater = trim($_POST['favMovieTheater']);
                              $phoneNumber = trim($_POST['phoneNumber']);
                              $birthday = trim($_POST['birthday']);
                              $promo = $_POST['promo'];
                              $pass = trim($_POST['password']);
                              $passc = trim($_POST['passwordc']);
                              $delta = false;
                              // change fname
                              if($firstName != ''){
                                $updt = "UPDATE customer SET firstName = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $firstName, $email);
                                //var_dump($stmt);
                                $stmt->execute();
                                $stmt->close();
                                $delta = true;
                              }
                              // change lname
                              if($lastName != ''){
                                $updt = "UPDATE customer SET lastName = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $lastName, $email);
                                //var_dump($stmt);
                                $stmt->execute();
                                $stmt->close();
                                $delta = true;
                              }
                              // change password
                              if($pass != ''){
                                $stmt = $con->prepare("SELECT * FROM user WHERE email = ? AND password = ?");
                                $stmt->bind_param("ss", $email, $passc);
                                $stmt->execute();
                                $result = $stmt->get_result();
                                $stmt->close();
                                if ($result->num_rows > 0) {
                                  $updt = "UPDATE customer SET lastName = ? WHERE customer.email = ?";
                                  $stmt = $con->prepare($updt);
                                  $stmt->bind_param("ss", $lastName, $email);
                                  //var_dump($stmt);
                                  $stmt->execute();
                                  $stmt->close();
                                  $delta = true;
                                }
                                else{
                                  echo "<script>alert(\"Password could not be changed as old password was inavlid.\");</script>";
                                }
                              }
                              // change movie
                              if($favMovieTheater != ''){
                                $updt = "UPDATE customer SET favTheater = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $favMovieTheater, $email);
                                //var_dump($stmt);
                                $stmt->execute();
                                $stmt->close();
                                $delta = true;
                              }
                              // change phone
                              if($phoneNumber != ''){
                                $updt = "UPDATE customer SET phone = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $phoneNumber, $email);
                                //var_dump($stmt);
                                $stmt->execute();
                                $stmt->close();
                                $delta = true;
                              }
                              // change bday
                              if($birthday != ''){
                                $updt = "UPDATE customer SET birthday = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $birthday, $email);
                                //var_dump($stmt);
                                $stmt->execute();
                                $stmt->close();
                                $delta = true;
                              }
                              // change promo
                              $updt = "UPDATE customer SET promo = ? WHERE customer.email = ?";
                              $stmt = $con->prepare($updt);
                              $stmt->bind_param("ss", $promo, $email);
                              //var_dump($stmt);
                              $stmt->execute();
                              $stmt->close();
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
                                  echo "<script>alert(\"Card 1 could not be changed because not all fields were filled.\")</script>";
                                }
                                else { // Check if card already exists
                                  $stmt = $con->prepare("SELECT * FROM paymentcard WHERE number = ?");
                                  $stmt->bind_param("s", $p1no);
                                  $stmt->execute();
                                  $result = $stmt->get_result();
                                  $stmt->close();
                                  if ($result->num_rows > 0) {
                                    $stmt = $con->prepare("DELETE FROM paymentcard WHERE number = ?");
                                    $stmt->bind_param("s", $p1no);
                                    $stmt->execute();
                                    $result = $stmt->get_result();
                                    $stmt->close();
                                  }
                                  $updt = "UPDATE customer SET paymentCard = ? WHERE customer.email = ?";
                                  $stmt = $con->prepare($updt);
                                  $stmt->bind_param("ss", $p1no, $email);
                                  $stmt->execute();
                                  $stmt->close();
                                  $ins = "INSERT INTO paymentcard (number, street, city, state, zip, expireDate) values(?,?,?,?,?,?)";
                                  $stmt = $con->prepare($ins);
                                  $stmt->bind_param("ssssss", $p1no, $p1a1, $p1a2, $p1a3, $p1a4, $p1ex);
                                  $stmt->execute();
                                  $stmt->close();
                                  $delta = true;
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
                                  echo "<script>alert(\"Card 2 could not be changed because not all fields were filled.\")</script>";
                                }
                                else { // Check if card already exists
                                  $stmt = $con->prepare("SELECT * FROM paymentcard WHERE number = ?");
                                  $stmt->bind_param("s", $p2no);
                                  $stmt->execute();
                                  $result = $stmt->get_result();
                                  $stmt->close();
                                  if ($result->num_rows > 0) {
                                    $stmt = $con->prepare("DELETE FROM paymentcard WHERE number = ?");
                                    $stmt->bind_param("s", $p2no);
                                    $stmt->execute();
                                    $result = $stmt->get_result();
                                    $stmt->close();
                                  }
                                  $updt = "UPDATE customer SET paymentCard2 = ? WHERE customer.email = ?";
                                  $stmt = $con->prepare($updt);
                                  $stmt->bind_param("ss", $p2no, $email);
                                  $stmt->execute();
                                  $stmt->close();
                                  $ins = "INSERT INTO paymentcard (number, street, city, state, zip, expireDate) values(?,?,?,?,?,?)";
                                  $stmt = $con->prepare($ins);
                                  $stmt->bind_param("ssssss", $p2no, $p2a1, $p2a2, $p2a3, $p2a4, $p2ex);
                                  $stmt->execute();
                                  $stmt->close();
                                  $delta = true;
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
                                  echo "<script>alert(\"Card 3 could not be changed because not all fields were filled.\")</script>";
                                }
                                else { // Check if card already exists
                                  $stmt = $con->prepare("SELECT * FROM paymentcard WHERE number = ?");
                                  $stmt->bind_param("s", $p3no);
                                  $stmt->execute();
                                  $result = $stmt->get_result();
                                  $stmt->close();
                                  if ($result->num_rows > 0) {
                                    $stmt = $con->prepare("DELETE FROM paymentcard WHERE number = ?");
                                    $stmt->bind_param("s", $p3no);
                                    $stmt->execute();
                                    $result = $stmt->get_result();
                                    $stmt->close();
                                  }
                                  $updt = "UPDATE customer SET paymentCard3 = ? WHERE customer.email = ?";
                                  $stmt = $con->prepare($updt);
                                  $stmt->bind_param("ss", $p3no, $email);
                                  $stmt->execute();
                                  $stmt->close();
                                  $ins = "INSERT INTO paymentcard (number, street, city, state, zip, expireDate) values(?,?,?,?,?,?)";
                                  $stmt = $con->prepare($ins);
                                  $stmt->bind_param("ssssss", $p3no, $p3a1, $p3a2, $p3a3, $p3a4, $p3ex);
                                  $stmt->execute();
                                  $stmt->close();
                                  $delta = true;
                                }
                              }
                              if($delta){
                                echo "<script>window.location.replace(\"editprofile-success.php\");</script>";
                              }
                              else{
                                echo "<script>window.location.replace(\"editprofile-failure.php\");</script>";
                              }
                            }
                          ?>
                          <!-- Form Row-->
                          <div class="row gx-3 mb-3">
                              <!-- Form Group (first name)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputFirstName">First name</label>
                                  <input class="form-control" id="inputFirstName" type="text" placeholder="<?php if($firstName != ''){ echo $firstName; }else{ echo "Enter your first name"; } ?>" name="firstName">
                              </div>
                              <!-- Form Group (last name)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputLastName">Last name</label>
                                  <input class="form-control" id="inputLastName" type="text" placeholder="<?php if($lastName != ''){ echo $lastName; }else{ echo "Enter your last name"; } ?>" name="lastName">
                              </div>
                          </div>
                          <!-- Form Row        -->
                          <div class="row gx-3 mb-3">
                              <div class="mb-3">
                                  <label class="small mb-1" for="password">Password</label>
                                  <input class="form-control" id="password" type="text" placeholder="New Password" name="password">
                                  <br/>
                                  <input class="form-control" id="passwordc" type="text" placeholder="Confirm Old Password" name="passwordc">
                              </div>
                          </div>
                          <div class="row gx-3 mb-3">
                            <div class="mb-3">
                              <input type="checkbox" id="pay1" name="pay1" value=1>
                              <label class="form-label" for="pay1"><?php if($pay1 != ''){ echo "Edit"; }else{ echo "Add"; } ?> Payment Card</label>
                            </div>
                            <div class="mb-3" id="pay1-ct" style="display:none">
                              <label class="form-label" for="pay1-addr">Card Number</label>    
                              <input type="password" class="form-control" id="pay1-num" placeholder="Card Number" name="pay1-num" disabled=pay1.checked>
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
                          </div>
                          <div class="row gx-3 mb-3">
                            <div class="mb-3">
                              <input type="checkbox" id="pay2" name="pay2" value=1>
                              <label class="form-label" for="pay2"><?php if($pay2 != ''){ echo "Edit"; }else{ echo "Add"; } ?> Payment Card</label>
                            </div>
                            <div class="mb-3" id="pay2-ct" style="display:none">
                              <label class="form-label" for="pay2-addr">Card Number</label>    
                              <input type="password" class="form-control" id="pay2-num" placeholder="Card Number" name="pay2-num" disabled=pay2.checked>
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
                          </div>
                          <div class="row gx-3 mb-3">
                            <div class="mb-3">
                              <input type="checkbox" id="pay3" name="pay3" value=1>
                              <label class="form-label" for="pay3"><?php if($pay3 != ''){ echo "Edit"; }else{ echo "Add"; } ?> Payment Card</label>
                            </div>
                            <div class="mb-3" id="pay3-ct" style="display:none">
                              <label class="form-label" for="pay3-addr">Card Number</label>    
                              <input type="password" class="form-control" id="pay3-num" placeholder="Card Number" name="pay3-num" disabled=pay3.checked>
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
                          </div>
                          <!-- Form Row        -->
                          <div class="row gx-3 mb-3">
                            <div class="mb-3">
                              <label class="small mb-1" for="inputOrgName">Preffered Movie Theater</label>
                              <input class="form-control" id="inputOrgName" type="text" placeholder="<?php if($favMovieTheater != ''){ echo $favMovieTheater; }else{ echo "Enter your preffered location"; } ?>" name="favMovieTheater">
                            </div>
                          </div>
                          <!-- Form Row-->
                          <div class="row gx-3 mb-3">
                              <!-- Form Group (phone number)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputPhone">Phone number</label>
                                  <input class="form-control" id="inputPhone" type="tel" placeholder="<?php if($phoneNumber != ''){ echo $phoneNumber; }else{ echo "###-###-####"; } ?>" name="phoneNumber">
                              </div>
                              <!-- Form Group (birthday)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputBirthday">Birthday</label>
                                  <input class="form-control" id="inputBirthday" type="text" name="birthday" placeholder="<?php if($birthday != ''){ echo $birthday; }else{ echo "YYYY-MM-DD"; } ?>" name="birthday">
                              </div>
                          </div>
                          <div class="row gx-3 mb-3">
                            <div class="mb-3">
                              <input type="checkbox" id="promo" name="promo" value=1 checked="<?php if($promo != 0){ echo "true"; }else{ echo "false"; } ?>">
                              <label class="small mb-1" for="promo">Accept Promotional Emails</label>
                            </div>
                          </div>
                          <!-- Save changes button-->
                          <button id="editProfile" class="btn btn-primary" type="submit" name="editProfile">Save changes</button>
                        </form>
                        <script>startPay();</script>
                    </div>
                </div>
            </div>
        </div>
    </div>
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
                            b1-cinemas@movie.com
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
    <script src="coffee.js"></script>
</body>

</html>