<?php
include "server.php";
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
    <link href="editprofile.css" rel="stylesheet" />
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
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
                          Welcome," . $_SESSION['email'] .
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
            <div class="col-xl-4">
                <!-- Profile picture card-->
                <div class="card mb-4 mb-xl-0">
                    <div class="card-header">Profile Picture</div>
                    <div class="card-body text-center">
                        <!-- Profile picture image-->
                        <img class="img-account-profile rounded-circle mb-2" src="http://bootdey.com/img/Content/avatar/avatar1.png" alt="">
                        <!-- Profile picture help block-->
                        <div class="small font-italic text-muted mb-4">JPG or PNG no larger than 5 MB</div>
                        <!-- Profile picture upload button-->
                        <button class="btn btn-primary" type="button">Upload new image</button>
                    </div>
                </div>
            </div>
            <div class="col-xl-8">
                <!-- Account details card-->
                <div class="card mb-4">
                    <div class="card-header">Account Details</div>
                    <div class="card-body">
                        <form method="post">
                          <?php
                            if (isset($_POST['editProfile'])) {
                              $id = $_SESSION['email'];
                              //$userName = trim($_POST['userName']);
                              $firstName = trim($_POST['firstName']);
                              $lastName = trim($_POST['lastName']);
                              $favMovieTheater = trim($_POST['favMovieTheater']);
                              $phoneNumber = trim($_POST['phoneNumber']);
                              $birthday = trim($_POST['birthday']);
                              $promo = trim($_POST['promo']);
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
                              // change movie
                              if($favMovieTheater != ''){
                                $updt = "UPDATE customer SET favTheater = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $favTheater, $email);
                                //var_dump($stmt);
                                $stmt->execute();
                                $stmt->close();
                                $delta = true;
                              }
                              // change phone
                              if($phoneNumber != ''){
                                $updt = "UPDATE customer SET phone = ? WHERE customer.email = ?";
                                $stmt = $con->prepare($updt);
                                $stmt->bind_param("ss", $phone, $email);
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
                              if($delta) echo "<script>alert(\"Changes Saved!\")</script>";
                            }
                          ?>
                          <!-- Form Group (username)-->
                          <!-- <div class="mb-3">
                              <label class="small mb-1" for="inputUsername">Username (how your name will appear to other users on the site)</label>
                              <input class="form-control" id="inputUsername" type="text" placeholder="Enter your username" value="username" name="userName">
                          </div> -->
                          <!-- Form Row-->
                          <div class="row gx-3 mb-3">
                              <!-- Form Group (first name)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputFirstName">First name</label>
                                  <input class="form-control" id="inputFirstName" type="text" placeholder="Enter your first name" value="Valerie" name="firstName">
                              </div>
                              <!-- Form Group (last name)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputLastName">Last name</label>
                                  <input class="form-control" id="inputLastName" type="text" placeholder="Enter your last name" value="Luna" name="lastName">
                              </div>
                          </div>
                          <!-- Form Row        -->
                          <div class="row gx-3 mb-3">
                              <!-- Form Group (organization name)-->
                              <div class="mb-3">
                                  <label class="small mb-1" for="inputOrgName">Preffered Movie Theater</label>
                                  <input class="form-control" id="inputOrgName" type="text" placeholder="Enter your preffered location" value="AMC Athens" name="favMovieTheater">
                              </div>
                              <!-- Form Group (location)-->
                              <!-- <div class="col-md-6">
                                  <label class="small mb-1" for="inputLocation">Zip Code</label>
                                  <input class="form-control" id="inputLocation" type="text" placeholder="XXXXX" value="30605" name="zipCode">
                              </div> -->
                          </div>
                          <!-- Form Group (email address)-->
                          <!-- <div class="mb-3">
                              <label class="small mb-1" for="inputEmailAddress">Email address</label>
                              <input class="form-control" id="inputEmailAddress" type="email" placeholder="Enter your email address" value="name@example.com">
                          </div> -->
                          <!-- Form Row-->
                          <div class="row gx-3 mb-3">
                              <!-- Form Group (phone number)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputPhone">Phone number</label>
                                  <input class="form-control" id="inputPhone" type="tel" placeholder="555-123-4567" name="phoneNumber">
                              </div>
                              <!-- Form Group (birthday)-->
                              <div class="col-md-6">
                                  <label class="small mb-1" for="inputBirthday">Birthday</label>
                                  <input class="form-control" id="inputBirthday" type="text" name="birthday" placeholder="MM/DD/YYYY" name="birthday">
                              </div>
                          </div>
                          <div class="row gx-3 mb-3">
                            <div class="mb-3">
                              <input type="checkbox" id="promo" name="promo" value=1>
                              <label class="small mb-1" for="promo">Accept Promotional Emails</label>
                            </div>
                          </div>
                          <!-- Save changes button-->
                          <button id="editProfile" class="btn btn-primary" type="submit" name="editProfile">Save changes</button>
                        </form>
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