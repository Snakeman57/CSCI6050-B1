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
    <!-- Navbar component -->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
        <div class="container">
            <a href="/" class="navbar-brand">Cinemaster</a>
            <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target="#navbarCollapse">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarCollapse">
                <div class="navbar-nav">
                    <a href="/" class="nav-item nav-link active">Home</a>
                    <a href="#" class="nav-item nav-link">Showtimes</a>
                    <a href="#" class="nav-item nav-link">Promotions</a>
                    <a href="#" class="nav-item nav-link">Contact</a>
                </div>
                <!-- Searh Bar -->
                <div class="navbar-nav ms-auto">
                    <a href="register" class="nav-item nav-link">Register</a>
                    <a href="login" class="nav-item nav-link">Login</a>
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
            <h2 class="text-center">Create an Account!</h2>
            <h5 class="text-muted text-center">Please complete the form below.</h5>
            <h6 id="required-fields">*All fields are required</h6>
            <br>
            <br>
            <form>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="firstName">First Name</label>
                    <input type="text" class="form-control" id="inputFirstName" placeholder="First Name">                    
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="lastName">Last Name</label>
                    <input type="text" class="form-control" id="inputLastName" placeholder="Last Name">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3 mx-auto">
                    <label class="form-label" for="username">Username</label>
                    <input type="text" class="form-control" id="inputUsername" placeholder="Username">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
                    <label class="form-label" for="inputEmail">Email</label>
                    <input type="email" class="form-control" id="inputEmail" placeholder="Email">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
                    <label class="form-label" for="inputPassword">Password</label>
                    <input name="password" type="password" class="form-control" id="inputPassword" placeholder="Password">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3 mx-auto">
                    <label class="form-label" for="confirmPassword">Confirm Password</label>
                    <input name="password" type="password" class="form-control" id="inputPassword" placeholder="Confirm Password">

                    <button type="submit" class="col-12 btn btn-primary mt-3">Submit</button>
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
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"
        crossorigin="anonymous"></script>
    <script src="index.js"></script>
</body>

</html>