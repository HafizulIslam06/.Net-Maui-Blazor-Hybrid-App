
// Get all input fields and textarea
const inputs = document.querySelectorAll('input, textarea');

// Add focus and blur event listeners to each input
inputs.forEach(input => {
    input.addEventListener('focus', () => {
        // Change background color of parent div when input is focused
        input.closest('.auth-signin').style.backgroundColor = 'lightblue';
    });

    input.addEventListener('blur', () => {
        // Revert background color of parent div when input loses focus
        input.closest('.auth-signin').style.backgroundColor = 'white';
    });
});