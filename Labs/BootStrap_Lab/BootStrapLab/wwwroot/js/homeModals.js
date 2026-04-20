'use strict';

const petModalDOM = document.getElementById('petModal');
const createPetBtn = document.getElementById('createPetBtn');
const petModal = new bootstrap.Modal(petModalDOM);

createPetBtn.addEventListener('click', () => {
    petModal.show();
});

const createPetForm = document.querySelector("#createPetForm");
createPetForm.addEventListener("submit", async (event) => {
    event.preventDefault();
    try {
        await submitWithAjax(createPetForm);
    }
    catch (error) {
        console.error(error);
    }
});

async function submitWithAjax(createPetForm) {
    const url = createPetForm.getAttribute('action');
    const method = createPetForm.getAttribute('method');
    const formData = new FormData(createPetForm);

    const response = await fetch(url, {
        method: method, body: formData
    });
    if (response.ok == false) {
        throw new Error("There was an HTTP error!");
    }
    const result = await response.json();
    if (result === "fail") {
        throw new Error("Failed to save the pet data!");
    }
    console.log(result);
    petModal.hide();
}
