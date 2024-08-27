async function getAllCategory() {
  let url = "http://localhost:5286/api/Categories";
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("conteainer"); // Fixed typo here

  data.forEach((category) => {
    // Create card with save button
    let imageUrl = `${category.categoryImage}`; 
    let cardHTML = `
         <div class="col-md-4 mb-4">
        <div class="card" style="width: 18rem;">
          <img src="${imageUrl}" alt="Image" class="card-img-top">
          <div class="card-body">
            <h5 class="card-title">${category.categoryName}</h5>
            <button class="btn btn-primary" onclick="saveToLocalStorage(${category.id})">Details</button>
            <button class="btn btn-primary" onclick="updateCategory(${category.id})">Update</button>
          </div>
        </div>
      </div>
    `;

    cards.innerHTML += cardHTML;
  });

  console.log(data);
}
function saveToLocalStorage(id) {
  localStorage.setItem("categories", id);
  window.location.href = "../Product/index.html";
}
//function to save the category to local storage
function updateCategory(id) {
  localStorage.setItem("categories", id);
  window.location.href = "updat.html";
}

getAllCategory();


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

  document.getElementById("categoryName").value = "";
  document.getElementById("categoryImage").value = "";
}}
//call the addCategory function when the submit button is clicked
document.getElementById("form").addEventListener("submit", addCategory);
