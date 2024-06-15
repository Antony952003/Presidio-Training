

document.addEventListener('DOMContentLoaded', () => {
    var errormessages = document.querySelectorAll('.message');
    console.log(errormessages);
    var displaymessages = document.querySelector('.displaymessages');
    for(var errormessage in errormessages){
        if(errormessage.innerHTML === undefined){
            continue;
        }
        var ptag = document.createElement('p');
        ptag.innerHTML = errormessage.innerHTML;
        displaymessages.appendChild(ptag);
    }
})

document.addEventListener('DOMContentLoaded', () => {


    var name = document.getElementById('name');
    name.addEventListener('blur' , () => {
        var isValid = validateField(name);
        var errormessage = document.querySelector(`.error${name.id}`);
        if(!isValid){
            errormessage.style.color = 'red';
            errormessage.innerHTML = "Name cannot be empty !!";
        }
        else{
            errormessage.innerHTML = '';
        }
    })
    var mail = document.getElementById('mail');
    mail.addEventListener('blur' , () => {
        var isValid = validateField(mail);
        var errormessage = document.querySelector(`.error${mail.id}`);
        if(!isValid){
            errormessage.style.color = 'red';
            errormessage.innerHTML = "Invalid Mail format!!";
        }
        else{
            errormessage.innerHTML = '';
        }
    })
    var phone = document.getElementById('phone');
    phone.addEventListener('blur' , () => {
        var isValid = validateField(phone);
        var errormessage = document.querySelector(`.error${phone.id}`);
        if(!isValid){
            errormessage.style.color = 'red';
            errormessage.innerHTML = "Invalid Phone number (must be 10 digits)";
        }
        else{
            errormessage.innerHTML = '';
        }
    })
    var dob = document.getElementById('dob');
    dob.addEventListener('blur' , () => {
        var isValid = validateField(dob);
        var errormessage = document.querySelector(`.error${dob.id}`);
        if(!isValid){
            errormessage.style.color = 'red';
            errormessage.innerHTML = "Dob is invalid (chack the year)!!";
        }
        else{
            errormessage.innerHTML = '';
        }
    })
    var profession = document.getElementById('Profession');
    profession.addEventListener('blur' , () => {
        var isValid = validateField(profession);
        var errormessage = document.querySelector(`.error${profession.id}`);
        if(!isValid){
            errormessage.style.color = 'red';
            errormessage.innerHTML = "Profession is invalid !!";
        }
        else{
            errormessage.innerHTML = '';
        }
    })
    


    const validateField = (input) => {
        const value = input.value.trim();
        let isValid = true;

        switch (input.id) {
            case 'name':
                isValid = value !== '';
                break;
            case 'mail':
                isValid = /\S+@\S+\.\S+/.test(value);
                break;
            case 'phone':
                isValid = /^[0-9]{10}$/.test(value);
                break;
            case 'dob':
                console.log("dob");
                isValid = value !== '';
                if (isValid) {
                    const dob = new Date(value);
                    const age = new Date().getFullYear() - dob.getFullYear();
                    if(age === 0){
                        console.log('notvalid')
                        isValid = false;
                    }
                    else{
                        console.log('valid here')
                        var ageinput = document.getElementById('age');
                        ageinput.value = age;
                    }
                }
                break;
            case 'profession':
                isValid = value !== '';
                if (!professions.has(value)) {
                    professions.add(value);
                    const dataList = document.getElementById('professions');
                    const option = document.createElement('option');
                    option.value = value;
                    dataList.appendChild(option);
                }
                break;
        }
        if(!isValid){
            console.log(`error${input.id}`);
            input.classList.add('error');
            input.classList.remove('active');
        }
        else{
            input.classList.remove('error');
            input.classList.add('active');
        }
        return isValid;
    }
})