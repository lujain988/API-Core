const id = Number(localStorage.getItem("categories"));
const url = `http://localhost:5286/api/Categories/${id}`;
var form = document.getElementById("form");
async function updateCategory() {
    event.preventDefault();
  var formData = new FormData(form);
  let request = await fetch(url, {
    method: "PUT",
    body: formData,
  });
    formData.append("productName", document.getElementById("productName").value);
const description = document.getElementById("description").value;
    formData.append("description", description);
const price = document.getElementById("price").value;
    formData.append("price", price);
const categoryId = document.getElementById("categoryId").value;
    formData.append("categoryId", categoryId);
const productImage = document.getElementById("productName").files[0];
    formData.append("productImage", productImage);

 
    var data = request;

}
document.getElementById("form").addEventListener("submit", updateCategory);
updateCategory();