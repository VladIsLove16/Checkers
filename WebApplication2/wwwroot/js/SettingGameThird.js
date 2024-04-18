const nameSystem = document.getElementById('name_system');
const mas = ['systemOne', 'systemTwo', 'systemThree', 'sistemFour'];
for (const iter of mas) {
  if (localStorage.getItem(iter)) {
    nameSystem.textContent = localStorage.getItem(iter);
    localStorage.removeItem(iter);
  }
}
