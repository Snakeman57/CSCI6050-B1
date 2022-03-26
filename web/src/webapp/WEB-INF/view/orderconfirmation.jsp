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

    <div class="checkout-title">
        <h1 style="font-size: 65px; margin-top: 1.5vw;">Order Confirmation</h1>
    </div>

    <div class="container">
        <br>
         <div style="float: left;">
             <h4 class="text-start">Your Tickets</h4>
         </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Attendee</th>
                    <th scope="col">Price</th>
                    <th scope="col">Seat</th>
                    <th scope="col">Movie</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1 Adult</td>
                    <td>$12.49</td>
                    <td>C1</td>
                    <td>The Kingsman</td>
                </tr>
                <tr>
                    <td>1 Child</td>
                    <td>$8.87</td>
                    <td>C2</td>
                    <td>The Kingsman</td>
                </tr>
            </tbody>
        </table>
        <h5>Order Total: <b>$21.36</b></h5>
        <h5>Where: Beechwood Cinemas, Athens, GA</h5>
        <a href="index.html"><button style="margin-bottom: 60px; margin-top: 20px;" class="btn bg-success text-white">Done</button></a>
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

    </body>
</html>