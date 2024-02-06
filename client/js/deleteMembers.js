document.addEventListener('DOMContentLoaded', function () {
    const form = document.getElementById('delete-company-form');
    const resultMessage = document.getElementById('result-message');

    form.addEventListener('submit', function (event) {
        event.preventDefault();

        // Retrieve Member ID from the form
        const memberId = document.getElementById('company-id').value;

        // Perform the deletion using an AJAX request or any preferred method
        // Example using fetch API:
        fetch(`/api/member/${memberId}`, {
            method: 'DELETE',
        })
        .then(response => {
            if (response.ok) {
                resultMessage.textContent = 'Member deleted successfully';
                // You can add any additional logic or redirection here
            } else if (response.status === 404) {
                resultMessage.textContent = 'Member with the given ID does not exist';
            } else {
                console.error('Error deleting member:', response.status);
                resultMessage.textContent = 'Error deleting member. Please try again.';
            }
        })
        .catch(error => {
            console.error('Error deleting member:', error);
            resultMessage.textContent = 'Error deleting member. Please try again.';
        });
    });
});
