/*my dom variables*/
const input = document.querySelectorAll(".input-field");
const toggle_btn = document.querySelector(".toggle");
const main = document.querySelectorAll(".main");
const bullets = document.querySelectorAll(".bullets span");
const images = document.querySelectorAll(".image");

inputs.forEach((inp) => {
    inp.addEventListener("focus", () => {
        inp.classLIst.add("active");
    });

    inp.addEventListener("blur", () => {
        if (inp.value != "") {
            return;
        }
        inp.classLIst.remove("active");
    });
});

toggle_btn.forEach((btn) => {
    btn.addEventListener("click", () => {
        main.classLIst.toggle("sign-up-mode");
    });
});

//fuction to slide the forms
function moveSlider() {
    let index = this.dataset.value;

    let currentImage = document.querySelector('img-${index}');

    images.forEach((img) => img.classList.remove("show"));
    currentImage.classList.add("show");

    const textSlider = document.querySelector(".text-group");

    textSlider.style.transform = 'translateY(${-(index -1) * 2.2}rem)';

    bullets.forEach((bull) => bull.classList.remove("active"));

    this.classList.add("active");
}

bullets.forEach((bullet) => {
    bullet.addEventListener("click", moveSlider);
});