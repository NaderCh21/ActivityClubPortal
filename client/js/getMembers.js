document.getElementById('fetch-companies').addEventListener('click', fetchMembers);

function fetchMembers() {
    fetch('http://localhost:5294/api/Member')
        .then(response => {
            if (!response.ok) {
                console.error('HTTP error! Status:', response.status);
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(responseData => {
            // Check if the response contains $values array
            const members = responseData.$values || [];

            // Clear existing table rows
            document.getElementById('company-table').querySelector('tbody').innerHTML = '';

            // Populate the table with member data
            members.forEach(member => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${member.memberId}</td>
                    <td>${member.fullName}</td>
                    <td>${member.email}</td>
                    <td>${member.password}</td>
                    <td>${member.dateOfBirth}</td>
                    <td>${member.gender}</td>
                    <td>${member.joiningDate}</td>
                    <td>${member.mobileNumber}</td>
                    <td>${member.emergencyNumber}</td>
                    <td>${member.photo}</td>
                    <td>${member.profession}</td>
                    <td>${member.nationality}</td>
                `;
                document.getElementById('company-table').querySelector('tbody').appendChild(row);
            });
        })
        .catch(error => console.error('Error fetching members:', error));
}
