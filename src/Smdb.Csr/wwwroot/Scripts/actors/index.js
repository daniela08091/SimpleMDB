import { $, apiFetch, renderStatus } from '/scripts/common.js';

(async function () {
    const list = $('#actor-list');
    const status = $('#status');

    try {
        const data = await apiFetch('/actors?page=1&size=50');
        for (const a of data.data) {
            const div = document.createElement('div');
            div.textContent = `${a.id} - ${a.name}`;
            list.appendChild(div);
        }
    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();