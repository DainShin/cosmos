// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Main navigation bar Sticky on scroll
let mainNav = document.querySelector('#main-navbar');
let secondaryNav = document.querySelector('#secondary-navbar');

let stickyPosition = mainNav.offsetTop;

function toggleSticky() {
	if(window.pageYOffset >= stickyPosition) {
		mainNav.classList.add('fixed-top');
	} else {
		mainNav.classList.remove('fixed-top');
	}
}	

window.onscroll = () => {toggleSticky()};

window.onresize = () => {stickyPosition = mainNav.offsetTop};


// 3D Card Effect
VanillaTilt.init(document.querySelector(".subscription-tier-ultimate"), {
	max: 15,
	speed: 250
});


// Popup
const popup = document.querySelector(".popup-wrapper");
const acceptBtn = document.querySelector(".popup-accept-btn");

// Check if the user has already clicked 'I understand'
if (localStorage.getItem('popupClosed') === 'true') {
	popup.style.display = 'none';
}

// Add event listener to the 'I understand' button
acceptBtn.addEventListener('click', function() {
	// Hide the popup
	 popup.style.display = 'none';
	// Set the item in localStorage so the popup doesn't show again
	localStorage.setItem('popupClosed', 'true');
});

document.addEventListener('DOMContentLoaded', function () {
    // Get all dropdown elements
    var dropdowns = document.querySelectorAll('.nav-item.dropdown');

    dropdowns.forEach(function (dropdown) {
        // Show the dropdown menu on hover
        dropdown.addEventListener('mouseover', function (e) {
            var dropdownMenu = dropdown.querySelector('.dropdown-menu');
            if (dropdownMenu) {
                new bootstrap.Dropdown(dropdownMenu).show();
            }
        });

        // Hide the dropdown menu when not hovered
        dropdown.addEventListener('mouseout', function (e) {
            var dropdownMenu = dropdown.querySelector('.dropdown-menu');
            if (dropdownMenu) {
                new bootstrap.Dropdown(dropdownMenu).hide();
            }
        });
    });
});