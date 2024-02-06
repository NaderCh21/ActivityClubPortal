document.getElementById('fetch-guides').addEventListener('click', fetchGuides);

function fetchGuides() {
    fetch('http://localhost:5294/api/Guide')
        .then(response => {
            if (!response.ok) {
                console.error('HTTP error! Status:', response.status);
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(responseData => {
            // Check if the response contains $values array
            const guides = responseData.$values || [];

            // Clear existing table rows
            const guidesTableBody = document.getElementById('company-table').getElementsByTagName('tbody')[0];
            guidesTableBody.innerHTML = '';

            // Populate the table with guide data
            guides.forEach(guide => {
                const row = document.createElement('tr');
                row.innerHTML = `
                    <td>${guide.guideId}</td>
                    <td>${guide.fullName}</td>
                    <td>${guide.email}</td>
                    <td>${guide.password}</td>
                    <td>${guide.dateOfBirth}</td>
                    <td>${guide.joiningDate}</td>
                `;
                guidesTableBody.appendChild(row);
            });
        })
        .catch(error => console.error('Error fetching guides:', error));
}
