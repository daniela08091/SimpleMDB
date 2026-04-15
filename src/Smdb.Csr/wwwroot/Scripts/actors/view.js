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

       
        const movies = await apiFetch(`/actormovies/actor/${id}`);
        const list = $('#movies-list');
        list.innerHTML = '';

        movies.forEach(m => {
            const li = document.createElement('li');
            li.textContent = `${m.title} (${m.year})`;
            list.appendChild(li);
        });

        renderStatus(status, 'ok', 'Actor loaded');

    } catch (err) {
        renderStatus(status, 'err', err.message);
    }

    
    $('#actor-movie-form').addEventListener('submit', async (e) => {
        e.preventDefault();

        const movieId = Number($('#movieId').value);

        try {
            await apiFetch('/actormovies', {
                method: 'POST',
                body: JSON.stringify({ actorId: Number(id), movieId })
            });

            renderStatus(status, 'ok', 'Movie added to actor');
            location.reload();

        } catch (err) {
            renderStatus(status, 'err', err.message);
        }
    });
})();