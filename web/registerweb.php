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
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">

    <?php
    $error_message = "";
    $success_message = "";

    // Register user
    if (isset($_POST['create'])) {
        $firstName = trim($_POST['firstName']);
        $lastName = trim($_POST['lastName']);
        $userName = trim($_POST['userName']);
        $email = trim($_POST['email']);
        $password = trim($_POST['password']);
        $confirmpassword = trim($_POST['confirmpassword']);

        $isValid = true;

        // Check fields are empty or not
        if ($firstName == '' || $lastName == '' || $userName = ''|| $email == '' || $password == '' || $confirmpassword == '') {
            $isValid = false;
            $error_message = "Please fill all fields.";
        }
        // Check if confirm password matching or not
        if ($isValid && ($password != $confirmpassword)) {
            $isValid = false;
            $error_message = "Confirm password not matching";
        }

        // Check if Email-ID is valid or not
        if ($isValid && !filter_var($email, FILTER_VALIDATE_EMAIL)) {
            $isValid = false;
            $error_message = "Invalid Email-ID.";
        }

        if ($isValid) {
            // Check if Email-ID already exists
            $stmt = $con->prepare("SELECT * FROM user WHERE email = ?");
            $stmt->bind_param("s", $email);
            $stmt->execute();
            $result = $stmt->get_result();
            $stmt->close();
            if ($result->num_rows > 0) {
                $isValid = false;
                $error_message = "Email-ID is already existed.";
            }

            // Check if Username already exists
            $stmt = $con->prepare("SELECT * FROM user WHERE userName = ?");
            $stmt->bind_param("s", $userName);
            $stmt->execute();
            $result = $stmt->get_result();
            $stmt->close();
            if ($result->num_rows > 0) {
                $isValid = false;
                $error_message = "Username is already existed.";
            }
        }
        // Insert records
        if ($isValid) {
            $insertSQL = "INSERT INTO user (userName, password, firstName, lastName, email) values(?,?,?,?,?)";
            $stmt = $con->prepare($insertSQL);
            $stmt->bind_param("sssss", $userName, $password, $firstName, $lastName, $email);
            var_dump($stmt);
            $stmt->execute();
            $stmt->close();
            $success_message = "Account created successfully.";
        }
    }

    ?>
    <title>B1 Cinemas</title>
</head>

<body>
    <!-- Navbar component -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a href="index.html" class="navbar-brand">Cinemaster</a>
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
                <!-- Searh Bar -->
                <div class="navbar-nav ms-auto">
                    <a href="register.html" class="nav-item nav-link">Register</a>
                    <a href="login.html" class="nav-item nav-link">Login</a>
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
            <h6 id="required-fields">*All fields are required</h6>
            <br>
            <br>
            <form method="post" action=''>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="firstName">First Name</label>
                    <input type="text" class="form-control" id="inputFirstName" placeholder="First Name" name="firstName">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="lastName">Last Name</label>
                    <input type="text" class="form-control" id="inputLastName" placeholder="Last Name" name="lastName">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="username">Username</label>
                    <input type="text" class="form-control" id="inputUsername" placeholder="Username" name="userName">
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

                    <button type="submit" name="create" class="col-12 btn btn-primary mt-3">Submit</button>
                </div>
                <!-- <div class="col-md-6 col-lg-5 col-xl-3 mb-3">
                    <img src="images/recaptcha-placeholder.png" style="width: 19rem;"></img>
                </div>                 -->
                <!-- <button type="submit" class="btn btn-primary">Submit</button> -->
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