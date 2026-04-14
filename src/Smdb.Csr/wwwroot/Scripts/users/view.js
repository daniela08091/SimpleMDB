import { $, apiFetch, renderStatus, getQueryParam } from '/scripts/common.js';


(async function () {
    const id = getQueryParam('id');
    const status = $('#status');

    if (!id) return renderStatus(status, 'err', 'Missing id');

    try {
        const u = await apiFetch(`/users/${id}`);

        $('#user-id').textContent = u.id;
        $('#user-name').textContent = u.name;
        $('#user-email').textContent = u.email;

        $('#edit-link').href = `/users/edit.html?id=${u.id}`;

        renderStatus(status, 'ok', 'User loaded');
    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();