// home.js
const appDiv = document.getElementById('app');

function navigateToHome() {
    appDiv.innerHTML = '';

    fetch('/index.html')  // Update the path to your actual home page file
        .then(response => response.text())
        .then(html => {
            appDiv.innerHTML = html;
        });
}

// Example: navigate to the home page when the app starts
navigateToHome();
