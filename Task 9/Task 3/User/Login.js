debugger;
const form = document.getElementById("form");
form.addEventListener("submit", async function () {
  event.preventDefault();

  const url = "http://localhost:5286/api/USer/login";
  const formData = new FormData(form);
  if (!username || !email || !password) {
    alert("Please fill in both the email and password fields.");
    return;
  }

  const response = await fetch(url, {
    method: "POST",
    body: formData,
  });

  const data = await response.text();

  if (response.ok) {
    alert("User Logged In");
    window.location.href = "../Product/index.html";
  } else {
    alert(`Login failed: ${data}`);
  }
});
