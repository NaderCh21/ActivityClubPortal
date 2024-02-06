document.addEventListener("DOMContentLoaded", function () {
    const fetchButton = document.getElementById("fetch-events");
    const tableBody = document.querySelector("#company-table tbody");
  
    fetchButton.addEventListener("click", function () {
      // Fetch events from the API
      fetch("/api/Event")
        .then((response) => {
          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }
          return response.json();
        })
        .then((responseData) => {
          // Check if the response contains $values array
          const events = responseData.$values || [];
  
          // Clear existing table rows
          tableBody.innerHTML = "";
  
          // Populate the table with event data
          events.forEach((event) => {
            const row = document.createElement("tr");
            row.innerHTML = `
              <td>${event.eventId}</td>
              <td>${event.name}</td>
              <td>${event.description}</td>
              <td>${event.categoryId}</td>
              <td>${event.destination}</td>
              <td>${event.dateFrom}</td>
              <td>${event.dateTo}</td>
              <td>${event.cost}</td>
            `;
            tableBody.appendChild(row);
          });
        })
        .catch((error) => console.error("Error fetching events:", error));
    });
  });
  