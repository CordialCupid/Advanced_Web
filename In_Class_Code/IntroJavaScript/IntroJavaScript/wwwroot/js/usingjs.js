'use strict';

console.log("Naming Identifiers");
let tax = 1.4;
let tax2 = 3.4;
let $tax3 = 5.6; // avoid using dollar sign
let _tax4 = 7.8;

console.log(`tax = ${tax}, tax2 = ${tax2}, $tax3 = ${$tax3}, _tax4 = ${_tax4}`);

console.log('\nObject Initializer');
let o1 = {};
let o2 = {name: "Mason", age: 23, grades: ['A', 'B', 'C']};
console.log(o1); //{}
console.log(o2); // o2 object
console.log(o2.name); // "Mason"
console.log(o2["name"]); // "Mason"
console.log(o2.grades[1]); // "B"

///////////////////////////////////////// WAYS TO INITIALIZE A FUNCTION
console.log("\nFunctions");

sayHello('Mason');
// FUNCTION DEFINITION
function sayHello(name){
    console.log("Hello, " + name + "!");
}

// sayHello2('Lauren') here will throw an error

// FUNCTION EXPRESSIONS
let sayHello2 = function(name){
    console.log("Hello, " + name + "!!");
};

sayHello2('Lauren'); // With function expressions, it must be called ONLY after it is initialized

// ARROW FUNCTIONS
let sayHello3 = (name) => {
    console.log("Hello, " + name + "!!!"); // just like function expression, this can also only be used AFTER it is initialized
};

sayHello3('Benny, Jack, and Mosley');

// This is a self-invoking function to create a localized scope. 'Self-invoking means to define and call at the same time'
(function _selfInvoking(){
    console.log("Self-invoking function");
})() // add parentheses around function, and add open-close after

////////////////////////////////////////// ARRAYS 
console.log("\nArrays"); // not arrays in typical sense, internally it is more like a hashmap or list
let fruits = ["apple", "banana", "cherry"];
let mixed = [42, "hello", true, null];
let scores = [];

console.log(fruits);
console.log(fruits[0]);
console.log(mixed[2]);
console.log(mixed.length);

let fruits2 = ["apple", "banana"];
console.log(fruits2);
fruits2.push("cherry"); // appends cherry to end of array
console.log(fruits2);
fruits2.pop(); // removes last element
console.log(fruits2);
fruits2.unshift("mango"); // prepends mango to front of array
console.log(fruits2);
fruits2.shift(); // removes first element in array
console.log(fruits2);

console.log(fruits2.includes("apple")); // returns boolean indicating if value is inside of an array
console.log(fruits2.indexOf("banana"));

for(let i = 0; i < fruits.length; i++) {
    console.log(fruits[i]);
}

for(let fruit of fruits) { // for of 
    console.log(fruit);
}

fruits.forEach((fruit) => { // "functional" way of doing a for of loop
    console.log(fruit);
});

// Transforming Arrays
let numbers = [1, 2, 3, 4, 5];

let doubled = numbers.map((n) => { // transforms whole array, in this case by doubling each element
    return n * 2;
});
console.log(doubled);

let numbers2 = [1, 2, 3, 4, 5, 6];
let evens = numbers2.filter((n) => {
    return n % 2 === 0; // triple === is used with data type in consideration, double == converts them to the same type; usually use triple in this situation
});
console.log(evens);

let total = numbers.reduce((accumulator, n) => {
    return accumulator + n;
}, 0);
console.log(total);

let students = [
    {name: "Alice", grade: 88},
    {name: "Bob", grade: 74},
    {name: "Carol", grade: 95}
];

let names = students.map((student) => {
    return student.name;
});
console.log(names);

let passing = students.filter((student) => {
    return student.grade >= 75;
});
console.log(passing);

let distinctions = students.reduce((count, student) => {
    return student.grade >= 90 ? count + 1 : count;
});