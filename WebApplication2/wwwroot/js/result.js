const btnTabs1 = document.getElementById('btnTabs1');
const btnTabs2 = document.getElementById('btnTabs2');
const btnTabs3 = document.getElementById('btnTabs3');
const btnTabs4 = document.getElementById('btnTabs4');
const btnTabs5 = document.getElementById('btnTabs5');
const btnTabs6 = document.getElementById('btnTabs6');
const btnTabs7 = document.getElementById('btnTabs7');
function clickBtn(btn) {
  btn.classList.toggle('btn_tabs_active');
}
btnTabs1.addEventListener('click', function () {
  clickBtn(btnTabs1);
});
btnTabs2.addEventListener('click', function () {
  clickBtn(btnTabs2);
});
btnTabs3.addEventListener('click', function () {
  clickBtn(btnTabs3);
});
btnTabs4.addEventListener('click', function () {
  clickBtn(btnTabs4);
});
btnTabs5.addEventListener('click', function () {
  clickBtn(btnTabs5);
});
btnTabs6.addEventListener('click', function () {
  clickBtn(btnTabs6);
});
btnTabs7.addEventListener('click', function () {
  clickBtn(btnTabs7);
});
