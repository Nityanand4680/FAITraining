//JS Code will be saved as files with extension .js.
//There are 2 ways to create a function. Named Function and Anonymous Functions. The shorter version of Anonymous functions are Lamdba Functions. 
//Named Function:
function addFunc(v1, v2){
    return v1 + v2;
}

//Anonymous function that is assigned to a const. the const name becomes the name of the function. 
const subFunc = function(v1, v2){
    return v1 - v2;
}

//Shorter version of Anonymous function using Lambda Expression syntax. Lambda Expressions dont need function keyword and it uses => operator to define the function. 
const mulFunc = (v1, v2) => v1 * v2;

