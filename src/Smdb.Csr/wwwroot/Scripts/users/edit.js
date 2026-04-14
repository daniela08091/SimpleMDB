import { $, apiFetch, renderStatus, getQueryParam, captureUserForm } from '/scripts/common.js';

(async function () {
    const id = getQueryParam('id');
    const form = $('#user-form');
    const status = $('#status');

    if (!id) return renderStatus(status, 'err', 'Missing id');

    try {
        const u = await apiFetch(`/users/${id}`);
        form.name.value = u.name;
        form.email.value = u.email;
    } catch (err) {
        return renderStatus(status, 'err', err.message);
    }

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const payload = captureUserForm(form);

        try {
            await apiFetch(`/users/${id}`, {
                method: 'PUT',
                body: JSON.stringify(payload)
            });
            renderStatus(status, 'ok', 'Updated');
        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();