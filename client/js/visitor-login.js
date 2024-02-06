document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("form1");
  
    if (form) {
      form.addEventListener("submit", function (event) {
        event.preventDefault(); // Prevent the default form submission
  
        // Navigate to public.html
        window.location.href = "public.html";
      });
    }
  });
  