'use strict';

class Shape{
    #name = "Shape";

    constructor(name) {
        this.setName() = name; // used this method becasue you might have validation inside the set name method
    }

    setName(name){
        this.#name = name;
    }

    getName(){
        return this.#name;
    }
}

class Rectangle extends Shape{ // 'extends' is used for shape inheritance
    #length = 0;
    #width = 0;

    constructor(length, width){
        super('Rectangle'); // super is used for calling base classes constructor and passing it a name

        this.#length = length;
        this.#width = width;
    }

    getArea(){
        return this.#length * this.#width;
    }

    getLength(){
        return this.#length;
    }

    getWidth(){
        return this.#width;
    }
}

class Circle extends Shape{
    #radius = 0;

    constructor(radius){
        super('Circle');
        this.#radius = radius;
    }

    getArea(){
        return Math.PI * (this.#radius * this.#radius);
    }

    getRadius(){
        return this.#radius;
    }
}

export {Shape, Rectangle, Circle}; // can also put export before class declaration for exporting