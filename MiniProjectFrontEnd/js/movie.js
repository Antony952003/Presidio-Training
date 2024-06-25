document.addEventListener("DOMContentLoaded", () => {
  async function fetchMovieData() {
    try {
      const response = await fetch(
        "http://localhost:5091/api/Movie/GetAllMovies",
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );
      const data = await response.json();
      console.log(data);
    } catch (error) {
      console.error("Error fetching movie data:", error);
    }
  }

  fetchMovieData();

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
        document.querySelector(".main-container").style.opacity = "1.0";
      }
    }
  });

  var swiper = new Swiper(".swiper-container", {
    slidesPerView: 1,
    spaceBetween: 10,
    navigation: false,
    pagination: false,
    breakpoints: {
      640: {
        slidesPerView: 2,
        spaceBetween: 10,
      },
      768: {
        slidesPerView: 3,
        spaceBetween: 20,
      },
      1024: {
        slidesPerView: 4,
        spaceBetween: 30,
      },
    },
  });

  var swiper2 = new Swiper(".hashtag-container", {
    slidesPerView: 1,
    spaceBetween: 10,
    navigation: false,
    pagination: false,
    breakpoints: {
      640: {
        slidesPerView: 2,
        spaceBetween: 10,
      },
      768: {
        slidesPerView: 2,
        spaceBetween: 20,
      },
      1024: {
        slidesPerView: 2,
        spaceBetween: 30,
      },
    },
  });

  const leftBtn = document.querySelector(".left-btn-content");
  const rightBtn = document.querySelector(".right-btn-content");
  const reviewContainer = document.querySelector(".review-card-container");
  const slideWidth = 446; // Width of each slide

  let currentTranslateX = 0;

  rightBtn.addEventListener("click", function () {
    const maxTranslateX =
      reviewContainer.scrollWidth - reviewContainer.clientWidth;
    if (currentTranslateX < maxTranslateX) {
      currentTranslateX += slideWidth;
      reviewContainer.style.transform = `translateX(-${currentTranslateX}px)`;
    }
  });

  leftBtn.addEventListener("click", function () {
    if (currentTranslateX > 0) {
      currentTranslateX -= slideWidth;
      reviewContainer.style.transform = `translateX(-${currentTranslateX}px)`;
    }
  });

  var locationdown = document.querySelector(".down-button");
  locationdown.addEventListener("click", () => {
    var popuplocation = document.querySelector(".popup-location");
    if (popuplocation.classList.contains("active")) {
      document.querySelector(".main-container").style.opacity = "1.0";
      popuplocation.classList.remove("active");
    } else {
      document.querySelector(".main-container").style.opacity = "0.3";
      popuplocation.classList.add("active");
    }
  });

  const cityButtons = document.querySelectorAll(".pcities button");
  const locationSpan = document.querySelector(".location span");

  cityButtons.forEach((button) => {
    button.addEventListener("click", () => {
      var popuplocation = document.querySelector(".popup-location");
      document.querySelector(".main-container").style.opacity = "1.0";
      popuplocation.classList.remove("active");
      locationSpan.innerHTML = button.innerHTML;
    });
  });
});
