// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    const currentPath = window.location.pathname.toLowerCase();
    const navButtons = document.querySelectorAll('.control-btn');

    navButtons.forEach(btn => {
        btn.classList.remove('active');
        const href = btn.getAttribute('href');

        if (href === '/' && (currentPath === '/' || currentPath === '/home' || currentPath === '/home/index')) {
            btn.classList.add('active');
        } else if (href !== '/' && currentPath.includes(href.toLowerCase())) {
            btn.classList.add('active');
        }
    });
});

// Efecto de click
document.querySelectorAll('.control-btn').forEach(btn => {
    btn.addEventListener('click', function (e) {
        document.querySelectorAll('.control-btn').forEach(b => b.classList.remove('active'));
        this.classList.add('active');
    });
});