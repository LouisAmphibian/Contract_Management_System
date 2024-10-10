/*my dom variables*/
const inputs = document.querySelectorAll(".input-field");
const toggle_btn = document.querySelectorAll(".toggle");
const mainElement = document.querySelector(".main");
const bullets = document.querySelectorAll(".bullets span");
const images = document.querySelectorAll(".image");

inputs.forEach((inp) => {
    inp.addEventListener("focus", () => {
        inp.classList.add("active");
    }); 

    inp.addEventListener("blur", () => {
        if (inp.value !== "") {
            return;
        }
        inp.classList.remove("active");
    });
});

toggle_btn.forEach((btn) => {
    btn.addEventListener("click", () => {
        mainElement.classList.toggle("sign-up-mode");
    });
});

//fuction to slide to th next images carousel
function moveSlider(event) {
    let index = event.target.dataset.value;  

    let currentImage = document.querySelector(`.img-${index}`); //`` when there is $ in JavaScript

    images.forEach((img) => img.classList.remove("show"));
    currentImage.classList.add("show");

    const textSlider = document.querySelector(".text-group");

    textSlider.style.transform = `translateY(${-(index -1) * 2.2}rem)`;

    bullets.forEach((bull) => bull.classList.remove("active"));

    event.target.classList.add("active");
}

bullets.forEach((bullet) => {
    bullet.addEventListener("click", moveSlider);
});

    