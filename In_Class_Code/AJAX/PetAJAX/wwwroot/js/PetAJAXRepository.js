'use strict'; 

export class PetAJAXRepository {
    #baseAddress;

    constructor(baseAddress) {
        this.#baseAddress = baseAddress;
    }

    // Read All
    // Given: Nothing
    // Returns: Colection of Pets
    // 1. Send the GET request
    // 2. Await response
    // 3. Check for errors
    // 4. Return the collection
    async readAll() {
        const address = `${this.#baseAddress}/all`;
        const response = await fetch(address);
        if (!response.ok) {
            throw new Error("There was an HTTP error getting the Pet data.");
        }
        return await response.json();
    }

    // Create 
    // Given: pet form data
    // Returns: created pet as json
    // 1. Encode form data
    // 2. Send POST request
    // 3. Check for errors
    // 4. Return the created pet as JSON
    async create(formData) {
        const address = `${this.#baseAddress}/create`;
        const response = await fetch(address, {
            method: 'post',
            body: formData
        });
        if (!response.ok) {
            throw new Error('There was an HTTP error creating the pet data');
        }
        return await response.json();
    }

    // Read
    // Given: pet id
    // Returns: pet as json
    // 1. Send GET request 
    // 2. Await response
    // 3. Check for errors
    // 4. Return the pet as json
    async read(id) {
        const address = `${this.#baseAddress}/one/${id}`;
        const response = await fetch(address);
        if (!response.ok) {
            throw new Error('There was an HTTP error getting the pet data');
        }
        return await response.json();
    }

    // Update
    // Given: pet form data
    // Returns: no content
    // 1. Encode form data
    // 2. Send PUT request
    // 3. Check for errors
    // 4. return no content (text)
    async update(formData) {
        const address = `${this.#baseAddress}/update`;
        const response = await fetch(address, {
            method: 'put',
            body: formData
        });
        if (!response.ok) {
            throw new Error('There was an HTTP error updating the pet data.');
        }
        return await response.text();
    }


    // Delete
    // Given: pet id
    // Returns: No Content
    // 1. Send Delete request
    // 2. Check for errors
    // 3. Return no content
    async delete(id) {
        const address = `${this.#baseAddress}/delete/${id}`;
        const response = await fetch(address, {
            method: 'delete'
        });
        if (!response.ok) {
            throw new Error('There was an HTTP error deleting the pet data.');
        }
        return await response.text();
    }
}