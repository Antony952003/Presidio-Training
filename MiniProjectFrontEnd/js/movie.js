document.addEventListener('DOMContentLoaded' , () => {
    var locationdown = document.querySelector('.down-button');
    locationdown.addEventListener('click', () => {
        var popuplocation = document.querySelector('.popup-location');
        if(popuplocation.classList.contains('active')){
            document.querySelector('.container').style.opacity = '1.0';
            popuplocation.classList.remove('active');
        }
        else{
            document.querySelector('.container').style.opacity = '0.3';
            popuplocation.classList.add('active');
        }
    })


    const cityButtons = document.querySelectorAll('.pcities button');
    const locationSpan = document.querySelector('.location span');

    cityButtons.forEach(button => {
        button.addEventListener('click', () => {
            var popuplocation = document.querySelector('.popup-location');
            document.querySelector('.container').style.opacity = '1.0';
            popuplocation.classList.remove('active');
            locationSpan.innerHTML = button.innerHTML;
        });
    });
})