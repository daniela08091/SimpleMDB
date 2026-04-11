import { $, apiFetch, renderStatus } from '/scripts/common.js';

(async function () {
    const list = $('#list');
    const status = $('#status');

    try {
        const data = await apiFetch('/actormovies');
        for (const r of data) {
            const div = document.createElement('div');
            div.textContent = `Actor ${r.actorId} -> Movie ${r.movieId}`;
            list.appendChild(div);
        }
    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();