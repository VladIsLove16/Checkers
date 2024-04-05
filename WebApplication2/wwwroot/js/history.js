const search = document.getElementById('input_name_tournaments');
const labelSearch = document.getElementById('labelSearch');
search.addEventListener('focus', () => {
  labelSearch.style.bottom = '1.5rem';
  labelSearch.style.fontSize = '1.3rem';
  search.style.right = '45rem';
  search.style.height = '4.5rem';
});
search.addEventListener('blur', () => {
  labelSearch.style.fontSize = '1.8rem';
  labelSearch.style.bottom = '0';
  search.style.right = '51rem';
  search.style.paddingBlock = '1.5rem';
});
