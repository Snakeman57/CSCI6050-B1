<!DOCTYPE html>
<%@ taglib prefix="spring" url="https://www.springframework.org/tags"%>
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
            <a href="admin-home.html" class="navbar-brand">B1 Cinemas - Admin Portal</a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="admin-home.html" class="nav-item nav-link">Home</a>
                    <a href="admin-manage-promotions.html" class="nav-item nav-link">Manage Promotions</a>
                    <a href="admin-manage-movies.html" class="nav-item nav-link active">Manage Movies</a>
                    <a href="admin-manage-users.html" class="nav-item nav-link">Manage Users</a>
                </div>
                <div class="navbar-nav ms-auto">
                    <!-- Login Dropdown -->
                    <div class="dropdown">
                        <button class="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButton1"
                            data-bs-toggle="dropdown" aria-expanded="false">
                            Welcome, Username
                        </button>
                        <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                            <li><a class="dropdown-item" href="editprofile.html">Edit Profile</a></li>
                            <li><a class="dropdown-item" href="#">Logout</a></li>
                        </ul>
                    </div>
                    <!-- Login Dropdown -->
                </div>
            </div>
        </div>
    </nav>
    <!-- Navbar -->

    <h1 class="text-center mt-4" style="font-weight: 700;">Manage Movies</h1>
    <h3 class="text-center"><small class="text-muted text-center">Add, Delete, or Edit a Movie.</small></h3>

    <!-- All Movies -->
    <div class="container">
        <br>
        <h2 class="text-start">All Movies</h2>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Movie Title</th>
                    <th scope="col">Status</th>
                    <th scop="col">Action</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Uncharted</td>
                    <td>In Theaters</td>
                    <td>
                        <button class="btn bg-primary text-white">Edit</button>
                        <button class="btn bg-primary text-white">Remove</button>
                        <a href="admin-sched-movie.html"><button class="btn bg-primary text-white">Schedule</button></a>
                    </td>
                </tr>
                <tr>
                    <td>John Wick 4</td>
                    <td>Coming Soon</td>
                    <td>
                        <button class="btn bg-primary text-white">Edit</button>
                        <button class="btn bg-primary text-white">Remove</button>
                        <a href="admin-sched-movie.html"><button class="btn bg-primary text-white">Schedule</button></a>
                    </td>
                </tr>
                <tr>
                    <td>Nightmare Alley</td>
                    <td>In Theaters</td>
                    <td>
                        <button class="btn bg-primary text-white">Edit</button>
                        <a href="admin-sched-movie.html"><button class="btn bg-primary text-white">Remove</button></a>
                        <button class="btn bg-primary text-white">Schedule</button>
                    </td>
                </tr>
            </tbody>
        </table>
        <a href="admin-add-movie.html"><button class="btn bg-success text-white">Add Movie</button></a>
    </div>
    <!-- All Movies -->

    <br> <br>

    <!-- Current Movie Schedule -->    
    <div class="container">
        <h2>Current Movie Schedule</h2>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Movie Title</th>
                    <th scope="col">Schedule Time</th>
                    <th scop="col">Room</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Uncharted</td>
                    <td>February 20, 2022, 12:00pm</td>
                    <td>3</td>
                    <td>
                        <button class="btn bg-primary text-white">Remove</button>
                    </td>
                </tr>
                <tr>
                    <td>John Wick 4</td>
                    <td>February 20, 2022, 12:30pm</td>
                    <td>1</td>
                    <td>
                        <button class="btn bg-primary text-white">Remove</button>
                    </td>
                </tr>
                <tr>
                    <td>Nightmare Alley</td>
                    <td>February 21, 2022, 6:30pm</td>
                    <td>2</td>
                    <td>
                        <button class="btn bg-primary text-white">Remove</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!-- Current Movie Schedule -->

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