import { $, apiFetch, renderStatus } from '/scripts/common.js';

(async function () {
    const list = $('#actor-list');
    const status = $('#status');
    const template = $('#actor-card');

    try {
        const data = await apiFetch('/actors?page=1&size=50');

        list.replaceChildren();

        for (const a of data.data) {
            const node = template.content.cloneNode(true);

            // DATA
            node.querySelector('.name').textContent = a.name;

            // VIEW
            const viewBtn = node.querySelector('.btn-view');
            viewBtn.href = `/actors/view.html?id=${a.id}`;

            // EDIT
            const editBtn = node.querySelector('.btn-edit');
            editBtn.href = `/actors/edit.html?id=${a.id}`;

            // DELETE
            const deleteBtn = node.querySelector('.btn-delete');
            deleteBtn.addEventListener('click', async () => {
                const ok = confirm(`Delete actor "${a.name}"?`);
                if (!ok) return;

                try {
                    await apiFetch(`/actors/${a.id}`, {
                        method: 'DELETE'
                    });

                    renderStatus(status, 'ok', 'Actor deleted');
                    location.reload();
                } catch (err) {
                    renderStatus(status, 'err', err.message);
                }
            });

            list.appendChild(node);
        }

        if (!data.data.length) {
            list.innerHTML = `<p style="color:var(--text-muted)">No actors found</p>`;
        }

    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();