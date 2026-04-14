import { $, apiFetch, renderStatus } from '/scripts/common.js';

(async function () {
    const list = $('#user-list');
    const status = $('#status');
    const template = $('#user-card');

    try {
        const data = await apiFetch('/users?page=1&size=50');

        list.replaceChildren();

        for (const u of data.data) {
            const node = template.content.cloneNode(true);

            // DATA
            node.querySelector('.name').textContent = u.name;
            node.querySelector('.email').textContent = u.email;

            // VIEW
            const viewBtn = node.querySelector('.btn-view');
            viewBtn.href = `/users/view.html?id=${u.id}`;

            // EDIT
            const editBtn = node.querySelector('.btn-edit');
            editBtn.href = `/users/edit.html?id=${u.id}`;

            // DELETE
            const deleteBtn = node.querySelector('.btn-delete');
            deleteBtn.addEventListener('click', async () => {
                const ok = confirm(`Delete user "${u.name}"?`);
                if (!ok) return;

                try {
                    await apiFetch(`/users/${u.id}`, {
                        method: 'DELETE'
                    });

                    renderStatus(status, 'ok', 'User deleted');
                    // reload list
                    location.reload();
                } catch (err) {
                    renderStatus(status, 'err', err.message);
                }
            });

            list.appendChild(node);
        }

        if (!data.data.length) {
            list.innerHTML = `<p style="color:var(--text-muted)">No users found</p>`;
        }

    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();