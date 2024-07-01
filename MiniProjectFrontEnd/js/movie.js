document.addEventListener("DOMContentLoaded", () => {
  async function fetchMovieData() {
    try {
      const response = await fetch(
        `http://localhost:5091/api/Movie/GetMovieByName?name=Garudan`,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );
      const data = await response.json();
      console.log(data); // Ensure data is correctly received in console

      // Update DOM with fetched data
      // const mainContainer = document.querySelector(".main-container");
      // mainContainer.innerHTML = `
      //   <section class="hero-container">
      //     <div class="hero-subcontainer">
      //       <div class="hero-elements">
      //         <div class="hero-image">
      //           <img
      //             src="${data.bannerImage}"
      //             alt="${data.title}"
      //             width="100%"
      //             height="100%"
      //           />
      //           <div class="incinemas">In Cinemas</div>
      //         </div>
      //         <div class="hero-details">
      //           <h1>${data.title}</h1>
      //           <div class="hero-rating">
      //             <div class="hero-rating-left">
      //               <span class="star">
      //                 <i class="bx bxs-star"></i>
      //               </span>
      //               <span class="imdb-rating">${data.averageRating}/10</span>
      //               <span class="votes"> (25.1k votes)</span>
      //             </div>
      //             <button>Rate Now</button>
      //           </div>
      //           <div class="hero-format-details">
      //             <div class="movie-formats">
      //               <a href="">2D</a>, <a href="">2D SCREEN X</a>,
      //               <a href="">mx4d</a>, <a href="">4dx</a>,
      //               <a href="">Imax 2d</a>,
      //               <a href="">ice</a>
      //             </div>
      //             <div class="movie-languages">
      //               <a href="">Tamil</a>, <a href="">English</a>,
      //               <a href="">Telugu</a>, <a href="">Malayalam</a>,
      //               <a href="">Kannada</a>,
      //               <a href="">Hindi</a>
      //             </div>
      //           </div>
      //           <div class="movie-details">
      //             <ul>
      //               <li>${data.genre}</li>
      //               <li>${data.certification}</li>
      //               <li>${data.releaseDate}</li>
      //               <li>${data.durationInHours} hours</li>
      //               <li>${data.director}</li>
      //             </ul>
      //           </div>
      //           <div class="booknow">
      //             <a href="" class="btn btn-hover">
      //               <span>Book Now</span>
      //             </a>
      //           </div>
      //         </div>
      //       </div>
      //     </div>
      //   </section>
      //   <section class="synopsis-container">
      //     <div class="synopsis">
      //       <div class="component-1">
      //         <h2 class="about-1">About the movie</h2>
      //         <p class="about-2">${data.description}</p>
      //       </div>
      //       <!-- Cast -->
      //       <div class="component-2">
      //         <h2>Cast</h2>
      //         <div class="cast-container swiper-container">
      //           <div class="swiper-wrapper">
      //             ${data.castMemberRoles
      //               .map(
      //                 (castMember) => `
      //               <div class="cast-card swiper-slide">
      //                 <img
      //                   alt="${castMember.name}"
      //                   src="${castMember.imageUrl}"
      //                 />
      //                 <div class="cast-info">
      //                   <p>${castMember.name}</p>
      //                   <span>as ${castMember.role}</span>
      //                 </div>
      //               </div>
      //             `
      //               )
      //               .join("")}
      //           </div>
      //         </div>
      //       </div>
      //       <!-- End Cast Container -->
      //       <!-- Reviews -->
      //       <div class="component-3">
      //         <!-- Your review section implementation -->
      //       </div>
      //       <!-- End Of Reviews -->
      //     </div>
      //   </section>
      // `;
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
