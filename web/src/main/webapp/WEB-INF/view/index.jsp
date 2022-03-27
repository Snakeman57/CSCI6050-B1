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
    <link href="style.css" rel="stylesheet"/>
    <!-- Bootstrap Icons -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css">
    <title>B1 Cinemas</title>
</head>

<body>
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
                    <a class="btn btn-outline-success mx-2" data-bs-toggle="collapse" href="#collapseSearch" role="button"
                        aria-expanded="false" aria-controls="collapseSearch">
                        Search
                    </a>
                </div>
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
    </nav>
    <div class="collapse" id="collapseSearch">
        <div class="card card-body">
            <form class="d-flex">
                <input class="form-control me-2" type="search" placeholder="Search Movies" aria-label="Search">
                <button class="btn btn-outline-success" type="submit">Search</button>
            </form>
        </div>
    </div>
    <!-- Navbar -->

    <!-- Movie Trailer Carousel  -->
    <div class="container-fluid">
        <div id="carouselExampleControls" class="carousel slide text-center carousel-btn" data-bs-ride="carousel">
            <!-- Indicators -->
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active"
                    aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1"
                    aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2"
                    aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner mt-2 mb-2">
                <div class="carousel-item active ratio ratio-21x9">
                    <iframe src="https://www.youtube.com/embed/dZOaI_Fn5o4" title="YouTube video player"
                        frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                        allowfullscreen>
                    </iframe>
                </div>
                <div class="carousel-item ratio ratio-21x9">
                    <iframe src="https://www.youtube.com/embed/JfVOs4VSpmA" title="YouTube video player"
                        frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                        allowfullscreen>
                    </iframe>
                </div>
                <div class="carousel-item ratio ratio-21x9">
                    <iframe src="https://www.youtube.com/embed/CaimKeDcudo" title="YouTube video player"
                        frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
                        allowfullscreen>
                    </iframe>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
            <button class="btn2">Buy Tickets Now!</button>
        </div>         
        <!-- Movie Trailer Carousel -->
    </div>

    <!-- Currently Showing -->
    <nav class="px-2 pt-3 pb-1 bg-dark" aria-label="Coming soon movies">
        <ul class="pagination pagination-lg justify-content-center">
            <li class="page-item active"><a class="page-link" href="index.html">Currently Showing</a></li>
            <li class="page-item"><a class="page-link" href="coming-soon.html">Coming Soon</a></li>
        </ul>
    </nav>
    <div class="container mt-2">
        <div class="row g-3 justify-content-center">
            <div class="card col-md-6 col-lg-4 col-xl-3 px-0 mx-2 movie_card">
                <img src="../../images/uncharted.jpg" class="card-img-top" alt="...">
                <div class="card-body text-center">
                    <h5 class="card-title">Uncharted</h5>
                    <a href="#" class="btn btn-primary">Buy Ticket</a>
                </div>
            </div>
            <div class="card col-md-6 col-lg-4 col-xl-3 px-0 mx-2 movie_card">
                <img src="../../images/nightmare-alley.jpg" class="card-img-top" alt="...">
                <div class="card-body text-center">
                    <h5 class="card-title">Nightmare Alley</h5>
                    <a href="#" class="btn btn-primary">Buy Ticket</a>
                </div>
            </div>
            <div class="card col-md-6 col-lg-4 col-xl-3 px-0 mx-2 movie_card">
                <img src="../../images/kingsman.jpeg" class="card-img-top" alt="...">
                <div class="card-body text-center">
                    <h5 class="card-title">The Kingsman</h5>
                    <a href="#" class="btn btn-primary">Buy Ticket</a>
                </div>
            </div>
            <div class="card col-md-6 col-lg-4 col-xl-3 px-0 mx-2 movie_card">
                <img src="../../images/dune.jpeg" class="card-img-top" alt="...">
                <div class="card-body text-center">
                    <h5 class="card-title">Dune</h5>
                    <a href="#" class="btn btn-primary">Buy Ticket</a>
                </div>
            </div>
        </div>
        <div class="container mt-5 text-center">
            <div class="row">
                <div class="col-12">
                    <button type="button" class="btn btn-success btn-lg">Book Movie</button>
                </div>
            </div>
        </div>
    </div>
    <!-- Currently Showing -->
    
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
    <!-- Custom JS -->
    <script src="index.js"></script>
</body>

</html>