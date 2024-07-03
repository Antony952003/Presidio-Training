document.addEventListener("DOMContentLoaded", () => {
  document.querySelector(".logo").addEventListener("click", () => {
    window.location.href = "index.html";
  });

  const fetchuserdetails = () => {
    fetch(
      `http://localhost:5091/api/User/GetUserById?userid=${localStorage.getItem(
        "uid"
      )}`,
      {
        method: "GET",
        headers: {
          "Content-Type": "application/json",
        },
      }
    )
      .then((response) => response.json())
      .then((data) => {
        console.log(data);
        document.querySelectorAll(".name-field").forEach((e) => {
          e.innerHTML = data.name;
        });
        var imageeles = document.querySelectorAll(".user-profile-image");
        imageeles.forEach((imageele) => {
          imageele.src = data.image;
          imageele.onerror = function () {
            imageele.src = "../Assets/Images/user_image.png";
          };
        });
      });
  };
  fetchuserdetails();

  document.querySelector(".user").addEventListener("click", () => {
    if (!document.querySelector(".user").classList.contains("active")) {
      document.querySelector(".user").classList.add("active");
      document.querySelector(".account-details-nav").classList.add("active");
      if (document.querySelector("#nav-menu").classList.contains("active")) {
        document.querySelector("#nav-menu").classList.remove("active");
        document.querySelector("#hamburger-menu").classList.remove("active");
      }
    } else {
      document.querySelector(".user").classList.remove("active");
      document.querySelector(".account-details-nav").classList.remove("active");
    }
  });

  document
    .querySelector(".ad-nav-header-comp-2")
    .addEventListener("click", () => {
      if (!document.querySelector(".user").classList.contains("active")) {
        document.querySelector(".user").classList.add("active");
        document.querySelector(".account-details-nav").classList.add("active");
        if (document.querySelector("#nav-menu").classList.contains("active")) {
          document.querySelector("#nav-menu").classList.remove("active");
          document.querySelector("#hamburger-menu").classList.remove("active");
        }
      } else {
        document.querySelector(".user").classList.remove("active");
        document
          .querySelector(".account-details-nav")
          .classList.remove("active");
      }
    });

  if (localStorage.getItem("token")) {
    document.getElementById("logged-in").innerHTML = "Log Out";
  }

  document.getElementById("logged-in").addEventListener("click", () => {
    if (document.getElementById("logged-in").innerHTML == "Log Out") {
      document.getElementById("logged-in").innerHTML = "Sign In";
      window.localStorage.removeItem("token");
    }
  });

  document.querySelector(".hamburger-menu").addEventListener("click", () => {
    if (
      !document.querySelector(".hamburger-menu").classList.contains("active")
    ) {
      document.querySelector(".hamburger-menu").classList.add("active");
      document.querySelector(".nav-menu").classList.add("active");
    } else {
      document.querySelector(".hamburger-menu").classList.remove("active");
      document.querySelector(".nav-menu").classList.remove("active");
      if (
        document.querySelector(".popup-location").classList.contains("active")
      ) {
        document.querySelector(".popup-location").classList.remove("active");
        document.querySelector(".showtimecontainer").style.opacity = "1.0";
      }
    }
  });

  var locationdown = document.querySelector(".down-button");
  locationdown.addEventListener("click", () => {
    var popuplocation = document.querySelector(".popup-location");
    if (popuplocation.classList.contains("active")) {
      document.querySelector(".showtimecontainer").style.opacity = "1.0";
      popuplocation.classList.remove("active");
    } else {
      document.querySelector(".showtimecontainer").style.opacity = "0.3";
      popuplocation.classList.add("active");
    }
  });

  const cityButtons = document.querySelectorAll(".pcities button");
  const locationSpan = document.querySelector(".location span");

  cityButtons.forEach((button) => {
    button.addEventListener("click", () => {
      var popuplocation = document.querySelector(".popup-location");
      document.querySelector(".showtimecontainer").style.opacity = "1.0";
      popuplocation.classList.remove("active");
      locationSpan.innerHTML = button.innerHTML;
    });
  });

  const movieTitle = new URLSearchParams(window.location.search).get("title");
  document.getElementById("movie-title").innerText = movieTitle;

  const daysOfWeek = 7;
  const today = new Date();
  const dayButtonsContainer = document.getElementById("day-buttons");

  const fetchShowtimes = () => {
    const activeDayButton = document.querySelector(".day-button.active");
    const selectedDate = activeDayButton ? activeDayButton.dataset.date : null;
    const formatFilter = document.getElementById("format-filter").value;
    const timeFilter = document.getElementById("time-filter").value;

    console.log(
      `Fetching showtimes for date: ${selectedDate}, format: ${formatFilter}, time: ${timeFilter}`
    );

    // Placeholder for actual data fetch
    const theaters = [
      {
        name: "Theater 1",
        showtimes: [
          { time: "10:00 AM", format: "2D" },
          { time: "1:00 PM", format: "3D" },
          { time: "4:00 PM", format: "IMAX" },
        ],
      },
      {
        name: "Theater 2",
        showtimes: [
          { time: "11:00 AM", format: "2D" },
          { time: "2:00 PM", format: "3D" },
          { time: "5:00 PM", format: "IMAX" },
        ],
      },
    ];

    const filteredTheaters = theaters
      .map((theater) => {
        return {
          ...theater,
          showtimes: theater.showtimes.filter((showtime) => {
            const showtimeFormatMatches =
              !formatFilter || showtime.format === formatFilter;
            const showtimeTimeMatches =
              !timeFilter ||
              (timeFilter === "morning" &&
                showtime.time >= "08:00 AM" &&
                showtime.time < "12:00 PM") ||
              (timeFilter === "afternoon" &&
                showtime.time >= "12:00 PM" &&
                showtime.time < "04:00 PM") ||
              (timeFilter === "evening" &&
                showtime.time >= "04:00 PM" &&
                showtime.time < "08:00 PM") ||
              (timeFilter === "night" &&
                showtime.time >= "08:00 PM" &&
                showtime.time <= "12:00 AM");

            return showtimeFormatMatches && showtimeTimeMatches;
          }),
        };
      })
      .filter((theater) => theater.showtimes.length > 0);

    const theaterListContainer = document.getElementById("theater-list");
    theaterListContainer.innerHTML = filteredTheaters
      .map(
        (theater) => `
    <div class="theater">
      <h2>${theater.name}</h2>
      <div class="showtimes">
        ${theater.showtimes
          .map(
            (showtime) => `
          <div class="showtime">${showtime.time} (${showtime.format})</div>
        `
          )
          .join("")}
      </div>
    </div>
  `
      )
      .join("");
  };

  for (let i = 0; i < daysOfWeek; i++) {
    const date = new Date(today);
    date.setDate(today.getDate() + i);

    const dayButton = document.createElement("button");
    dayButton.classList.add("day-button");
    dayButton.innerText =
      date.toDateString().slice(0, 3) + " " + date.getDate();
    dayButton.dataset.date = date.toISOString().split("T")[0];

    if (i === 0) {
      dayButton.classList.add("active");
    }

    dayButton.addEventListener("click", () => {
      document
        .querySelectorAll(".day-button")
        .forEach((button) => button.classList.remove("active"));
      dayButton.classList.add("active");
      fetchShowtimes();
    });

    dayButtonsContainer.appendChild(dayButton);
  }

  document
    .getElementById("format-filter")
    .addEventListener("change", fetchShowtimes);
  document
    .getElementById("time-filter")
    .addEventListener("change", fetchShowtimes);

  fetchShowtimes();
});
