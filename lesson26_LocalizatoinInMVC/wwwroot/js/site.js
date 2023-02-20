// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.ajax-link').click(async e => {
    e.preventDefault();

    let element = e.target;
    let link = element.getAttribute('href');

    await $.ajax(link);
})
