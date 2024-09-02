async function postData() {
  event.preventDefault();
  const url = "http://localhost:5286/api/USer/register";
  const form = document.getElementById("form");
  const formData = new FormData(form);
  const requiredFields = ["username", "email", "password", "confirmPassword"];
  
  for (const field of requiredFields) {
    if (!formData.get(field)) {
      alert(`Please fill out the ${field} field.`);
      return;
    }
  }
  //check password and confirm password
  if (formData.get("password") !== formData.get("confirmPassword")) {
    alert("Passwords do not match");
    return;
  }
  const response = await fetch(url, {
    method: "POST",
    body: formData,
  });
  const data = await response.json();
  alert("User Registered");

  window.location.href = "Login.html";
}
