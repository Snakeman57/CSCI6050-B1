<?php include "server.php"; ?>

<!DOCTYPE html>
<html lang="en">
<head>
    <!-- Required meta tags -->
    <meta charset="utf-8" />
    <!-- Ensures proper rendering and touch zooming for all devices -->
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- Required Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <!-- Custom CSS -->
    <link href="style.css" rel="stylesheet" />
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
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
                    <a class="btn btn-outline-success mx-2" data-bs-toggle="collapse" href="#collapseSearch" role="button"
                        aria-expanded="false" aria-controls="collapseSearch">
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
            <h2 class="text-center">Login</h2>
            <h5 class="text-muted text-center">Enter your details.</h5>
            <br>
            <br>
            <form method="post">
                <?php
                  $msg = "";
                  if(isset($_POST['login'])){
                    if(!empty($_POST['email']) && !empty($_POST['password'])){
                      $email = trim($_POST['email']);
                      $password = trim($_POST['password']);
                      // Check if Email exists
                      $stmt = $con->prepare("SELECT * FROM customer WHERE email = ? AND password = ?");
                      $stmt->bind_param("ss", $email, $password);
                      $stmt->execute();
                      $result = $stmt->get_result();
                      $stmt->close();
                      if ($result->num_rows > 0) {
                        $_SESSION['valid'] = true;
                        $_SESSION['timeout'] = time();
                        $_SESSION['email'] = $email;
                        echo "<script>
                          alert(\"Welcome Customer!\")
                          window.location.replace(\"index.php\")
                        </script>";
                      }
                      else {
                        $stmt = $con->prepare("SELECT * FROM user WHERE email = ? AND password = ?");
                        $stmt->bind_param("ss", $email, $password);
                        $stmt->execute();
                        $result = $stmt->get_result();
                        $stmt->close();
                        if ($result->num_rows > 0) {
                          $_SESSION['valid'] = true;
                          $_SESSION['timeout'] = time();
                          $_SESSION['email'] = $email;
                        echo "<script>
                          alert(\"Welcome Administrator!\")
                          window.location.replace(\"admin-home.php\")
                        </script>";
                        }
                        else{
                          $msg = "Invalid username and/or password.";
                        }
                      }/*
                      $_SESSION['valid'] = true;
                      $_SESSION['timeout'] = time();
                      $_SESSION['email'] = 'tutorialspoint';*/
                    }
                    else{
                      $msg = "Please enter username &amp; password";
                    }
                  }
                  if($msg != "")echo "<div class=\"alert alert-danger alert-dismissible\" role=\"alert\">". $msg . "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button></div>"
                ?>
                <!-- Login Prompt -->
                <div class="col-md-6 col-lg-5 col-xl-9 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="firstName">Email</label>
                    <input name="email" type="text" class="form-control" id="email" placeholder="Email">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-9 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="password">Password</label>
                    <input name="password" type="password" class="form-control" id="password" placeholder="Password">
                </div>
                <div class="d-flex justify-content-around align-items-center mb-4 mx-auto">
                  <!-- Checkbox -->
                  <!--<div class="form-check">
                    <input
                      class="form-check-input"
                      type="checkbox"
                      value=""
                      checked
                    />
                    <label class="form-check-label"> Remember me </label>
                  </div> -->
                  <a href="forgot.php">Forgot password?</a>
                </div>
                <button id="login" type="submit" class="btn btn-primary col-3 mx-auto" name="login" style="horizantal-align:center">Login</button>
            </form>
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"
        crossorigin="anonymous"></script>        
    <script src="index.js"></script>
</body>

</html>