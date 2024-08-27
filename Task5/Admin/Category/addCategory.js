const url = "http://localhost:5286/api/Categories";
async function addCategory() {
  event.preventDefault();
  debugger;
  let formData = new FormData();
  let categoryName = document.getElementById("categoryName").value;
  formData.append("categoryName", categoryName);
  let categoryImage = document.getElementById("categoryImage").files[0];
  formData.append("categoryImage", categoryImage);
  let request = await fetch(url, {
    method: "POST",
    body: formData,
  });
  if (request.ok) {
    let data = await request.json();
    alert("Category added successfully");
    document.getElementById("categoryName").value = "";
    document.getElementById("categoryImage").value = "";
  }
  window.location.href = "../AdminDashboard.html";
}
//call the addCategory function when the submit button is clicked
document.getElementById("form").addEventListener("submit", addCategory);
