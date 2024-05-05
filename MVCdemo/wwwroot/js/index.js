const listImage = document.querySelector('.list-images');
const imgs = document.querySelectorAll('.list-images img');
const btnLeft = document.querySelector('.btn-left');
const btnRight = document.querySelector('.btn-right');
const length = imgs.length;
let current = 0;
const handleChangeslide = () => {
    current = (current + 1) % length;
    let width = imgs[0].offsetWidth;
    listImage.style.transform = `translateX(-${width * current}px)`;
    document.querySelector('.active').classList.remove('active');
    document.querySelector('.index-item-' + current).classList.add('active');
};

let handleVentChangeSlide = setInterval(handleChangeslide, 3000);

btnRight.addEventListener('click', () => {
    clearInterval(handleVentChangeSlide);
    handleChangeslide();
    handleVentChangeSlide = setInterval(handleChangeslide, 3000);
});

btnLeft.addEventListener('click', () => {
    clearInterval(handleVentChangeSlide);
    current = (current - 1 + length) % length;
    let width = imgs[0].offsetWidth;
    listImage.style.transform = `translateX(-${width * current}px)`;
    document.querySelector('.active').classList.remove('active');
    document.querySelector('.index-item-' + current).classList.add('active');
    handleVentChangeSlide = setInterval(handleChangeslide, 3000);
});
