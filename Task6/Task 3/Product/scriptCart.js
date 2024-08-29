async function getCartItem() {
  let url = "http://localhost:5286/api/cartItem";
  let request = await fetch(url);
  let data = await request.json();
  let cards = document.getElementById("ShopingCart");

  // Filter items where cartId is 3
  let filteredItems = data.filter((item) => item.cartId === 3);

  filteredItems.forEach((item) => {
    let cardHTML = `
            <div class="card mb-3">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div class="d-flex flex-row align-items-center">
                            <div>
                                <!-- Placeholder image, adjust as necessary -->
                                <img
                                    src="${item.product.productImage}"
                                    class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                            </div>
                            <div class="ms-3">
                                <h5>${item.product.productName}</h5>
                                <p class="small mb-0"><span> Description: </span> ${
                                  item.product.description || "No description"
                                }</p>
                            </div>
                        </div>
                        <div class="d-flex flex-row align-items-center">
                            <div style="width: 50px;">
                          <button class="btn btn-outline-success" onclick="addQuantity(${
                            item.id
                          })">+</button>

                                <h5 class="fw-normal mb-0" id="quantity">${
                                  item.quantity
                                }</h5>
                            <button class="btn btn-outline-danger" onclick="deleteQuantity(${
                              item.id
                            })">-</button>

                            </div>
                            <div style="width: 80px;">
                                <h5 class="mb-0">$${item.product.price}</h5>
                            </div>
                                   <button class="btn btn-outline-danger" onclick="deleteProduct(${
                                     item.id
                                   })">Delete</button>

                        </div>
                    </div>
                </div>
            </div>
        `;

    cards.innerHTML += cardHTML;
  });

  //make price summation
  //TOTAL PRICE FOR cartid =3 only

  let totalPrice = 0;
  filteredItems.forEach((item) => {
    totalPrice += item.product.price * item.quantity;
  });

  let price = document.getElementById("count");
  price.innerHTML = `Subtotal: $${totalPrice}`;
  document.getElementById("itemCount").textContent = filteredItems.length;

  console.log(filteredItems);
}

getCartItem();

async function deleteProduct(id) {
  var url = `http://localhost:5286/api/cartItem/${id}`;

  let request = await fetch(url, {
    method: "DELETE",
  });
  alert("Product Deleted");
  window.location.href = "ShopingCart.html";
}
//add quantity
async function addQuantity(id) {
  var url = `http://localhost:5286/increment/${id}`;
  let request = await fetch(url, {
    method: "PUT",
    body: JSON.stringify({
      quantity: 1,
    }),
    headers: {
      "Content-Type": "application/json",
    },
  });
  const updatedItem = await request.json();
  document.getElementById("quantity").textContent = updatedItem.quantity;
  alert("Quantity Added");
  window.location.reload();
}

//delete quantity
async function deleteQuantity(id) {
  var url = `http://localhost:5286/decrement/${id}`;
  let request = await fetch(url, {
    method: "PUT",
    body: JSON.stringify({
      quantity: -1,
    }),
    headers: {
      "Content-Type": "application/json",
    },
  });

  const updatedItem = await request.json();
  document.getElementById("quantity").textContent = updatedItem.quantity;
  alert("Quantity Deleted");
  window.location.reload();
}
