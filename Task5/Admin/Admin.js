async function getAllCategory() {
    let url = "http://localhost:5286/api/Categories";
    let request = await fetch(url);
  
    let data = await request.json();
    let cards = document.querySelector("tbody"); // Fixed typo here
  
    data.forEach((category) => {
      // Create card with save button
      let imageUrl = `${category.categoryImage}`; 
      cards.innerHTML +=`
   
    <tr>
      <th scope="row">:)</th>
      <td><img src="${imageUrl}" alt="${category.categoryImage} (image not found)" style="width: 50px; height: auto;"></td>
      <td>${category.categoryName}</td>
      <td>${category.id}</td>
      <td>
      <button class="btn btn-outline-primary" onclick="saveToLocalStorage(${category.id})">Edit</button>
              <button class="btn btn-outline-danger" onclick="deleteProduct(${category.id})">Delete</button>

      </td>
    </tr>

        
    `

    });
  
    console.log(data);
  }
  function saveToLocalStorage(id) {
    localStorage.setItem("categories", id);
    window.location.href = "Category/updateCategory.html";
  }
  //function to save the category to local storage
  function updateCategory(id) {
    localStorage.setItem("categories", id);
    window.location.href = "updat.html";
  }
  
async function deleteProduct(id) {
  var url = `http://localhost:5286/api/Categories/${id}`;
  
  let request = await fetch(url, {
    method: "DELETE",
  });
    alert("Product Deleted");
    window.location.href = "AdminDashboard.html";
}
  
  getAllCategory();
  function addCategory(id) {
    window.location.href = "category/addCategory.html";
  }