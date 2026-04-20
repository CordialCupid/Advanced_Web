'use strict';

import {Rectangle} from './Rectangle.js';
import {Rectangle2} from './Rectangle2.js';

let r1 = new Rectangle(2, 3);
let r2 = new Rectangle(6.7, 21.3); // you can declare variables without let or const, but it will put it in the global namespace which you want to avoid; can also use var but that will also put it in global
console.log(r1.getArea());
console.log(r1.area);
console.log(r2.getArea());
console.log(r2.area);
console.log(r1.getPerimeter());

let r3 = new Rectangle2(3,4);
let r4 = new Rectangle2(3.1, 4.2);
console.log(r3.getArea());
console.log(r4.area);
console.log(r3.getPerimeter());
//console.log(r3.#length); // ERROR due to trying to use private field

r4.length = 5.7; // using setter
console.log(r4.area)

