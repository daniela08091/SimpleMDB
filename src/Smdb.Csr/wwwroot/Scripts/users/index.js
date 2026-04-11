import { $, apiFetch, renderStatus } from '/scripts/common.js';

(async function () {
    const list = $('#user-list');
    const status = $('#status');

    try {
        const data = await apiFetch('/users?page=1&size=50');
        for (const u of data.data) {
            const div = document.createElement('div');
            div.textContent = `${u.name} (${u.email})`;
            list.appendChild(div);
        }
    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();