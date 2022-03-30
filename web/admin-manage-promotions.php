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
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet"
        integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous" />
    <!-- Custom CSS -->
    <link href="style.css" rel="stylesheet" />
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
    <title>B1 Cinemas</title>
</head>

<body>
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a href="admin-home.php" class="navbar-brand">B1 Cinemas - Admin Portal</a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="admin-home.php" class="nav-item nav-link">Home</a>
                    <a href="admin-manage-promotions.php" class="nav-item nav-link active">Manage Promotions</a>
                    <a href="admin-manage-movies.php" class="nav-item nav-link">Manage Movies</a>
                    <a href="admin-manage-users.php" class="nav-item nav-link">Manage Users</a>
                </div>
            <div class="navbar-nav ms-auto">
                <!-- Login Dropdown -->
                <div class="dropdown">
                    <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1"
                        data-bs-toggle="dropdown" aria-expanded="false">
                        Welcome, Username
                    </button>
                    <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li><a class="dropdown-item" href="editprofile.php">Edit Profile</a></li>
                        <li><a class="dropdown-item" href="#">Logout</a></li>
                    </ul>
                </div>
                <!-- Login Dropdown -->
            </div>
            </div>
        </div>
    </nav>
    <!-- Navbar -->

    <!-- Current Promotions -->
    <h1 class="text-center mt-4 mb-5" style="font-weight: 700;">Manage Promotions</h1>
    <div class="container">
        <br>
        <h4 class="text-start">Current Promotions</h4>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Deal</th>
                    <th scope="col">Code</th>
                    <th scope="col"></th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>15% Off Uncharted</td>
                    <td>15OFF!</td>
                    <td>
                        <button class="btn bg-primary text-white">Remove</button>
                    </td>
                </tr>
                <tr>
                    <td>50% Off John Wick 4</td>
                    <td>50OFFWOW!</td>
                    <td>
                        <button class="btn bg-primary text-white">Remove</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <a href="admin-add-promotion.php"><button class="btn bg-success text-white">Add Promotion</button></a>
    </div>
    <!-- Current Promotions -->


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
    <!-- Custom JS -->
    <script src="index.js"></script>
</body>

</html>