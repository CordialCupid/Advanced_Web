'use strict';

import { PetAJAXRepository } from "./PetAJAXRepository.js";
import { PetDOM } from "./PetDOM.js";

main();

async function main() {
    const petRepo = new PetAJAXRepository('http://localhost:5076/api/pet');

    PetDOM.showNoPetsMessage();
    PetDOM.createPetCard({ id: 1, name: 'Fred', weight: 34.2 });

    await setUpEventHandlers(petRepo);

    let pets = await petRepo.readAll();
    PetDOM.showPetCards(pets);

    // SHOWCASE DIFFERENT FUNCTIONS
    // await createTestData(petRepo);
    // await updateTestData(petRepo);
    // await petRepo.delete(1);

    // let pets = await petRepo.readAll();
    // console.log(pets);

    // // works
    // let pet = await petRepo.read(1);
    // console.log(pet);

    // // doesnt work (id doesnt exist in db)
    // pet = await petRepo.read(2);
    // console.log(pet);
}

async function setUpEventHandlers(petRepo) {
    const petForm = document.getElementById('petForm');
    petForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const submitBtn = document.getElementById('submitBtn');
        const isEditMode = submitBtn.textContent.trim().includes('Update');
        if (isEditMode === false) {
            await processCreatePet(petForm, petRepo);
        } else {
            await processEditPet(petForm, petRepo);
        }

        let pets = await petRepo.readAll();
        PetDOM.showPetCards(pets);
        PetDOM.resetForm();
        return false
    });

    document.addEventListener('click', async (e) => {
        const editBtn = e.target.closest('.edit-btn');
        if (editBtn) {
            const petId = parseInt(editBtn.getAttribute('data-pet-id'));
            let pet = await petRepo.read(petId);
            PetDOM.populateFormForEdit(pet);
        }
    });

    document.addEventListener('click', (e) => {
        if (e.target.getAttribute('id') === 'cancelBtn') {
            PetDOM.resetForm();
        }
    });

    document.addEventListener('click', async (e) => {
        if (e.target.closest('.delete-btn')) {
            const deleteBtn = e.target.closest('.delete-btn');
            const petId = parseInt(deleteBtn.getAttribute('data-pet-id'));
            let pet = await petRepo.read(petId);
            await deletePet(pet, petRepo);

            let pets = await petRepo.readAll();
            PetDOM.showPetCards(pets);
            PetDOM.resetForm();
            return false
        }
    });
}


async function createTestData(petRepo) {
    const formData = new FormData();
    formData.set('Id', 0);
    formData.set('Name', 'Fluffy');
    formData.set('Weight', 2.3);

    let pet = await petRepo.create(formData);
    console.log(pet);
}

async function updateTestData(petRepo) {
    const formData = new FormData();
    formData.set('Id', 1);
    formData.set('Name', 'Fluffyy');
    formData.set('Weight', 12.3);

    let result = await petRepo.update(formData);
    console.log(result);
}

async function processCreatePet(petForm, petRepo) {
    try {
        const formData = new FormData(petForm);
        await petRepo.create(formData);
    }
    catch (error) {
        console.error("An error occurred:", error.message);
    }
}

async function processEditPet(petForm, petRepo) {
    try {
        const formData = new FormData(petForm);
        await petRepo.update(formData);
    }
    catch (error) {
        console.error("An error occurred:", error.message);
    }
}

async function deletePet(pet, petRepo) {
    const confirmed = confirm(`Are you sure you want to delete "${pet.name}"?`);

    if (confirmed) {
        await petRepo.delete(pet.id);
    }
}



