import { $, apiFetch, renderStatus, captureActorForm } from '/scripts/common.js';

(async function () {
    const form = $('#actor-form');
    const status = $('#status');

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const payload = captureActorForm(form);

        try {
            await apiFetch('/actors', {
                method: 'POST',
                body: JSON.stringify(payload)
            });
            renderStatus(status, 'ok', 'Actor created');
            form.reset();
        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();