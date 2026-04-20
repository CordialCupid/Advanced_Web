'use strict';

class Rectangle{
    constructor(length, width) {
        this.length = length;
        this.width = width;
    }

    // Method
    getArea(){
        return this.length * this.width;
    }

    // Getter - begins with get
    get area(){
        return this.getArea();
    }
}

Rectangle.prototype.getPerimeter = function _getPerimeter(){ // can be used to override methods and behaviors of classes - very dangerous
    return 2 * (this.length + this.width);
};

export { Rectangle };