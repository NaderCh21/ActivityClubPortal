document.getElementById('fetch-users').addEventListener('click', fetchUsers);

function fetchUsers() {
    fetch('http://localhost:5294/api/User')
        .then(response => {
            if (!response.ok) {
                console.error('HTTP error! Status:', response.status);
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(responseData => {
            // Check if the response contains $values array
            const users = responseData.$values || [];

            // Clear existing table rows
            document.getElementById('user-table-body').innerHTML = '';
            console.log(users);
            // Populate the table with user data
            users.forEach(user => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${user.userId}</td>
                    <td>${user.name}</td>
                    <td>${user.dateOfBirth}</td>
                    <td>${user.gender}</td>
                    <td>${user.email}</td>
                    <td>${user.password}</td>
                    <td>${user.role}</td>
                `;
                document.getElementById('user-table-body').appendChild(row);
            });
        })
        .catch(error => console.error('Error fetching users:', error));
}
        