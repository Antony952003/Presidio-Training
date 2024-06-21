class Student {
    #name;
    #GPA;
    #studentId;
    #email;

    constructor(name, studentId, email) {
        this.#name = name;
        this.#studentId = studentId;
        this.#email = email;
    }

    getName() {
        return this.#name;
    }

    setName(name) {
        this.#name = name;
    }

    getStudentId() {
        return this.#studentId;
    }

    setStudentId(studentId) {
        this.#studentId = studentId;
    }

    getEmail() {
        return this.#email;
    }

    setEmail(email) {
        this.#email = email;
    }

    displayInfo() {
        console.log(`Student: ${this.#name}, Student ID: ${this.#studentId}, Email: ${this.#email}`);
    }
}


class StudentGpa extends Student{
    #gpa;
    constructor(name, studentId, email, gpa){
        super(name,studentId, email);
        this.#gpa = gpa;
    }
    getGpa() {
        return this.#gpa;
    }

    setGpa(gpa) {
        this.#gpa = gpa;
    }

    displayInfo() {
        console.log(`Student: ${this.getName()}, GPA: ${this.getGpa()}, Student ID: ${this.getStudentId()}, Email: ${this.getEmail()}`);
    }
}


class CStudent extends Student{
    constructor(name, studentId, email){
        super(name, studentId, email);
    }

    displayInfo(){
        console.log(`Student : ${this.getName()}, StudentId : ${this.getStudentId()}, email : ${this.getEmail()}`)
    }
}


const student1 = new CStudent('Mark', 'M1433', 'mark@gmail.com');
student1.displayInfo(); 
// console.log(student1.getGPA()); 

