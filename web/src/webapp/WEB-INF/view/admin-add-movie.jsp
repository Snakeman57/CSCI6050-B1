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

    <div class="container border p-3 mt-4 form-horizontal">
        <div class="row">
            <h2 class="text-start">Add a Movie</h2>
            <h5 class="text-muted text-start">Please complete the form below to add a movie.</h5>
            <br><br>
            <form>
                <div class="input-group-md mb-3">
                    <label class="form-label" for="inputTitle"><strong>Title</strong></label>
                    <input type="text" class="form-control" id="inputTitle" placeholder="Movie Title">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3">
                    <label class="form-label" for="inputDuration"><strong>Duration</strong></label>
                    <input type="text" class="form-control" id="inputDuration" placeholder="Duration">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 input-group-md mb-3">
                    <label class="form-label" for="inputCategory"><strong>Category</strong></label>
                    <input type="text" class="form-control" id="inputCategory" placeholder="Category/Genre">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputCast"><strong>Cast</strong></label>
                    <textarea class="form-control" id="inputCast" rows="4"></textarea>
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputDirector"><strong>Director</strong></label>
                    <input type="text" class="form-control" id="inputDirector" placeholder="Director">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputProducer"><strong>Producer</strong></label>
                    <input type="text" class="form-control" id="inputProducer" placeholder="Producer">
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputSynopsis"><strong>Synopsis</strong></label>
                    <textarea class="form-control" id="inputSynopsis" rows="3"></textarea>
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputReviews"><strong>Reviews</strong></label>
                    <textarea class="form-control" id="inputReviews" rows="3"></textarea>
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputTrailerURL"><strong>Link to Trailer</strong></label>
                    <input type="text" class="form-control" id="inputTrailerURL" placeholder="Trailer URL">
                </div>
                <!-- See CES Demo for idea on uploading images -->
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <label class="form-label" for="inputImage"><strong>Image</strong></label>
                    <input type="text" class="form-control" id="inputImage">
                </div>
                <select class="form-select" aria-label="Default select example">
                    <option selected>Rating</option>
                    <option value="1">G</option>
                    <option value="2">PG</option>
                    <option value="3">PG-13</option>
                    <option value="4">R</option>
                </select>
                <br>
                <h6><strong>Now Showing:</strong></h6>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="inTheaters">
                    <label class="form-check-label" for="inTheaters">
                        Yes (In Theaters)
                    </label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="comingSoon">
                    <label class="form-check-label" for="comingSoon">
                        No (Coming Soon)
                    </label>
                </div>
                <div class="col-md-6 col-lg-5 col-xl-5 mb-3">
                    <button type="submit" class="col-12 btn btn-primary mt-3">Add Movie</button>
                </div>
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