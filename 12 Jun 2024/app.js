// function checkingEvenNumbers(num)
// {
//     return num%2==0
// }


// function filteringEvenNumbers(numbers,callbackFunc)
// {
//     let numberArray=[]
//     for(let value of numbers)
//     {
//         if(callbackFunc(value))
//             numberArray.push(value)
//     }
//     return () => console.log(numberArray);
// }

// let arrayOfNumbers=[22,45,99,3,8,44]
// let ans = filteringEvenNumbers(arrayOfNumbers,checkingEvenNumbers);
// // ans()



var dateDisplay=()=>{
    console.log(Date());
    document.getElementById('demo').innerHTML=" "+Date();
}

var func1 = () => {
    console.log("hello");
    let div2 = document.querySelectorAll(".div1");
    console.log(div2);
};

