import { $, apiFetch, renderStatus, getQueryParam } from '/scripts/common.js';

(async function () {
    const id = getQueryParam('id');
    const status = $('#status');

    if (!id) return renderStatus(status, 'err', 'Missing id');

    try {
        const a = await apiFetch(`/actors/${id}`);

        $('#actor-id').textContent = a.id;
        $('#actor-name').textContent = a.name;

        $('#edit-link').href = `/actors/edit.html?id=${a.id}`;

        renderStatus(status, 'ok', 'Actor loaded');
    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();