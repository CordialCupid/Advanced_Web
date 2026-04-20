'use strict'; 

import {Shape, Rectangle, Circle} from './Shapes.js';

let shapes = [
    new Shape("Generic"), 
    new Rectangle(2,3),
    new Circle(10),
    new Rectangle(5.6, 90.1)
];

for (let i = 0; i < shapes.length; i++){
    console.log(shapes[i].getName());
    console.log(shapes[i].getArea?.()); // '?' used for if specific shape does not have a 'getArea' method, will be undefined
}