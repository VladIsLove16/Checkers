const listPlayers = document.getElementById('listPlayers');
const liPlayerArr = listPlayers.getElementsByTagName('li');
const spanPlayerArr = listPlayers.querySelectorAll('span.span_player');

for (const iter of liPlayerArr) {
  const i = iter.id;
  const match = i.split(/(\d+)/);
  const index = parseInt(match[1], 10) - 1;
  if (index >= 0 && index < spanPlayerArr.length) {
    const span_li_player = spanPlayerArr[index];
    span_li_player.textContent = match[1];
  }
}
