//get the local storage catagories

async function getAllProduct() {
  const n = localStorage.getItem("categories");
  var url;
  if (n) {
    url = `http://localhost:5286/Products/${n}`;
  } else {
    url = "http://localhost:5286/Products";
  }
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("productCard");

  data.forEach((product) => {
    cards.innerHTML += `   <div class="card" style="width: 18rem;">
      <div class="card-body">
          <h5 class="card-title">${product.productName}</h5>
        
          <img src="${product.productImage}" alt="Image" class="card-img-top">
            <p class="card-text">${product.price}</p>
        </div>
      <button class="btn btn-primary" onclick="saveToLocalStorage(${product.id})">Details</button>
      <button class="btn btn-primary" onclick="updateCategory(${product.id})">Update</button>


      </div>
      </div>`;
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

getAllProduct();
