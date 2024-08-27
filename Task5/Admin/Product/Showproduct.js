//get the local storage catagories

async function getAllProduct() {
  const n = localStorage.getItem("categories");
  var url;
//   if (n) {
    // url = `http://localhost:5286/Products/${n}`;
//   } else {
    url = "http://localhost:5286/Products";
//   }
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.querySelector("tbody");

  data.forEach((product) => {
    cards.innerHTML += `
    <tr>
      <th scope="row">:)</th>
      <td><img src="${product.productImage}" (image not found)" style="width: 50px; height: auto;"></td>
      <td>${product.productName}</td>
      <td>${product.id}</td>
      <td>${product.price}</td>
      <td>
        <button class="btn btn-outline-primary" onclick="saveToLocalStorage(${product.id})">Edit</button>
        <button class="btn btn-outline-danger" onclick="deleteProduct(${product.id})">Delete</button>
      </td>
    </tr>
  `;
  });

  console.log(data);
}
function updateCategory(id) {
  localStorage.setItem("categories", id);
  window.location.href = "updat.html";
}
function saveToLocalStorage(id) {
  localStorage.setItem("products", id);
  window.location.href = "details.html";
}
function saveToLocalStorage(id) {
  localStorage.setItem("products", id);
  window.location.href = "UpdateProduct.html";
}



async function deleteProduct(id) {
  var url = `http://localhost:5286/Products/${id}`;
  
  let request = await fetch(url, {
    method: "DELETE",
  });
    alert("Product Deleted");
    window.location.href = "ShowProduct.html";  
}

getAllProduct();
function addCategory(id) {
    window.location.href = "addProudact.html";
  }