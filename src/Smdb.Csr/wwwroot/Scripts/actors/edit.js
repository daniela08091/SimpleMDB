import { $, apiFetch, renderStatus, getQueryParam, captureActorForm } from '/scripts/common.js';

(async function () {
    const id = getQueryParam('id');
    const form = $('#actor-form');
    const status = $('#status');

    if (!id) {
        renderStatus(status, 'err', 'Missing id');
        return;
    }

    try {
        const a = await apiFetch(`/actors/${id}`);
        form.name.value = a.name;
    } catch (err) {
        return renderStatus(status, 'err', err.message);
    }

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const payload = captureActorForm(form);

        try {
            await apiFetch(`/actors/${id}`, {
                method: 'PUT',
                body: JSON.stringify(payload)
            });
            renderStatus(status, 'ok', 'Updated');
        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();