/*
Classes in JS are created in 3 different ways:
Using singleton object 
Using function keyword: Traditional way of creating classes. 
Using class keyword: From ES 6
*/
////////////////Example for Singleton objects/////////////////////////
// const emp = {};//singleton object. 
// emp.empId = 123;
// emp.empName = "Phaniraj"
// emp.empAddress = "Bangalore";
// for(const key in emp){
//     console.log(`${key}: ${emp[key]}`)
// }
// console.log(emp);

// const copy = emp;
// copy.empName = "Vinod kumar";
// console.log(emp.empName);
/////////////////////////////////////////////////////////////////////////////
////////////////////////Using function keyword to create a class/////////////
const employee = function(id, name, address){
    this.empId = id;
    this.empName = name;
    this.empAddress = address;
    this.display = function(){
        alert("Name: " + this.empName)
    }
}

const emp1 = new employee(123, "Name", "Address");
//emp1.display();

const emp2 = new employee(124, "Vinod", "Shimoga");
//emp2.display(); 
///////////////////////////ES6 version of class creation////////////////
class Customer{
    constructor(id, name, address){
        this.id = id;
        this.name = name;
        this.address = address;
    }
}

let cst = new Customer(123, "Phaniraj", "Bangalore");
let cst2 = new Customer(124, "Prakash", "Mysore");
//alert("The class object: " + cst.name);
//alert("The class object: " + cst2.name);
///////////////////////////////////////////////////////////////////
class SampleClass{
    constructor(){
        this.value = 123;
    }
}
class CustomerDatabase{
    constructor(){
        this.data = [];
    }
    
    addRecord(row){
        console.log(this.value)
        this.data.push(row)
    }

    findRecord(id) {
        return this.data.find((row)=>row.id == id);
    }

    removeRecord(id){
        for (const key in this.data) {
            if (this.data[key].id == id){
                this.data.splice(key, 1);
                return;
            }
        }
        throw "Record not found to remove"
    }

    updateRecord(id, row){
        throw "Do It URSelf!!!";
    }
}