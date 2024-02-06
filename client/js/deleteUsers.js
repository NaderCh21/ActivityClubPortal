document.getElementById('delete-user-form').addEventListener('submit', deleteUser);

function deleteUser(event) {
    event.preventDefault();

    const userId = document.getElementById('user-id').value;
    const confirmation = confirm(`Are you sure you want to delete user with ID ${userId}?`);

    if (confirmation) {
        fetch(`http://localhost:5294/api/User/${userId}`, {
            method: 'DELETE',
        })
        .then(handleResponse)
        .then(handleSuccess)
        .catch(handleError);
    }
}

function handleResponse(response) {
    if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
    }
    return response.text();
}

function handleSuccess(responseText) {
    console.log('Success:', responseText);
    displayMessage('User deleted successfully', 'success');
}

function handleError(error) {
    console.error('Error deleting user:', error);
    console.log('Response status:', error.response ? error.response.status : 'N/A');
    console.log('Response text:', error.response ? error.response.text() : 'N/A');
    displayMessage('Error deleting user. Please try again.', 'error');
}

function displayMessage(message, messageType) {
    const messageContainer = document.getElementById('message-container');
    messageContainer.innerHTML = `<div class="${messageType}">${message}</div>`;
}
