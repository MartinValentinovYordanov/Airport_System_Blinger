// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('scroll', reveal);
function reveal() {
    var reveals = document.querySelectorAll('.reveal')
    for (var i = 0; i < reveals.length; i++) {
        var windowheight = window.innerHeight;
        var revealtop = reveals[i].getBoundingClientRect().top;
        var revealpoint = 150;

        if (revealtop < windowheight - revealpoint) {
            reveals[i].classList.add('active');
        } else {
            reveals[i].classList.remove('active');
        }
    }
}



function openNav() {
   document.getElementById("mySidenav").style.width = "250px";
}

function closeNav() {
    document.getElementById("mySidenav").style.width = "0px";
}


var GetPortId1 = () => {
    let firstFormControl = document.getElementById('form-control1');
    let secondFormControlOptions = Array.from(document.getElementById('form-control2').options);
    secondFormControlOptions.forEach(o => {
        o.hidden = false;
        o.disabled = false;
    });
    secondFormControlOptions[firstFormControl.selectedIndex].hidden = true;
    secondFormControlOptions[firstFormControl.selectedIndex].disabled = true;
}