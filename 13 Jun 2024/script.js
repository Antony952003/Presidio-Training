        document.getElementById('id').addEventListener('input', validateId);
        document.getElementById('name').addEventListener('input', validateName);
        document.getElementById('price').addEventListener('input', validatePrice);
        document.getElementById('quantity').addEventListener('input', validateQuantity);

        function validateId() {
            let idInput = document.getElementById('id');
            if (idInput.value.trim() === '') {
                markAsInvalid(idInput);
            } else {
                markAsValid(idInput);
            }
        }

        function validateName() {
            let nameInput = document.getElementById('name');
            if (nameInput.value.trim() === '') {
                markAsInvalid(nameInput);
            } else {
                markAsValid(nameInput);
            }
        }

        function validatePrice() {
            let priceInput = document.getElementById('price');
            if (priceInput.value.trim() === '' || isNaN(priceInput.value) || (quantityInput.value < 0)) {
                markAsInvalid(priceInput);
            } else {
                markAsValid(priceInput);
            }
        }

        function validateQuantity() {
            let quantityInput = document.getElementById('quantity');
            if (quantityInput.value.trim() === '' || isNaN(quantityInput.value) || (quantityInput.value < 0)) {
                markAsInvalid(quantityInput);
            } else {
                markAsValid(quantityInput);
            }
        }

        function markAsInvalid(inputElement) {
            inputElement.classList.remove('valid');
            inputElement.classList.add('invalid');
        }

        function markAsValid(inputElement) {
            inputElement.classList.remove('invalid');
            inputElement.classList.add('valid');
        }

        var appendRecord = (event) => {
            event.preventDefault();

            
            var recordTable = document.querySelector('.record-table');
            var tbody = recordTable.lastElementChild;
            console.log(tbody);
            var firsttr = tbody.lastElementChild;
            console.log(firsttr)
            var previd = firsttr.firstElementChild.innerHTML;
            console.log(previd)

            var id = document.getElementById('id');
            var name = document.getElementById('name');
            var price = document.getElementById('price');
            var quantity = document.getElementById('quantity');
            if(id.classList.contains('invalid') || name.classList.contains('invalid')
                 || price.classList.contains('invalid') || quantity.classList.contains('invalid')){
                    window.alert("check the fields for some error!!!");
                }
                
            var newRow = document.createElement('tr');

            id = parseInt(previd) + 1;
            var newColumn = document.createElement('td');
            newColumn.innerHTML = id.value;
            newRow.appendChild(newColumn);

            newColumn = document.createElement('td');
            newColumn.innerHTML = name.value;
            newRow.appendChild(newColumn);

            newColumn = document.createElement('td');
            newColumn.innerHTML = '$'+price.value;
            newRow.appendChild(newColumn);

            newColumn = document.createElement('td');
            newColumn.innerHTML = quantity.value;
            newRow.appendChild(newColumn);

            recordTable.appendChild(newRow);
            id.value = '';
            name.value ='';
            price.value = '';
            quantity.value='';
        }