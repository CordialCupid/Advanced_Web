'use strict';

export class PetDOM {
    static showNoPetsMessage() {
        const emptyState = document.querySelector('#emptyState');
        emptyState.computedStyleMap.display = 'block';
    }

    static hideNoPetsMessage() {
        const emptyState = document.querySelector('#emptyState');
        emptyState.computedStyleMap.display = 'none';
    }

    static createPetCard(pet) {
        const outerDiv = document.createElement('div');
        outerDiv.className = 'col';
        const shadowDiv = document.createElement('div');
        shadowDiv.className = 'card h-100 shadow-sm';
        outerDiv.appendChild(shadowDiv);
        shadowDiv.innerHTML = `
            <div class="card-body">
                <h5 class="card-title text-primary">${pet.name}</h5>
                <p class="card-text">
                    <strong>ID:</strong>${pet.id}<br>
                    <strong>Weight:</strong> ${pet.weight} lbs
                </p>
            </div>
            <div class="card-footer bg-transparent">
                <button class="btn btn-sm btn-outline-primary edit-btn" data-pet-id="${pet.id}">
                    <i class="bi bi-pencil"></i> Edit
                </button>
                <button class="btn btn-sm btn-outline-danger delete-btn" data-pet-id="${pet.id}">
                    <i class="bi bi-trash"></i> Delete
                </button>
            </div>
        `;
        const petCardsContainer = document.querySelector('#petCardsContainer');
        petCardsContainer.appendChild(outerDiv);
    }

    static showPetCards(pets) {
        const petCardsContainer = document.querySelector('#petCardsContainer');
        petCardsContainer.innerHTML = "";
        if (pets.length === 0) {
            PetDOM.showNoPetsMessage();
        } else {
            PetDOM.hideNoPetsMessage();
            pets.forEach(pet => {
                PetDOM.createPetCard(pet);
            });
        }
    }

    static resetForm() {
        // Reset all form fields to default values
        document.getElementById('petForm').reset();

        // Reset the hidden pet ID to 0 (for add mode)
        document.getElementById('Id').value = '0';

        // Update form heading back to "Add New Pet"
        document.querySelector('#form-title').innerHTML = '<i class="bi bi-plus-circle"></i> Add New Pet';

        // Update button text back to "Add Pet"
        document.getElementById('submitBtn').innerHTML = '<i class="bi bi-plus-lg"></i> Add Pet';

        // Hide the cancel button
        document.getElementById('cancelBtn').style.display = 'none';
    }

    static populateFormForEdit(pet) {
        // Populate form fields
        document.getElementById('Id').value = pet.id;
        document.getElementById('Name').value = pet.name;
        document.getElementById('Weight').value = pet.weight;

        // Update form heading
        document.querySelector('#form-title').innerHTML =
            '<i class="bi bi-pencil-square"></i> Edit Pet';

        // Update button text to "Update Pet"
        document.getElementById('submitBtn').innerHTML =
            '<i class="bi bi-pencil-square"></i> Update Pet';

        // Show the cancel button
        document.getElementById('cancelBtn').style.display = 'block';

        // Scroll to the form
        document.getElementById('petForm').scrollIntoView({ behavior: 'smooth', block: 'start' });
    }

}
