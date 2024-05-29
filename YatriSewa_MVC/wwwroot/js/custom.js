/*
Template Name: OsahanBus - Bus Booking HTML Mobile Template
Author: Askbootstrap
Author URI: https://themeforest.net/user/askbootstrap
Version: 0.1
*/

(function ($) {
    "use strict"; // Start of use strict

    // Tooltip
    $('[data-toggle="tooltip"]').tooltip();

    // Osahan Slider
    $('.osahan-slider').slick({
        infinite: true,
        autoplay: true,
        autoplaySpeed: 5000,
        centerMode: false,
        slidesToShow: 1,
        arrows: false,
        dots: true
    });

    // Sidebar Nav
    var $main_nav = $('#main-nav');
    var $toggle = $('.toggle');

    var defaultOptions = {
        disableAt: false,
        customToggle: $toggle,
        levelSpacing: 40,
        navTitle: '',
        levelTitles: true,
        levelTitleAsBack: true,
        pushContent: '#container',
        insertClose: 2
    };

    // call our plugin
    var Nav = $main_nav.hcOffcanvasNav(defaultOptions);

    // Select2
    $('.js-example-basic-single').select2();


})(jQuery); // End of use strict


// ==========index========

function redirectAfterDelay() {
    setTimeout(function () {
        window.location.href = "Landing";
    },
        1000); // 2 seconds in milliseconds 
};

// =======signup.js=======

//function checkPasswords() {
//    var password = document.getElementById("password").value;
//    var confirmPassword = document.getElementById("confirmPassword").value;
//    var errorDiv = document.getElementById("passwordMatchError");

//    if (password !== confirmPassword) {
//        errorDiv.style.display = "block";
//    } else {
//        errorDiv.style.display = "none";
//        document.getElementById("signupForm").submit();
//    }
//};

//=============   ================
function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

function passwordlength(password) {

}

function checkPasswords() {
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword").value;
    var email = document.getElementById("email").value; 
    var errorDiv = document.getElementById("passwordMatchError");
    var emailErrorDiv = document.getElementById("emailError");
    var nullErrorDiv = document.getElementById("nullError");
    var errorMessageDiv = document.getElementById("errorMessage");

    if (!email || !password || !confirmPassword) {
        nullErrorDiv.style.display = "block";
        return false;
    }
    else if (password.length <= 5) {
        errorMessageDiv.innerHTML = "Password must be at least 6 characters long.";
        return false;
    }
    else if (password != confirmPassword) {
        errorDiv.style.display = "block";
        return false;
    } 
    else if (!validateEmail(email)) {
        emailErrorDiv.style.display = "block";
        return false;
    }
    else {
        errorMessageDiv.innerHTML = "";
        errorDiv.style.display = "none";
        emailErrorDiv.style.display = "none";
        nullErrorDiv.style.display = "none";
        document.getElementById("signupForm").action ="/Yatri/Home";
        document.getElementById("signupForm").submit();
        return true;
    }
}

// Event listener for form submission
document.getElementById("signupForm").addEventListener("submit", function (event) {
    if (!checkPasswords()) {
        // Prevent form submission if passwords don't match
        event.preventDefault();
    }
});


function updateSeatSelection(checkbox, seatCost) {
    var seatNumber = checkbox.value;
    if (checkbox.checked) {
        totalCost += seatCost;
        selectedSeatsCount++;
    } else {
        totalCost -= seatCost;
        selectedSeatsCount--;
    }

    // Update the total cost and selected seats count display
    document.getElementById("totalAmount").textContent = totalCost.toFixed(2);
    document.getElementById("selectedSeatsCount").textContent = selectedSeatsCount;

    // Enable/disable the "Next" button based on seat selection
    var nextButton = document.querySelector(".osahanbus-btn");
    nextButton.disabled = selectedSeatsCount === 0;
}
