'use strict';

import {MovieDOM} from './MovieDom.js';

let movies = [
    {
        id: 1,
        title: "The Shawshank Redemption",
        director: "Frank Darabont",
        releaseDate: "1994-09-23",
        isAvailable: true
    },
    {
        id: 2,
        title: "The Godfather",
        director: "Francis Ford Coppola",
        releaseDate: "1972-03-24",
        isAvailable: true
    },
    {
        id: 3,
        title: "The Dark Knight",
        director: "Christopher Nolan",
        releaseDate: "2008-07-18",
        isAvailable: false
    },
    {
        id: 4,
        title: "Pulp Fiction",
        director: "Quentin Tarantino",
        releaseDate: "1994-10-14",
        isAvailable: true
    }
];
// Your code will go here
const movieGrid = document.querySelector('#moviesGrid');
let emptyMovies = [];
let movieDom = new MovieDOM();

movieDom.showMovies(movieGrid, movies);
movieDom.setUpEventListeners();