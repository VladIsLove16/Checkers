const btnSwimMenu = document.getElementById('btnSwimMenu');
const sideMenu = document.getElementById('sideMenu');
const burgerImg = document.getElementById('burgerImg');
const backBurgerImg = document.getElementById('backBurgerImg');
const closeMenu = document.getElementById('closeMenu');
btnSwimMenu.addEventListener('click', () => {
  if (sideMenu.style.display !== 'none') {
    sideMenu.style.display = 'none';
    btnSwimMenu.classList.remove('btn_swim_menu');
    btnSwimMenu.classList.add('close-btn_swim_menu');
    burgerImg.classList.remove('burger-menu');
    backBurgerImg.classList.remove('back-burger');
    burgerImg.classList.add('close-burger-menu');
    backBurgerImg.classList.add('close-back-burger');
  } else {
    sideMenu.style.display = 'block';
    btnSwimMenu.classList.remove('close-btn_swim_menu');
    btnSwimMenu.classList.add('btn_swim_menu');
    burgerImg.classList.remove('close-burger-menu');
    backBurgerImg.classList.remove('close-back-burger');
    burgerImg.classList.add('burger-menu');
    backBurgerImg.classList.add('back-burger');
  }
});
