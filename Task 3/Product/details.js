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
  
        </div>
        </div>`;
    ;
  
    console.log(data);
  }
  getAllProduct();
