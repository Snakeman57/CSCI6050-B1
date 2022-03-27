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

    <div class="movie-title" id="movieTitle">
        <h1 style="font-size: 75px;">The Kingsman</h1>
        <h6>Now Playing</h6>
        <div id="selectDate">
            <form action="/action_page.php">
                <label for="cars">Select a Date:</label>
                <select name="cars" id="cars">
                <option value="blank"> </option>
                <option value="first">January 1st, 2100</option>
                <option value="second">January 2nd, 2100</option>
                <option value="third">January 3rd, 2100</option>
                <option value="fourth">January 4th, 2100</option>
                </select>
            </form>
        </div>
    </div>

    <div class="movie-times" id="movieTimes">
        <div id="theater-name">
            <h3>Beechwood Cinemas</h3>
        </div>
        <div id="showTimes">
            <button type="button" class="btn btn-primary">4:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">7:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">8:00pm</button>
        </div>
    </div>
    <div class="divider2"></div>
    <div class="movie-times" id="movieTimes">
        <div id="theater-name">
            <h3>University 16 Cinemas</h3>
        </div>
        <div id="showTimes">
            <button type="button" class="btn btn-primary">5:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">7:00pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">9:00pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">10:00pm</button>
        </div>
    </div>
    <div class="divider2"></div>
    <div class="movie-times" id="movieTimes">
        <div id="theater-name">
            <h3>Commerce Cinemas</h3>
        </div>
        <div id="showTimes">
            <button type="button" class="btn btn-primary">4:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">6:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">8:00pm</button>
        </div>
    </div>
    <div class="divider2"></div>
    <div class="movie-times" id="movieTimes">
        <div id="theater-name">
            <h3>AMC Classic Cinemas</h3>
        </div>
        <div id="showTimes">
            <button type="button" class="btn btn-primary">6:00pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">7:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">8:00pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">8:30pm</button>
            <div class="divider"></div>
            <button type="button" class="btn btn-primary">11:00pm</button>
        </div>
    </div>
</body>

<div id="moviePoster">
    <img src="../../images/kingsman.jpeg" alt="Kingsman" >
</div>


</html>