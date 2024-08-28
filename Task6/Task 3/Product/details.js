async function getAllProduct() {
    const n = localStorage.getItem("products");
    var url = `http://localhost:5286/Products/Product/${n}`;
   
    let request = await fetch(url);
  
    let data = await request.json();
    let cards = document.getElementById("productCard");
  
      cards.innerHTML = `<div class="card" style="width: 18rem;">
        <div class="card-body">
            <h5 class="card-title">${data.productName}</h5>
          
            <img src="${data.productImage}" alt="Image" class="card-img-top">
              <p class="card-text">${data.price}</p>
          </div>

            <input type="number" id="quantity" value="1" class="form-control mb-2">
                <button class="btn btn-primary" onclick="addToCart(${data.id})">Add to cart</button>
  
        </div>
        </div>`;
    ;
  
    console.log(data);
  }

  getAllProduct();

        

  async function addToCart() {
      let url = "http://localhost:5286/api/cartItem";
      const cartId = 3; 
      const productId = localStorage.getItem("products");
      const quantity = document.getElementById("quantity").value;

      let request = {
          cartId: cartId,
          productId: productId,
          quantity: quantity
          };

          let response = await fetch(url, {
              method: "POST",
              body: JSON.stringify(request),
              headers: {
                  "Content-Type": "application/json",
              },
          });

          let responseData = await response.json();
          window.location.href = 'ShopingCart.html';

  }
  

  document.querySelector("button").addEventListener("click", addToCart);

  addToCart();
