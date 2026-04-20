'use strict';

export class DOMManipulator{
    #skillCount = 0;

    static demonstrateDOMSelectors(){
        console.log("DOM SELECTOR EXAMPLES");

        const form = document.querySelector('#jobApplicationForm'); // # is used to signify an element id; with this method, you dont need selector type
        console.log(form);

        const form2 = document.getElementById('jobApplicationForm'); // preference as to which one you want to use, query selecotr is broader and can handle more querying types
        console.log(form2);

        const allInputs = document.querySelectorAll('input'); // returns collection of all input elements
        console.log(allInputs);

        const formSections = document.querySelectorAll('.form-section h2'); // selecting by css class name
        console.log(formSections);
    };

    setUpEventListeners(){
        document.addEventListener('click', (e)=>{
            if (e.target.getAttribute('id') === 'addSkillBtn'){
                this.addSkillField();
            }
        });
    };

    addSkillField(){
        this.#skillCount += 1;

        const skillsContainer = document.getElementById('skillsContainer');

        const skillDiv = document.createElement('div');
        skillDiv.className = 'skill-item';
        skillDiv.setAttribute('data-skill-id', this.#skillCount);

        const label = document.createElement('label');
        label.setAttribute('for', `skill${this.#skillCount}`) // label for input
        label.textContent = `Skill ${this.#skillCount}`;

        const input = document.createElement('input');
        input.setAttribute('type', 'text');
        input.setAttribute('id', `skill${this.#skillCount}`);
        input.setAttribute('name', `skill${this.#skillCount}`); // name is used to transfer data from form
        input.setAttribute('placeholder', 'e.g. JavaScript, Project Management');

        const removeBtn = document.createElement('button');
        removeBtn.className = 'remove-btn remove-skill';
        removeBtn.textContent = 'Remove';
        removeBtn.setAttribute('type', 'button');

        skillDiv.appendChild(label);
        skillDiv.appendChild(input);
        skillDiv.appendChild(removeBtn);

        skillsContainer.appendChild(skillDiv);
    }
}