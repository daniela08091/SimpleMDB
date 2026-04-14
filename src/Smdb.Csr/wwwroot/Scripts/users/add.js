import { $, apiFetch, renderStatus, captureUserForm } from '/scripts/common.js';


(async function () {
    const form = $('#user-form');
    const status = $('#status');

    form.addEventListener('submit', async e => {
        e.preventDefault();
        const payload = captureUserForm(form);

        try {
            await apiFetch('/users', {
                method: 'POST',
                body: JSON.stringify(payload)
            });
            renderStatus(status, 'ok', 'User created');
            form.reset();
        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();