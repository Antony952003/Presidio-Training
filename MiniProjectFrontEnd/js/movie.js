document.addEventListener("DOMContentLoaded", () => {
  document.querySelector(".logo").addEventListener("click", () => {
    window.location.href = "index.html";
  });
  async function fetchMovieData() {
    try {
      const params = new URLSearchParams(window.location.search);
      const movieTitle = params.get("title");
      const response = await fetch(
        `http://localhost:5091/api/Movie/GetMovieByName?name=${movieTitle}`,
        {
          method: "GET",
          headers: { "Content-Type": "application/json" },
        }
      );
      const data = await response.json();
      console.log(data);

      // Update DOM with fetched data
      const mainContainer = document.querySelector(".main-container");
      function convertHoursToHoursMinutes(durationInHours) {
        // Extract whole hours and minutes
        const hours = Math.floor(durationInHours);
        const minutes = Math.round((durationInHours - hours) * 60);

        // Format the result
        const formattedDuration = `${hours}hr ${minutes}mins`;

        return formattedDuration;
      }
      function formatDate(dateString) {
        const date = new Date(dateString);

        // Define month names
        const monthNames = [
          "January",
          "February",
          "March",
          "April",
          "May",
          "June",
          "July",
          "August",
          "September",
          "October",
          "November",
          "December",
        ];

        // Get day with ordinal suffix
        const day = date.getDate();
        let dayWithSuffix;
        if (day === 1 || day === 21 || day === 31) {
          dayWithSuffix = day + "st";
        } else if (day === 2 || day === 22) {
          dayWithSuffix = day + "nd";
        } else if (day === 3 || day === 23) {
          dayWithSuffix = day + "rd";
        } else {
          dayWithSuffix = day + "th";
        }

        // Get month and year
        const month = monthNames[date.getMonth()];
        const year = date.getFullYear();

        // Construct formatted date string
        const formattedDate = `${dayWithSuffix} ${month} ${year}`;

        return formattedDate;
      }

      mainContainer.innerHTML = `
         <section class="hero-container">
        <div class="hero-subcontainer">
          <div class="hero-elements">
            <div class="hero-image">
              <img
                src="${data.mainImage}"
                alt="${data.title}"
                width="100%"
                height="100%"
              />
              <div class="incinemas">In Cinemas</div>
            </div>
            <div class="hero-details">
              <h1>${data.title}</h1>
              <div class="hero-rating">
                <div class="hero-rating-left">
                  <span class="star">
                    <i class="bx bxs-star"></i>
                  </span>
                  <span class="imdb-rating"> ${data.averageRating}/10 </span>
                  <span class="votes"> (25.1k votes) <span>></span> </span>
                </div>
                <button>Rate Now</button>
              </div>
              <div class="hero-format-details">
                <div class="movie-formats">
                  <a href="">2D</a>, <a href="">2D SCREEN X</a>,
                  <a href="">mx4d</a>, <a href="">4dx</a>,
                  <a href="">Imax 2d</a>,
                  <a href="">ice</a>
                </div>
                <div class="movie-languages">
                  <a href="">Tamil</a>, <a href="">English</a>,
                  <a href="">Telugu</a>, <a href="">Malayalam</a>,
                  <a href="">Kannada</a>,
                  <a href="">Hindi</a>
                </div>
              </div>
              <div class="movie-details">
                <span class="time"> ${convertHoursToHoursMinutes(
                  data.durationInHours
                )} </span>
                <ul>
                  <li>${data.genre}</li>
                  <li>${data.certification}</li>
                  <li>${formatDate(data.releaseDate)}</li>
                </ul>
              </div>
              <div class="booknow">
                <a href="" class="btn btn-hover">
                  <span>Book Now</span>
                </a>
              </div>
            </div>
          </div>
        </div>
      </section>
      <!-- End Hero Container -->
      <section class="synopsis-container">
        <div class="synopsis">
          <div class="component-1">
            <h2 class="about-1">About the movie</h2>
            <p class="about-2">
              ${data.description}
            </p>
          </div>
          <!-- Cast -->
          <div class="component-2">
            <h2>Cast</h2>
            <div class="cast-container swiper-container">
              <div class="swiper-wrapper">
              ${data.castMemberRoles
                .map((castmember) => {
                  return `
                  <div class="cast-card swiper-slide">
                  <img
                    alt="${castmember.artistName}"
                    src="${castmember.artistImage}"
                  />
                  <div class="cast-info">
                    <p>${castmember.artistName}</p>
                    <span>as ${castmember.characterName}</span>
                  </div>
                </div>
                  `;
                })
                .join("")}
              </div>
            </div>
          </div>
          <!-- End Cast Container -->
          <!-- Reviews -->
          <div class="component-3">
            <div class="review-wrapper">
              <div class="review-head">
                <h2>Top Reviews</h2>
                <span>11.3k reviews <a href="#">></a></span>
              </div>

              <div class="summary-reviews">
                <p>Summmary of 11.3k reviews.</p>
                <div class="hashtag-container swiper-container">
                  <div class="swiper-wrapper">
                    <div class="hashtag-card swiper-slide">
                      <span
                        >#SuperDirection
                        <span class="hashtag-count">5663</span></span
                      >
                    </div>
                    <div class="hashtag-card swiper-slide">
                      <span
                        >#SuperDirection
                        <span class="hashtag-count">5663</span></span
                      >
                    </div>
                    <div class="hashtag-card swiper-slide">
                      <span
                        >#SuperDirection
                        <span class="hashtag-count">5663</span></span
                      >
                    </div>
                    <div class="hashtag-card swiper-slide">
                      <span
                        >#SuperDirection
                        <span class="hashtag-count">5663</span></span
                      >
                    </div>
                    <div class="hashtag-card swiper-slide">
                      <span
                        >#SuperDirection
                        <span class="hashtag-count">5663</span></span
                      >
                    </div>
                  </div>
                </div>
              </div>

              <div class="top-review-wrapper">
                <div class="review-card-container">
                  <div class="review-card">
                    <div class="review-profile">
                      <div class="user-profile">
                        <i class="bx bxs-user-circle"></i>
                        <span>Jeswin</span>
                      </div>
                      <div class="review-rating">
                        <i class="bx bxs-star"></i>
                        <span>8/10</span>
                      </div>
                    </div>
                    <h2>#SuperDirection #Wellmade</h2>
                    <p class="review-description">
                      Fury Road is a masterpiece in action films especially for
                      the Mad Max franchise. It took me by surprise so I was
                      eager to watch this prequel. It didn’t disappoint. For
                      those unfamiliar, the Mad Max franchise is an Australian
                      dystopian action series created by George Miller and Byron
                      Kennedy. The story centers on Max Rockatansky, a man
                      fighting to stay alive in a post-apocalyptic Australia
                      devastated by societal collapse caused by war and resource
                      depletion. This film explores Furiosa's origin story
                      detailing her journey as a renegade warrior in a dystopian
                      Australia before she meets and joins forces with Mad Max.
                      The story takes place around 15 years before Fury Road,
                      where young Furiosa (Anya Taylor Joy) is being taken from
                      her village. Captured by a biker horde under the command
                      of warlord Dementus (Chris Hemsworth), Furiosa finds
                      herself navigating the chaotic “Wasteland”. The storyline
                      is developed with characters slightly more fleshed out
                      than the previous film, however; at times, the complexity
                      feels unjustified and becomes noticeably frustrating when
                      character development tries to overshadow the action. Anya
                      Taylor Joy shines, dominating the screen with her depth
                      and quiet strength. Experiencing Furiosa's transformation
                      throughout the story was a genuine pleasure. Also the
                      girl, Alyla Browne, who plays young Furiosa did an
                      incredible job, even with minimal dialogue. Chris
                      Hemsworth tries to steal the show as Dementus, the
                      villainous gang leader, a stark contrast from his usual
                      portrayals as the hero. In a couple of scenes, by the
                      costumes and hairstyling, he even looks like Thor, yeah
                      Thor, his Marvel counterpart. Coming to the visuals, the
                      entire place is vividly stunning, captivating your eyes
                      and likely sending your heart rate into pretty much
                      overdrive. The gritty, decayed settings reminiscent of
                      Fury Road pound you with rich rusty hues of orange, red,
                      and yellow, all the while immersing you in a world heavy
                      with metal and gasoline. Fury Road set a high standard
                      with its gripping editing, and this movie comes close,
                      complemented by strong sound design. Cinematography is
                      superb, real delightful. It truly elevates the film in the
                      art of staging, framing action and characters. The action
                      sequences are expertly choreographed keeping you on the
                      edge of your seat throughout. There are moments of
                      unexpected beauty that leave an impression and yeah this
                      film is IMAX recommended. As for the VFX, another Fury
                      Road mastery, I expected more as some of the CGI sequences
                      looked a bit fake along with some of the action physics
                      being totally off. However, the fine production design,
                      intense editing and cinematography overcomes this. George
                      Miller impresses. His ability to build immersive worlds
                      and characters is incomparable. The seamless integration
                      of action set pieces into his storytelling leaves you
                      marveling at how he even begins to craft such a film.
                      Certainly, he knows what to do with a valuable franchise
                      and take it forward. While the action in Furiosa is
                      undoubtedly thrilling, it might not reach the same
                      intensity as Fury Road. However, if you're willing to
                      embrace Miller's dystopian vision fully, you'll still find
                      plenty to enjoy in this cinematic adventure. Worth
                      watching.
                    </p>
                    <span class="read-more" id="readMore">more...</span>
                    <div class="card-footer">
                      <div class="opinion">
                        <div class="like">
                          <i class="bx bx-like"></i>
                          <span class="like-count">200</span>
                        </div>
                        <div class="dislike">
                          <i class="bx bx-dislike"></i>
                          <span class="dislike-count"></span>
                        </div>
                      </div>
                      <div class="date-share">
                        <span class="posted-date">31 Days Ago</span>
                        <i class="bx bx-share-alt"></i>
                      </div>
                    </div>
                  </div>
                  <div class="review-card">
                    <div class="review-profile">
                      <div class="user-profile">
                        <i class="bx bxs-user-circle"></i>
                        <span>Jeswin</span>
                      </div>
                      <div class="review-rating">
                        <i class="bx bxs-star"></i>
                        <span>8/10</span>
                      </div>
                    </div>
                    <h2>#SuperDirection #Wellmade</h2>
                    <p class="review-description">
                      Fury Road is a masterpiece in action films especially for
                      the Mad Max franchise. It took me by surprise so I was
                      eager to watch this prequel. It didn’t disappoint. For
                      those unfamiliar, the Mad Max franchise is an Australian
                      dystopian action series created by George Miller and Byron
                      Kennedy. The story centers on Max Rockatansky, a man
                      fighting to stay alive in a post-apocalyptic Australia
                      devastated by societal collapse caused by war and resource
                      depletion. This film explores Furiosa's origin story
                      detailing her journey as a renegade warrior in a dystopian
                      Australia before she meets and joins forces with Mad Max.
                      The story takes place around 15 years before Fury Road,
                      where young Furiosa (Anya Taylor Joy) is being taken from
                      her village. Captured by a biker horde under the command
                      of warlord Dementus (Chris Hemsworth), Furiosa finds
                      herself navigating the chaotic “Wasteland”. The storyline
                      is developed with characters slightly more fleshed out
                      than the previous film, however; at times, the complexity
                      feels unjustified and becomes noticeably frustrating when
                      character development tries to overshadow the action. Anya
                      Taylor Joy shines, dominating the screen with her depth
                      and quiet strength. Experiencing Furiosa's transformation
                      throughout the story was a genuine pleasure. Also the
                      girl, Alyla Browne, who plays young Furiosa did an
                      incredible job, even with minimal dialogue. Chris
                      Hemsworth tries to steal the show as Dementus, the
                      villainous gang leader, a stark contrast from his usual
                      portrayals as the hero. In a couple of scenes, by the
                      costumes and hairstyling, he even looks like Thor, yeah
                      Thor, his Marvel counterpart. Coming to the visuals, the
                      entire place is vividly stunning, captivating your eyes
                      and likely sending your heart rate into pretty much
                      overdrive. The gritty, decayed settings reminiscent of
                      Fury Road pound you with rich rusty hues of orange, red,
                      and yellow, all the while immersing you in a world heavy
                      with metal and gasoline. Fury Road set a high standard
                      with its gripping editing, and this movie comes close,
                      complemented by strong sound design. Cinematography is
                      superb, real delightful. It truly elevates the film in the
                      art of staging, framing action and characters. The action
                      sequences are expertly choreographed keeping you on the
                      edge of your seat throughout. There are moments of
                      unexpected beauty that leave an impression and yeah this
                      film is IMAX recommended. As for the VFX, another Fury
                      Road mastery, I expected more as some of the CGI sequences
                      looked a bit fake along with some of the action physics
                      being totally off. However, the fine production design,
                      intense editing and cinematography overcomes this. George
                      Miller impresses. His ability to build immersive worlds
                      and characters is incomparable. The seamless integration
                      of action set pieces into his storytelling leaves you
                      marveling at how he even begins to craft such a film.
                      Certainly, he knows what to do with a valuable franchise
                      and take it forward. While the action in Furiosa is
                      undoubtedly thrilling, it might not reach the same
                      intensity as Fury Road. However, if you're willing to
                      embrace Miller's dystopian vision fully, you'll still find
                      plenty to enjoy in this cinematic adventure. Worth
                      watching.
                    </p>
                    <span class="read-more" id="readMore">more...</span>
                    <div class="card-footer">
                      <div class="opinion">
                        <div class="like">
                          <i class="bx bx-like"></i>
                          <span class="like-count">200</span>
                        </div>
                        <div class="dislike">
                          <i class="bx bx-dislike"></i>
                          <span class="dislike-count"></span>
                        </div>
                      </div>
                      <div class="date-share">
                        <span class="posted-date">31 Days Ago</span>
                        <i class="bx bx-share-alt"></i>
                      </div>
                    </div>
                  </div>
                  <div class="review-card">
                    <div class="review-profile">
                      <div class="user-profile">
                        <i class="bx bxs-user-circle"></i>
                        <span>Jeswin</span>
                      </div>
                      <div class="review-rating">
                        <i class="bx bxs-star"></i>
                        <span>8/10</span>
                      </div>
                    </div>
                    <h2>#SuperDirection #Wellmade</h2>
                    <p class="review-description">
                      Fury Road is a masterpiece in action films especially for
                      the Mad Max franchise. It took me by surprise so I was
                      eager to watch this prequel. It didn’t disappoint. For
                      those unfamiliar, the Mad Max franchise is an Australian
                      dystopian action series created by George Miller and Byron
                      Kennedy. The story centers on Max Rockatansky, a man
                      fighting to stay alive in a post-apocalyptic Australia
                      devastated by societal collapse caused by war and resource
                      depletion. This film explores Furiosa's origin story
                      detailing her journey as a renegade warrior in a dystopian
                      Australia before she meets and joins forces with Mad Max.
                      The story takes place around 15 years before Fury Road,
                      where young Furiosa (Anya Taylor Joy) is being taken from
                      her village. Captured by a biker horde under the command
                      of warlord Dementus (Chris Hemsworth), Furiosa finds
                      herself navigating the chaotic “Wasteland”. The storyline
                      is developed with characters slightly more fleshed out
                      than the previous film, however; at times, the complexity
                      feels unjustified and becomes noticeably frustrating when
                      character development tries to overshadow the action. Anya
                      Taylor Joy shines, dominating the screen with her depth
                      and quiet strength. Experiencing Furiosa's transformation
                      throughout the story was a genuine pleasure. Also the
                      girl, Alyla Browne, who plays young Furiosa did an
                      incredible job, even with minimal dialogue. Chris
                      Hemsworth tries to steal the show as Dementus, the
                      villainous gang leader, a stark contrast from his usual
                      portrayals as the hero. In a couple of scenes, by the
                      costumes and hairstyling, he even looks like Thor, yeah
                      Thor, his Marvel counterpart. Coming to the visuals, the
                      entire place is vividly stunning, captivating your eyes
                      and likely sending your heart rate into pretty much
                      overdrive. The gritty, decayed settings reminiscent of
                      Fury Road pound you with rich rusty hues of orange, red,
                      and yellow, all the while immersing you in a world heavy
                      with metal and gasoline. Fury Road set a high standard
                      with its gripping editing, and this movie comes close,
                      complemented by strong sound design. Cinematography is
                      superb, real delightful. It truly elevates the film in the
                      art of staging, framing action and characters. The action
                      sequences are expertly choreographed keeping you on the
                      edge of your seat throughout. There are moments of
                      unexpected beauty that leave an impression and yeah this
                      film is IMAX recommended. As for the VFX, another Fury
                      Road mastery, I expected more as some of the CGI sequences
                      looked a bit fake along with some of the action physics
                      being totally off. However, the fine production design,
                      intense editing and cinematography overcomes this. George
                      Miller impresses. His ability to build immersive worlds
                      and characters is incomparable. The seamless integration
                      of action set pieces into his storytelling leaves you
                      marveling at how he even begins to craft such a film.
                      Certainly, he knows what to do with a valuable franchise
                      and take it forward. While the action in Furiosa is
                      undoubtedly thrilling, it might not reach the same
                      intensity as Fury Road. However, if you're willing to
                      embrace Miller's dystopian vision fully, you'll still find
                      plenty to enjoy in this cinematic adventure. Worth
                      watching.
                    </p>
                    <span class="read-more" id="readMore">more...</span>
                    <div class="card-footer">
                      <div class="opinion">
                        <div class="like">
                          <i class="bx bx-like"></i>
                          <span class="like-count">200</span>
                        </div>
                        <div class="dislike">
                          <i class="bx bx-dislike"></i>
                          <span class="dislike-count"></span>
                        </div>
                      </div>
                      <div class="date-share">
                        <span class="posted-date">31 Days Ago</span>
                        <i class="bx bx-share-alt"></i>
                      </div>
                    </div>
                  </div>
                  <div class="left-button"></div>
                  <div class="right-button"></div>
                </div>
                <div class="left-btn">
                  <div class="left-btn-content">
                    <i class="bx bx-chevron-left"></i>
                  </div>
                </div>
                <div class="right-btn">
                  <div class="right-btn-content">
                    <i class="bx bx-chevron-right"></i>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- End Of Reviews -->
        </div>
      </section>
      `;
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

      const herosubcontainer = document.querySelector(".hero-subcontainer");
      function setBackgroundImage() {
        if (window.innerWidth >= 810) {
          herosubcontainer.style.backgroundImage = `linear-gradient(
            90deg,
            rgb(26, 26, 26) 24.97%,
            rgb(26, 26, 26) 38.3%,
            rgba(26, 26, 26, 0.04) 97.47%,
            rgb(26, 26, 26) 100%
          ),
          url('${data.bannerImage}')`;
        } else {
          herosubcontainer.style.backgroundImage = "none";
        }
      }
      setBackgroundImage();

      window.addEventListener("resize", setBackgroundImage);

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
