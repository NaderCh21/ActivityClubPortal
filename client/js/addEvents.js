document.addEventListener("DOMContentLoaded", function () {
    const eventForm = document.getElementById("event-form");
    const fetchButton = document.getElementById("fetch-events");
    const tableBody = document.querySelector("#company-table tbody");
  
    eventForm.addEventListener("submit", function (event) {
      event.preventDefault();
  
      // Fetch values from the form
      const eventName = document.getElementById("event-name").value;
      const eventDescription = document.getElementById("event-description").value;
      const eventCategory = document.getElementById("event-category").value;
      const eventDestination = document.getElementById("event-destination").value;
      const eventDateFrom = document.getElementById("event-date-from").value;
      const eventDateTo = document.getElementById("event-date-to").value;
      const eventCost = document.getElementById("event-cost").value;
  
      // Create a new event object
      const newEvent = {
        name: eventName,
        description: eventDescription,
        categoryId: eventCategory,
        destination: eventDestination,
        dateFrom: eventDateFrom,
        dateTo: eventDateTo,
        cost: eventCost,
      };
  
      // Add the new event to the list (you can modify this part based on your data structure)
      events.push(newEvent);
  
      // Clear the form if needed
      eventForm.reset();
  
      // Fetch and display the updated events list
      fetchEvents();
    });
  
    fetchButton.addEventListener("click", fetchEvents);
  
    function fetchEvents() {
      // Fetch events from the API
      fetch("/api/Event")
        .then((response) => {
          if (!response.ok) {
            throw new Error(`HTTP error! Status: ${response.status}`);
          }
          return response.json();
        })
        .then((events) => {
          // Clear existing table rows
          tableBody.innerHTML = "";
  
          // Populate the table with fetched events
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
    }
  });
  