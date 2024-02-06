function addUser() {
    // Get form data
    const name = document.getElementById('name').value;
    const dob = document.getElementById('dob').value;
    const gender = document.getElementById('gender').value;
    const email = document.getElementById('email').value;
    const password = document.getElementById('password').value;
    const role = document.getElementById('role').value;

    // Create a user object
    const newUser = {
        name: name,
        dateOfBirth: dob,
        gender: gender,
        email: email,
        password: password,
        role: role
    };

    // Send a POST request to your API endpoint
    fetch('/api/User', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newUser)
    })
    .then(response => response.json())
    .then(data => {
        // Handle the response data (optional)
        console.log('User created:', data);
        // You can update the UI or perform additional actions here
    })
    .catch(error => {
        console.error('Error creating user:', error);
        // Handle errors
    });
}
