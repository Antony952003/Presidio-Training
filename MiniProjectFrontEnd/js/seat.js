const container = document.querySelector(".container");
const seats = document.querySelectorAll(".row .seat:not(.sold)");
const count = document.getElementById("count");
const total = document.getElementById("total");
const tickets = document.getElementById("tickets");
const movieSelect = document.getElementById("movie");

populateUI();

let ticketPrice = +movieSelect.value;

function setMovieData(movieIndex, moviePrice) {
  localStorage.setItem("selectedMovieIndex", movieIndex);
  localStorage.setItem("selectedMoviePrice", moviePrice);
}

function updateSelectedCount() {
  const selectedSeats = document.querySelectorAll(".row .seat.selected");

  const seatsIndex = [...selectedSeats].map((seat) => [...seats].indexOf(seat));

  var selectedseatnums = [];
  for(let i=0;i<selectedSeats.length;i++){
    if(i != 0){
      selectedseatnums += ",";
    }
    selectedseatnums += selectedSeats[i].classList[1];
  }
  
  localStorage.setItem("selectedSeats", JSON.stringify(seatsIndex));

  const selectedSeatsCount = selectedSeats.length;

  count.innerText = selectedSeatsCount;
  total.innerText = selectedSeatsCount * ticketPrice;
  tickets.innerHTML = selectedseatnums;

  setMovieData(movieSelect.selectedIndex, movieSelect.value);
}

// Get data from localstorage and populate UI
function populateUI() {
  const selectedSeats = JSON.parse(localStorage.getItem("selectedSeats"));

  if (selectedSeats !== null && selectedSeats.length > 0) {
    seats.forEach((seat, index) => {
      if (selectedSeats.indexOf(index) > -1) {
        seat.classList.add("selected");
      }
    });
  }

  const selectedMovieIndex = localStorage.getItem("selectedMovieIndex");

  if (selectedMovieIndex !== null) {
    movieSelect.selectedIndex = selectedMovieIndex;
  }
}

// Movie select event
movieSelect.addEventListener("change", (e) => {
  ticketPrice = +e.target.value;
  setMovieData(e.target.selectedIndex, e.target.value);
  updateSelectedCount();
});

// Seat click event
container.addEventListener("click", (e) => {
  if (
    e.target.classList.contains("seat") &&
    !e.target.classList.contains("sold")
  ) {
    e.target.classList.toggle("selected");

    updateSelectedCount();
  }
});

// Initial count and total set
updateSelectedCount();


document.addEventListener('DOMContentLoaded', () => {
  var startChar = 'A'.charCodeAt(0);
  var endChar = 'T'.charCodeAt(0);
  var colcount = 16;
  var container = document.querySelector('.container-seat');

  for(let i = startChar; i <= endChar; i++) {
      var newrow = document.createElement('div');
      newrow.classList.add('row');
      var rownum = document.createElement('p');
      rownum.classList.add('rownum');
      rownum.innerHTML = String.fromCharCode(i);
      newrow.appendChild(rownum);
      for(let j = 1; j <= colcount; j++) {
          var newcol = document.createElement('div');
          newcol.classList.add('seat');
          newcol.classList.add(`${String.fromCharCode(i)}${j}`);
          newcol.innerHTML = `${j}`;
          newrow.appendChild(newcol);
      }
      container.appendChild(newrow);
  }
});
