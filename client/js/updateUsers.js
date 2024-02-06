function updateUser() {
    // Retrieve userId from the input field
    const userId = document.getElementById('userId').value;

    // Retrieve other user details from the form
    const name = document.getElementById('name').value;
    const dob = document.getElementById('dob').value;
    const gender = document.getElementById('gender').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const role = document.getElementById('role').value;

    // Create a user object with the updated details
    const updatedUser = {
        userId: parseInt(userId), // Ensure userId is a number
        name: name,
        dateOfBirth: dob,
        gender: gender,
        email: email,
        password: password,
        role: role
    };

    // Perform the update using fetch
    fetch(`http://localhost:5294/api/User/${userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedUser),
    })
    .then(response => {
        if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
        }
        return response.json();
    })
    .then(updatedUser => {
        console.log('User updated:', updatedUser);
        // Handle success, e.g., show a success message
    })
    .catch(error => {
        console.error('Error updating user:', error);
        // Handle error, e.g., show an error message
    });
}
