document.getElementById('company-form').addEventListener('submit', addMember);

function addMember(event) {
    event.preventDefault();

    // Fetch values from the form
    const name = document.getElementById('member-name').value;
    const email = document.getElementById('member-email').value;
    const password = document.getElementById('member-password').value;
    const dob = document.getElementById('member-dob').value;
    const gender = document.getElementById('member-gender').value;
    const joiningDate = document.getElementById('member-joining-date').value;
    const mobileNumber = document.getElementById('member-mobile-number').value;
    const emergencyNumber = document.getElementById('member-emergency-number').value;
    const photo = document.getElementById('member-photo').value;
    const profession = document.getElementById('member-profession').value;
    const nationality = document.getElementById('member-nationality').value;

    // Perform any additional validation if needed

    // Create an object with the form data
    const newMember = {
        name,
        email,
        password,
        dob,
        gender,
        joiningDate,
        mobileNumber,
        emergencyNumber,
        photo,
        profession,
        nationality
    };

    // Use fetch or your preferred method to send data to the server
    // For example:
    fetch('http://localhost:5294/api/Member', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newMember),
    })
    .then(response => {
        if (!response.ok) {
            console.error('HTTP error! Status:', response.status);
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then(responseData => {
        console.log('Member added successfully:', responseData);
        // Optionally, redirect to another page or update UI
    })
    .catch(error => console.error('Error adding member:', error));
}
