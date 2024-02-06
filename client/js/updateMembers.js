document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('company-form');

    form.addEventListener('submit', function (event) {
        event.preventDefault();

        // Retrieve values from the form
        const memberId = document.getElementById('member-id').value;
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

        // Construct the member object
        const updatedMember = {
            MemberId: memberId,
            FullName: name,
            Email: email,
            Password: password,
            DateOfBirth: dob,
            Gender: gender,
            JoiningDate: joiningDate,
            MobileNumber: mobileNumber,
            EmergencyNumber: emergencyNumber,
            Photo: photo,
            Profession: profession,
            Nationality: nationality
        };

        // Perform the update using an AJAX request or any preferred method
        // Example using fetch API:
        fetch(`/api/member/${memberId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updatedMember)
        })
        .then(response => response.json())
        .then(data => {
            console.log('Member updated successfully:', data);
            // You can add any additional logic or redirection here
        })
        .catch(error => console.error('Error updating member:', error));
    });
});
