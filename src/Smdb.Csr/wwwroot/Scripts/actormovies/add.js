import { $, apiFetch, renderStatus, captureActorMovieForm } from '/scripts/common.js';

(async function () {
    const form = $('#form');
    const status = $('#status');

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const payload = captureActorMovieForm(form);

        try {
            await apiFetch('/actormovies', {
                method: 'POST',
                body: JSON.stringify(payload)
            });
            renderStatus(status, 'ok', 'Relation created');
            form.reset();
        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();