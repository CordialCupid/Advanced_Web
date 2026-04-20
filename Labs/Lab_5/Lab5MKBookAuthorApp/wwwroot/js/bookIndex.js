"use strict";

class Main {
    #bookRepo;
    #bookDetailsModal = new bootstrap.Modal(document.getElementById('bookDetailsModal'));
    #authorModal = new bootstrap.Modal(document.getElementById('authorModal'));

    async run() {
        this.#bookRepo = new BookAJAXRepository('http://localhost:5253');
        const bookContainer = document.getElementById("bookContainer");
        console.log(bookContainer);
        await this.getAllBooks();
        this.setUpEventHandlers();
    }
    async getAllBooks() {
        const books = await this.#bookRepo.readAll();
        for (let book of books) {
            BookDOM.createBookCard(book);
        }
    }

    setUpEventHandlers() {
        document.addEventListener('click', async (e) => {
            const detailsBtn = e.target.closest('.details-btn');
            if (detailsBtn) {
                const bookId = parseInt(detailsBtn.getAttribute('data-book-id'));
                const book = await this.#bookRepo.read(bookId);
                console.log(book);
                this.#bookDetailsModal.show();
                BookDOM.populateBookDetailsModal(book);
            }
        });

        document.addEventListener('click', async (e) => {
            const addBtn = e.target.closest('.add-author-btn');
            if (addBtn) {
                const bookAttr = addBtn.getAttribute('data-book-id');
                this.#bookDetailsModal.hide();
                this.#authorModal.show();
                document.getElementById('bookId').value = bookAttr;
                this.#authorModal.show();
            }
        });

        document.addEventListener('submit', async (e) => {
            e.preventDefault();
            const addBtn = document.getElementById('submitAuthModal');
            const authorModalConfirmed = addBtn.textContent.trim().includes('Add Author');
            if (authorModalConfirmed) {
                const authorForm = document.getElementById('addAuthorForm');
                const form = new FormData(authorForm);
                await this.#bookRepo.addAuthor(form);
                authorForm.reset();
                const bookContainer = document.getElementById("bookContainer");
                bookContainer.innerHTML = '';
                await this.getAllBooks();
                this.#authorModal.hide();
            }
        });
    }
}

export class BookDOM {
    static createBookCard(book) {
        const outerDiv = document.createElement("div");
        outerDiv.className = "col";
        outerDiv.id = `book-${book.id}`;
        const shadDiv = document.createElement("div");
        shadDiv.className = "card h-100 shadow-sm";
        shadDiv.innerHTML = `
            <div class="card-body">
                <h5 class="card-title">${book.title}</h5>
                <p class="card-text text-muted">
                    <small>Published: ${book.publicationYear}</small>
                    </br>
                    <small>Number of Authors: ${book.authors.length}</small>
                </p>
            </div>
            <div class="card-footer bg-white border-0 d-flex gap-2 justify-content-end">
                <button class="btn btn-sm btn-outline-info details-btn" data-book-id="${book.id}">
                    <i class="bi bi-info"></i> Details
                </button>
                <button class="btn btn-sm btn-outline-warning edit-btn" data-book-id="${book.id}">
                    <i class="bi bi-pencil"></i> Edit
                </button>
                <button class="btn btn-sm btn-outline-danger delete-btn" data-book-id="${book.id}">
                    <i class="bi bi-trash"></i> Delete
                </button>
            </div>
            `;
        outerDiv.appendChild(shadDiv);
        const container = document.getElementById("bookContainer");
        container.appendChild(outerDiv);
    }

    static populateBookDetailsModal(book) {
        document.getElementById('bookTitle').textContent = book.title;
        document.getElementById('bookPublicationYear').textContent = book.publicationYear;
        document.getElementById('numberOfAuthors').textContent = book.authors.length;
        const addBtn= document.querySelector('.add-author-btn');
        addBtn.setAttribute('data-book-id', book.id);
        const authContainer = document.getElementById('bookAuthors');
        authContainer.innerHTML = "";
        for (let auth of book.authors) {
            BookDOM.createAuthorRow(auth);
        }
    }

    static createAuthorRow(author) {
        const tableRow = document.createElement('tr');
        tableRow.innerHTML = `
        <td>${author.id}</td>
        <td>${author.firstName} ${author.lastName}</td>
        `;
        const container = document.getElementById('bookAuthors');
        container.appendChild(tableRow);
    }
}

class BookAJAXRepository {
    #baseAddress;

    constructor(address) {
        this.#baseAddress = address;
    }

    async readAll() {
        const address = `${this.#baseAddress}/api/bookapi/all`;
        const response = await fetch(address);
        if (!response.ok) {
            throw new Error("There was an HTTP error getting the book data.");
        }
        return await response.json();
    }

    async read(id) {
        const address = `${this.#baseAddress}/api/bookapi/one/${id}`;
        const response = await fetch(address);
        if (!response.ok) {
            throw new Error("There was an HTTP error getting the book data.");
        }
        return await response.json();
    }

    async addAuthor(formData) {
        const address = `${this.#baseAddress}/api/bookapi/author/add`;
        const response = await fetch(address, {
            method: 'post',
            body: formData
        });
        if (!response.ok) {
            throw new Error('There was an HTTP error creating the author data');
        }
        return await response.json();
    }
}

const main = new Main();
await main.run();
