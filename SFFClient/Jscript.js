function updateMovieList() {
  getMovieDataAsync("http://localhost:5000/api/Movie").then((data) =>
    buildMovieList(data)
  );
}

async function getMovieDataAsync(url) {
  let response = await fetch(url);
  let data = await response.json();
  return data;
}

function buildMovieList(data) {
  document.getElementById("movieContainer").innerHTML = "";
  data.forEach((element) => {
    var newDiv = document.createElement("div");
    newDiv.className = "addedDiv";
    newDiv.textContent =
      "ID: " +
      element.id +
      " | Title: " +
      element.title +
      "   |   Genre:   " +
      element.genre;
    //console.log(element.Title);
    var containerDiv = document.getElementById("movieContainer");
    containerDiv.appendChild(newDiv);
  });
}

fetch("http://localhost:5000/api/Movie")
  .then((response) => response.json())
  .then((data) => buildMovieList(data));

////////////////////////////////////////////////////////////////////

function updateStudioList() {
  getStudioDataAsync("http://localhost:5000/api/Studio").then((data) =>
    buildList(data)
  );
}

async function getStudioDataAsync(url) {
  let response = await fetch(url);
  let data = await response.json();
  return data;
}

function buildStudioList(data) {
  document.getElementById("studioContainer").innerHTML = "";
  data.forEach((element) => {
    var newDiv = document.createElement("div");
    newDiv.className = "addedDivStudio";
    newDiv.textContent =
      "ID: " +
      element.id +
      " | Studio: " +
      element.name +
      "   |   City:   " +
      element.city;
    var containerDiv = document.getElementById("studioContainer");
    containerDiv.appendChild(newDiv);
  });
}

fetch("http://localhost:5000/api/Studio")
  .then((response) => response.json())
  .then((data) => buildStudioList(data));

///////////////////////////////////////////////////////////////////

function updateRentalsList() {
  getRentalsDataAsync("http://localhost:5000/api/Rentedmovie").then((data) =>
    buildList(data)
  );
}

async function getRentalsDataAsync(url) {
  let response = await fetch(url);
  let data = await response.json();
  return data;
}

function buildRentalsList(data) {
  document.getElementById("rentalsContainer").innerHTML = "";
  data.forEach((element) => {
    var newDiv = document.createElement("div");
    newDiv.className = "addedDivStudio";
    newDiv.textContent =
      "Studio: " +
      element.studio.name +
      "   |   Movie:   " +
      element.movie.title;
    var containerDiv = document.getElementById("rentalsContainer");
    containerDiv.appendChild(newDiv);
  });
}

fetch("http://localhost:5000/api/Rentedmovie")
  .then((response) => response.json())
  .then((data) => buildRentalsList(data));

///////////////////////////////////////////////////////////////////

function createNewMovie() {
  var newTitle = document.getElementById("movieTitleText").value;
  var newGenre = document.getElementById("movieGenreText").value;
  var newMaxAmount = 3;
  var jsonObject = {
    Title: newTitle,
    Genre: newGenre,
    maxRentAmount: newMaxAmount,
  };

  const data = JSON.stringify(jsonObject);
  postNewMovie(data);
}
async function postNewMovie(data) {
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      alert(this.responseText);
    }
  };
  xhttp.open("POST", "http://localhost:5000/api/Movie", true);
  xhttp.setRequestHeader("Content-Type", "application/json");
  xhttp.send(data);
}

///////////////////////////////////////////////////////////////////////

function createNewStudio() {
  var newName = document.getElementById("studioNameText").value;
  var newCity = document.getElementById("cityNameText").value;

  var jsonObject = {
    Name: newName,
    City: newCity,
  };

  const data = JSON.stringify(jsonObject);
  postNewStudio(data);
}

async function postNewStudio(data) {
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      alert(this.responseText);
    }
  };
  xhttp.open("POST", "http://localhost:5000/api/Studio", true);
  xhttp.setRequestHeader("Content-Type", "application/json");
  xhttp.send(data);
}

//////////////////////////////////////////////////////////////////////

function createNewRental() {
  var newRentingStudio = parseInt(
    document.getElementById("rentingStudioText").value
  );
  var newRentedMovie = parseInt(
    document.getElementById("rentedMovieText").value
  );

  var jsonObject = {
    MovieId: newRentedMovie,
    StudioId: newRentingStudio,
  };

  const data = JSON.stringify(jsonObject);
  postNewRental(data);
}

function postNewRental(data) {
  var xhttp = new XMLHttpRequest();
  xhttp.onreadystatechange = function () {
    if (this.readyState == 4 && this.status == 200) {
      alert(this.responseText);
    }
  };
  xhttp.open("POST", "http://localhost:5000/api/Rentedmovie", true);
  xhttp.setRequestHeader("Content-Type", "application/json");
  xhttp.send(data);
}
