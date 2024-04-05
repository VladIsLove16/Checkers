const system_1 = document.getElementById('system_1');
const system_2 = document.getElementById('system_2');
const system_3 = document.getElementById('system_3');
const system_4 = document.getElementById('system_4');
const desc1 = document.getElementById('desc1');
const desc2 = document.getElementById('desc2');
const desc3 = document.getElementById('desc3');
const desc4 = document.getElementById('desc4');
const backFon = document.getElementById('backFon');
let flag = 0;
function showSystem(desc) {
  if (desc.style.display === 'none') {
    desc.style.display = 'flex';
    desc.style.height = '57vh';
    backFon.style.backgroundImage = "url('/img/Frame-system1.png')";
  } else {
    desc.style.display = 'none';
    backFon.style.backgroundImage = "url('/img/Frame-system.png')";
  }
}
system_1.addEventListener('click', () => {
  switch (flag) {
    case 0:
      showSystem(desc1);
      flag = 1;
      break;
    case 1:
      showSystem(desc1);
      flag = 0;
      break;
    case 2:
      showSystem(desc2);
      showSystem(desc1);
      flag = 1;
      break;
    case 3:
      showSystem(desc3);
      showSystem(desc1);
      flag = 1;
      break;
    case 4:
      showSystem(desc4);
      showSystem(desc1);
      flag = 1;
    default:
      break;
  }
});

system_2.addEventListener('click', () => {
  switch (flag) {
    case 0:
      showSystem(desc2);
      flag = 2;
      break;
    case 1:
      showSystem(desc1);
      showSystem(desc2);
      flag = 2;
      break;
    case 2:
      showSystem(desc2);
      flag = 0;
      break;
    case 3:
      showSystem(desc3);
      showSystem(desc2);
      flag = 2;
      break;
    case 4:
      showSystem(desc4);
      showSystem(desc2);
      flag = 2;
    default:
      break;
  }
});
system_3.addEventListener('click', () => {
  switch (flag) {
    case 0:
      showSystem(desc3);
      flag = 3;
      break;
    case 1:
      showSystem(desc1);
      showSystem(desc3);
      flag = 3;
      break;
    case 2:
      showSystem(desc2);
      showSystem(desc3);
      flag = 3;
      break;
    case 3:
      showSystem(desc3);
      flag = 0;
      break;
    case 4:
      showSystem(desc4);
      showSystem(desc3);
      flag = 3;
    default:
      break;
  }
});
system_4.addEventListener('click', () => {
  switch (flag) {
    case 0:
      showSystem(desc4);
      flag = 4;
      break;
    case 1:
      showSystem(desc1);
      showSystem(desc4);
      flag = 4;
      break;
    case 2:
      showSystem(desc2);
      showSystem(desc4);
      flag = 4;
      break;
    case 3:
      showSystem(desc3);
      showSystem(desc4);
      flag = 4;
      break;
    case 4:
      showSystem(desc4);
      flag = 0;
    default:
      break;
  }
});
