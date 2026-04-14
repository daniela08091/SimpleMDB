import { $, apiFetch, renderStatus, getQueryParam } from '/scripts/common.js';

(async function () {
    const id = getQueryParam('id');
    const status = $('#status');

    if (!id) return renderStatus(status, 'err', 'Missing id');

    try {
        const r = await apiFetch(`/actormovies/${id}`);

        $('#id').textContent = r.id;
        $('#actor').textContent = r.actorId;
        $('#movie').textContent = r.movieId;

        $('#edit-link').href = `/actormovies/edit.html?id=${r.id}`;

        renderStatus(status, 'ok', 'Loaded');
    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();