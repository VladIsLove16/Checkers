const nameSystem = document.getElementById('name_system');
const link = document.getElementById('Link');
function getQueryParam(param) {
  const urlParams = new URLSearchParams(window.location.search);
  return urlParams.get(param);
}
switch (getQueryParam('choice')) {
  case '1':
    nameSystem.textContent = 'КРУГОВАЯ СИСТЕМА';
    localStorage.setItem('systemOne', 'КРУГОВАЯ СИСТЕМА');
    break;
  case '2':
    nameSystem.textContent = 'ОЛИМПИЙСКАЯ СИСТЕМА';
    localStorage.setItem('systemTwo', 'ОЛИМПИЙСКАЯ СИСТЕМА');
    break;
  case '3':
    nameSystem.textContent = 'СХЕВЕНИНГЕНСКАЯ СИСТЕМА';
    localStorage.setItem('systemThree', 'СХЕВЕНИНГЕНСКАЯ СИСТЕМА');
    break;
  case '4':
    nameSystem.textContent = 'ШВЕЙЦАРСКАЯ СИСТЕМА';
    localStorage.setItem('systemFour', 'ШВЕЙЦАРСКАЯ СИСТЕМА');
  default:
    break;
}
