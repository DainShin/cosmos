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
