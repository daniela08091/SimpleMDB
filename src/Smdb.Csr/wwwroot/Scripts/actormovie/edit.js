import { $, apiFetch, renderStatus, getQueryParam, captureActorMovieForm } from '/scripts/common.js';

(async function () {
    const id = getQueryParam('id');
    const form = $('#form');
    const status = $('#status');

    if (!id) return renderStatus(status, 'err', 'Missing id');

    try {
        const r = await apiFetch(`/actormovies/${id}`);
        form.actorId.value = r.actorId;
        form.movieId.value = r.movieId;
    } catch (err) {
        return renderStatus(status, 'err', err.message);
    }

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const payload = captureActorMovieForm(form);

        try {
            await apiFetch(`/actormovies/${id}`, {
                method: 'PUT',
                body: JSON.stringify(payload)
            });
            renderStatus(status, 'ok', 'Updated');
        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();