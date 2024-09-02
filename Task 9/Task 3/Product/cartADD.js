    


function storeProductInCart(id) {
    localStorage.setItem("productCart", id);
  }

    async function addToCart() {
        let url = "http://localhost:5286/api/cartItem";
        const cartId = 3; 
        const productId = localStorage.getItem("productCart");
        const quantity = document.getElementById(`quantity-${productId}`).value;

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
            alert ("Product added to cart");
            window.location.href = 'ShopingCart.html';

    }
    

    document.querySelector("button").addEventListener("click", addToCart);

    addToCart();
