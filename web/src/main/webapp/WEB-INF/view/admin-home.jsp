<!DOCTYPE html>
<%@ taglib prefix="spring" uri="http://www.springframework.org/tags"%>
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
            <a href="admin-home" class="navbar-brand">B1 Cinemas - Admin Portal</a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="admin-home" class="nav-item nav-link active">Home</a>
                    <a href="admin-manage-promotions" class="nav-item nav-link">Manage Promotions</a>
                    <a href="admin-manage-movies" class="nav-item nav-link">Manage Movies</a>
                    <a href="admin-manage-users" class="nav-item nav-link">Manage Users</a>
                </div>
                <div class="navbar-nav ms-auto">
                    <!-- Login Dropdown -->
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown"
                            aria-expanded="false">
                            Welcome, Username
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                            <li><a class="dropdown-item" href="editprofile">Edit Profile</a></li>
                            <li><a class="dropdown-item" href="#">Logout</a></li>
                        </ul>
                    </div>
                    <!-- Login Dropdown -->
                </div>
            </div>
        </div>
    </nav>
    <!-- Navbar -->

    <h1 class="text-center mt-4 mb-5" style="font-weight: 700;">Admin Home</h1>

    <!-- Customer Stats --> 
    <div class="container">
        <h3 class="text-start">Customer Count</h3>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Adults</th>
                    <th scope="col">Children</th>
                    <th scope="col">Seniors</th>
                    <th scope="col">Total</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>15</td>
                    <td>4</td>
                    <td>7</td>
                    <td>26</td>
                </tr>                
            </tbody>
        </table>
    </div>
    <!-- Customer Stats -->
    <br>
    <!-- Ticket Stats -->
    <div class="container">
        <h3 class="text-start">Ticket Sales</h3>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Adults</th>
                    <th scope="col">Children</th>
                    <th scope="col">Seniors</th>
                    <th scope="col">Total</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>8</td>
                    <td>3</td>
                    <td>4</td>
                    <td>15</td>
                </tr>
            </tbody>
        </table>
    </div>
    <!-- Ticket Stats -->
    <br>
    <!-- Movie Stats -->
    <!-- Maybe add column that tracks ticket count for each movie? -->
    <div class="container">
        <h3 class="text-start">Movies Currently Showing</h3>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Titles</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Uncharted</td>
                </tr>
                <tr>
                    <td>Nightmare Alley</td>
                </tr>
                <tr>
                    <td>The Kingsman</td>
                </tr>
                <tr>
                    <td>Dune</td>
                </tr>
            </tbody>
        </table>
    </div>
    <!-- Movie Stats -->

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
                            B1-cinemas@movie.com
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