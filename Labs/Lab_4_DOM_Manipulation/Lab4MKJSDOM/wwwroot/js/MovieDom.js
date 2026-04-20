'use strict';

class MovieDOM {
    #movies = [];

    showMovies(parentElement, movies) {
        if (movies.length === 0) {
            parentElement.appendChild(this.#createEmptyState());
            return;
        }
        this.#movies = movies;
        for (let movie of movies) {
            parentElement.appendChild(this.#createMovieCard(movie));
        }
        console.log(movies);
        console.log(parentElement);
    }

    #createEmptyState() {
        let emptyState = document.createElement('div');

        emptyState.className = 'col-12 text-center py-5';
        emptyState.id = 'emptyState';
        emptyState.style.display = 'block';
        emptyState.innerHTML = '<i class="bi bi-film display-1 text-muted"></i><h4 class="mt-3 text-muted">No Movies Found</h4><p class="text-muted">Start by adding your first movie above!</p>';

        return emptyState;
    }

    #createMovieCard(movie) {
        let sampleCard = document.createElement('div');
        sampleCard.className = 'col-lg-3 col-md-4 col-sm-6 mb-4';
        sampleCard.style.display = 'block';
        sampleCard.setAttribute('id', `movie-${movie.id}`)

        // Format the release date
        const releaseDate = new Date(movie.releaseDate + 'T00:00:00');
        console.log(releaseDate);
        const formattedDate = releaseDate.toLocaleDateString('en-US', {
            year: 'numeric',
            month: 'long',
            day: 'numeric'
        });

        let spanAvailable = movie.isAvailable ? `<span class="badge bg-success">Available</span>` : `<span class="badge bg-danger">Unavailable</span>`;
        
        sampleCard.innerHTML = `<div class="card h-100 shadow-sm movie-card">
                <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
                    <h6 class="mb-0 text-truncate">${movie.title}</h6>
                    ${spanAvailable}
                </div>
                <div class="card-body">
                    <p class="mb-2">
                        <strong><i class="bi bi-person-fill"></i> Director:</strong><br>
                        ${movie.director}
                    </p>
                    <p class="mb-3">
                        <strong><i class="bi bi-calendar-event"></i> Release Date:</strong><br>
                        ${formattedDate}
                    </p>
                </div>
                <div class="card-footer bg-transparent border-top-0">
                    <div class="d-flex gap-2">
                        <button class="btn btn-sm btn-outline-primary flex-fill edit-btn" title="Edit" data-movie-id="${movie.id}">
                            <i class="bi bi-pencil-square"></i> Edit
                        </button>
                        <button class="btn btn-sm btn-outline-danger flex-fill delete-btn" title="Delete" data-movie-id="${movie.id}">
                            <i class="bi bi-trash"></i> Delete
                        </button>
                    </div>
                </div>
            </div>`;

        return sampleCard;
    }

    setUpEventListeners() {
        document.addEventListener('submit', (e)=> {
            if (e.target.getAttribute('id') === 'movieForm') {
                e.preventDefault();
                console.log('Form Submitted');
                let movie = this.#processForm();
                let editState = document.getElementById('submitBtn').textContent.includes("Update");
                if (editState) {
                    let card = document.getElementById(`movie-${movie.id}`);
                    let newCard = this.#createMovieCard(movie);
                    card.replaceWith(newCard);
                    return;
                }
                this.#movies.push(movie);
                const movieGrid = document.querySelector('#moviesGrid');
                this.#createAndAppendMovieCard(movie, movieGrid);
                this.#resetForm();
            }
        });

        document.addEventListener('click', (e)=> {
            if (e.target.classList.contains('edit-btn')){
                let movieItem = e.target.closest('.edit-btn');
                let id = movieItem.getAttribute('data-movie-id');
                this.#populateFormForEdit(id);
            }
        });

        document.addEventListener('click', (e) => {
            if (e.target.classList.contains('delete-btn')) {
                let movieItem = e.target.closest('.delete-btn');
                let id = movieItem.getAttribute('data-movie-id');
                this.#deleteMovie(id);
            }
        });

        document.addEventListener('click', (e) => {
            if (e.target.getAttribute('id') === 'cancelBtn') {
                this.#resetForm();
            }
        });
    }

    #processForm() {
        let formElement = document.getElementById('movieForm');

        let editState = document.getElementById('submitBtn').textContent.includes("Update");

        const formData = new FormData(formElement);

        let newMovie = {
            id: editState ? parseInt(formData.get('movieId')) : this.#movies.length + 1,
            title: formData.get('title'),
            director: formData.get('director'),
            releaseDate: formData.get('releaseDate'),
            isAvailable: formData.get('isAvailable') === 'true'
        };

        console.log(newMovie);
        return newMovie;
    }

    #createAndAppendMovieCard(movie, parentElement) {
        // Create the movie card
        const cardCol = this.#createMovieCard(movie);

        // Hide it initially for animation
        $(cardCol).hide();

        // Append to parent and animate
        $(parentElement).append(cardCol);
        $(cardCol).fadeIn(600);
    }

    #resetForm() {
        // Reset all form fields to default values
        document.getElementById('movieForm').reset();

        // Reset the hidden movie ID to 0 (for add mode)
        document.getElementById('movieId').value = '0';

        // Update form heading back to "Add New Movie"
        document.querySelector('.card-title').innerHTML = '<i class="bi bi-plus-circle"></i> Add New Movie';

        // Update button text back to "Add Movie"
        document.getElementById('submitBtn').innerHTML = '<i class="bi bi-plus-lg"></i> Add Movie';

        // Hide the cancel button
        document.getElementById('cancelBtnRow').style.display = 'none';
    }

    #populateFormForEdit(movieId) {
        let newMovie = this.#movies.find((element) => element.id == movieId);

        if (!newMovie) {
            return;
        }
        //populate form fields
        document.getElementById('movieId').value = newMovie.id;
        document.getElementById('title').value = newMovie.title;
        document.getElementById('director').value = newMovie.director;
        document.getElementById('releaseDate').value = newMovie.releaseDate;
        document.getElementById('isAvailable').value = newMovie.isAvailable;

        //change new movie heading 
        document.querySelector('.card-title').innerHTML = '<i class="bi bi-plus-circle"></i> Edit Movie';

        // change button text
        document.querySelector('#submitBtn').innerHTML = '<i class="bi bi-plus-lg"></i> Update Movie';

        // show cancel button
        document.getElementById('cancelBtnRow').style.display = 'block';

        // Scroll to form
        document.getElementById('movieForm').scrollIntoView( {behavior: 'smooth', block: 'start'});
    }

    #deleteMovie(movieId) {
        // Find the movie
        const movie = this.#movies.find(m => m.id == movieId);
        if (!movie) return;

        // Show confirmation dialog
        const confirmed = confirm(`Are you sure you want to delete "${movie.title}"?`);

        if (confirmed) {
            // Remove from array
            const index = this.#movies.findIndex(m => m.id === movieId);
            if (index !== -1) {
                this.#movies.splice(index, 1);
            }

            // Remove the card with animation
            const card = document.getElementById(`movie-${movieId}`);
            $(card).fadeOut(400, function () {
                $(this).remove();

                // Check if there are no movies left and show empty state
                const movieGrid = document.querySelector('#moviesGrid');
                if (this.#movies.length === 0) {
                    const emptyState = this.#createEmptyState();
                    movieGrid.appendChild(emptyState);
                }
            }.bind(this));
        }
    }
}

export {MovieDOM};