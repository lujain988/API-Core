//get the local storage catagories

async function getAllProduct() {
 
  const n = localStorage.getItem("categories");
  const token = localStorage.getItem('jwtToken');
  if (token == null) {
    alert("Please login first");
    window.location.href = "../User/login.html";
  }
  var url;
  if (n) {
    url = `http://localhost:5286/Products${n}`;
  } else {
    url = "http://localhost:5286/Products";
  }
  let request = await fetch(url, {
    headers: {
      'Authorization': `Bearer ${token}`
  },
  });

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
      <br>
      <button class="btn btn-primary" onclick="storeProductInCart(${product.id})">Store</button>
      <br>
      <button class="btn btn-primary" onclick="addToCart(${product.id})">Add to cart </button>
            <input type="number" id="quantity-${product.id}" value="1" class="form-control mb-2">


      </div>
      </div>`;
  });

  console.log(data);
}

function saveToLocalStorage(id) {
  localStorage.setItem("products", id);
  window.location.href = "details.html";
}

getAllProduct();
