import { $, apiFetch, renderStatus } from '/scripts/common.js';

(async function () {
    const list = $('#list');
    const status = $('#status');
    const template = $('#relation-card');

    try {
        const [relations, actorsRes, moviesRes] = await Promise.all([
            apiFetch('/actormovies'),
            apiFetch('/actors?page=1&size=100'),
            apiFetch('/movies?page=1&size=100')
        ]);

        const actors = actorsRes.data;
        const movies = moviesRes.data;

        list.replaceChildren();

        for (const r of relations) {

            const actor = actors.find(a => a.id === r.actorId);
            const movie = movies.find(m => m.id === r.movieId);

            const node = template.content.cloneNode(true);

            node.querySelector('.actor').textContent =
                actor?.name ?? `Actor #${r.actorId}`;

            node.querySelector('.movie').textContent =
                movie?.title ?? `Movie #${r.movieId}`;


            node.querySelector('.btn-delete').addEventListener('click', async () => {
                if (!confirm('Delete this relation?')) return;

                try {
                    await apiFetch(`/actormovies/${r.id}`, {
                        method: 'DELETE'
                    });

                    renderStatus(status, 'ok', 'Deleted');
                    location.reload();
                } catch (err) {
                    renderStatus(status, 'err', err.message);
                }
            });

            list.appendChild(node);
        }

        if (!relations.length) {
            list.innerHTML = `<p style="color:var(--text-muted)">No relations found</p>`;
        }

    } catch (err) {
        renderStatus(status, 'err', err.message);
    }
})();