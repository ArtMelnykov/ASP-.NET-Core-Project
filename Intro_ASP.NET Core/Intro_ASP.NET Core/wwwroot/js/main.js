"use strict";

const emailLink = document.getElementById("emailLink");

emailLink.addEventListener("click", function(event) 
{
    event.preventDefault();
    alert("Email Added!");
})

const emailButton = document.getElementById("emailButton");

emailButton.addEventListener("click", function(event) 
{
    // If this button was triggering a mailto or form submit, you can prevent it:
    event.preventDefault();
    alert("Email popup is prevented!");
    // ... do whatever else you want here
});