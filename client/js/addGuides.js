document.getElementById('guide-form').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevent the default form submission

    // Get form values
    const name = document.getElementById('guide-name').value;
    const email = document.getElementById('guide-email').value;
    const password = document.getElementById('guide-password').value;
    const dob = document.getElementById('guide-dob').value;
    const joiningDate = document.getElementById('guide-joining-date').value;

    // Create a guide object with form values
    const guide = {
        fullName: name,
        email: email,
        password: password,
        dateOfBirth: dob,
        joiningDate: joiningDate
    };

    // Call the function to add a guide
    addGuide(guide);
});

function addGuide(guide) {
    fetch('http://localhost:5294/api/Guide', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(guide),
    })
    .then(response => {
        if (!response.ok) {
            console.error('HTTP error! Status:', response.status);
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then(responseData => {
        console.log('Guide added successfully:', responseData);
        // Optionally, you can redirect to another page or update the UI
    })
    .catch(error => console.error('Error adding guide:', error));
}
