 // --- Element References ---
 const checkAvailabilityForm = document.getElementById('checkForm');
 const resultDiv = document.getElementById('result');
 const bookingSection = document.getElementById('booking-section');
 const userInfoSection = document.getElementById('user-info-section');
 const userInfoForm = document.getElementById('userInfoForm');
 const userInfoError = document.getElementById('userInfoError');
 const pickupDateInput = document.getElementById('pickup');
 const returnDateInput = document.getElementById('return');
 const carSelect = document.getElementById('car');
 const emailInput = document.getElementById('email');
 const userNameInput = document.getElementById('userName');

 // --- Event Listeners ---

 // 1. Check Availability Form Submission
 checkAvailabilityForm.addEventListener('submit', function (e) {
   e.preventDefault(); // Prevent default form submission
   resultDiv.innerHTML = ''; // Clear previous results
   userInfoError.innerHTML = ''; // Clear previous errors

   const pickupDate = pickupDateInput.value;
   const returnDate = returnDateInput.value;

   // Basic date validation
   const isAvailable = (pickupDate && returnDate && pickupDate < returnDate);

   if (isAvailable) {
     resultDiv.innerHTML = "<p style='color:green; font-size: 25px; margin:30px;'>✅ Car is available</p>";
     bookingSection.style.display = 'block'; // Show the 'Confirm Booking' button
     userInfoSection.style.display = 'none'; // Ensure user info form is hidden
   } else {
     resultDiv.innerHTML = "<p style='color:red; font-size: 25px; margin:30px;'>❌  Car is NOT a\Available or data is not valid</p>";
     bookingSection.style.display = 'none';
     userInfoSection.style.display = 'none';
   }
 });

 // 2. User Info Form Submission (Handles Validation and EmailJS)
 userInfoForm.addEventListener('submit', function(e) {
   e.preventDefault(); // Prevent default form submission
   userInfoError.innerHTML = ''; // Clear previous errors

   // --- Collect User Data ---
   const userName = userNameInput.value;
   const nationalId = document.getElementById('nationalId').value;
   const phoneNumber = document.getElementById('phoneNumber').value;
   const email = emailInput.value;
   const optionalPhoneNumber = document.getElementById('optionalPhoneNumber').value; // Optional
   const creditCardNumber = document.getElementById('creditCardNumber').value;
   const creditCardExpiry = document.getElementById('creditCardExpiry').value;
   const creditCardCvv = document.getElementById('creditCardCvv').value;
   const pickupDate = pickupDateInput.value; // Get pickup date again for the email
   const selectedCar = carSelect.options[carSelect.selectedIndex].text; // Get selected car text

   // --- Basic Validation ---
   // Add more specific validation (e.g., email format, phone number format, CC format) if needed
   if (!userName || !nationalId || !phoneNumber || !email || !creditCardNumber || !creditCardExpiry || !creditCardCvv) {
     userInfoError.innerHTML = 'please fill all fields';
     return; // Stop submission if validation fails
   }

   // --- Prepare EmailJS Data ---
   // **IMPORTANT:** Ensure these parameter names match *exactly* the variables in your EmailJS template
   const templateParams = {
     to_email: email,          // Email address from the form
     to_name: userName,        // User's name from the form
     pickup_date: pickupDate,  // Pickup date from the form
     selected_car: selectedCar, // Selected car model
     // Add any other parameters your EmailJS template expects
   };
   
   // --- Send Email using EmailJS ---
   // Replace with your actual EmailJS Service ID and Template ID
   

   console.log('Sending email with params:', templateParams); // For debugging

   emailjs.send("service_n4xmxox", "template_4skzvyj", templateParams)
 .then(function(response) {
   alert("✅ Your booking has beeen successfully confirmed! \n A confirmation email will sent to ${email} containing the booking details ");
 }, function(error) {
   alert("❌ Failed to send email : " + error.text);
 });
 });

 // --- Helper Functions ---

 // Function called by the 'Confirm Booking' button
 function showUserInfoForm() {
 document.getElementById('user-info-section').style.display = 'block';
 document.getElementById('booking-section').style.display = 'none';
}
