import { $, apiFetch, renderStatus, getQueryParam } from '/scripts/common.js';

(async function initMovieView() {
    const id = getQueryParam('id');
    const statusEl = $('#status');

    if (!id) return renderStatus(statusEl, 'err', 'Missing ?id in URL.');

    try {
        const m = await apiFetch(`/movies/${id}`);

        $('#movie-id').textContent = m.id;
        $('#movie-title').textContent = m.title;
        $('#movie-year').textContent = m.year;
        $('#movie-desc').textContent = m.description || '—';

        $('#edit-link').href = `/movies/edit.html?id=${m.id}`;


        const actors = await apiFetch(`/actormovies/movie/${id}`);
        const list = $('#actors-list');
        list.innerHTML = '';

        actors.forEach(a => {
            const li = document.createElement('li');
            li.textContent = `${a.name} (ID: ${a.id})`;
            list.appendChild(li);
        });

        renderStatus(statusEl, 'ok', 'Movie loaded');

    } catch (err) {
        renderStatus(statusEl, 'err', err.message);
    }


    $('#actor-movie-form').addEventListener('submit', async (e) => {
        e.preventDefault();

        const actorId = Number($('#actorId').value);

        try {
            await apiFetch('/actormovies', {
                method: 'POST',
                body: JSON.stringify({ actorId, movieId: Number(id) })
            });

            renderStatus(statusEl, 'ok', 'Actor added to movie');
            location.reload();

        } catch (err) {
            renderStatus(statusEl, 'err', err.message);
        }
    });
})();