document.addEventListener('DOMContentLoaded', () => {
    const professions = new Set();

    const updateDisplayMessages = () => {
        const errormessages = document.querySelectorAll('.message');
        const displaymessages = document.querySelector('.displaymessages');

        // Clear existing messages
        while (displaymessages.firstChild) {
            displaymessages.removeChild(displaymessages.firstChild);
        }

        // Add current error messages
        errormessages.forEach(errormessage => {
            if (errormessage.innerHTML.trim() === '') {
                return;
            }
            const ptag = document.createElement('p');
            ptag.classList.add(errormessage.classList.item(0));
            ptag.classList.add('message');
            ptag.innerHTML = errormessage.innerHTML;
            displaymessages.appendChild(ptag);
        });
    };

    const validateField = (input) => {
        const value = input.value.trim();
        let isValid = true;
        const errormessage = document.querySelector(`.error${input.id}`);

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
                isValid = value !== '';
                if (isValid) {
                    const dob = new Date(value);
                    const age = new Date().getFullYear() - dob.getFullYear();
                    if (age === 0) {
                        isValid = false;
                    } else {
                        const ageinput = document.getElementById('age');
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

        if (!isValid) {
            input.classList.add('error');
            input.classList.remove('active');
        } else {
            input.classList.remove('error');
            input.classList.add('active');
        }

        return isValid;
    };

    const attachValidationEvent = (id, errorMessage, validationFunction) => {
        const input = document.getElementById(id);
        input.addEventListener('blur', () => {
            const isValid = validationFunction(input);
            const errormessage = document.querySelector(`.error${id}`);
            if (!isValid) {
                errormessage.style.color = 'red';
                errormessage.innerHTML = errorMessage;
            } else {
                errormessage.innerHTML = '';
            }
            updateDisplayMessages();
        });
    };

    attachValidationEvent('name', "Name cannot be empty !!", validateField);
    attachValidationEvent('mail', "Invalid Mail format!!", validateField);
    attachValidationEvent('phone', "Invalid Phone number (must be 10 digits)", validateField);
    attachValidationEvent('dob', "Dob is invalid (check the year)!!", validateField);
    attachValidationEvent('Profession', "Profession is invalid !!", validateField);
});
