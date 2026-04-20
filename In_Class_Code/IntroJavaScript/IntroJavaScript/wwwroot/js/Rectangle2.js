'use strict'; 

class Rectangle2{
    #length = 0; // used to declare private attributes in js, also enforces private
    #width = 0;

    constructor(length, width){
        this.#length = length;
        this.#width = width;
    }

    getArea() { // can also # to beginning of method name to make it private
        return this.#length * this.#width;
    }

    set length(length){
        this.#length = length; // setter for length
    }

    set width(width) {
        this.#width = width;
    }

    get length() {
        return this.#length;
    }

    get width() {
        return this.#width;
    }

    get area() {
        return this.getArea();
    }
}

Rectangle2.prototype.getPerimeter = function _getPerimeter(){
    return 2 * (this.length * this.width) // in prototype, you only have access to the public fields
}

export { Rectangle2 };