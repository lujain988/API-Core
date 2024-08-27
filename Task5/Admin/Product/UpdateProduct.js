// debugger;

async function getCategoryName() {
    const dropDown = document.getElementById("dropDownList");
    let url = "http://localhost:5286/api/Categories";
    let request = await fetch(url);
    let data = await request.json();
    //make append for dropdown list



    data.forEach((select) => {
        dropDown.innerHTML += `
        <option value="${select.id}">${select.categoryName}</option>
        `;
    });
}
getCategoryName();

const n = localStorage.getItem("products");
var url = `http://localhost:5286/Products/${n}`;
var form = document.getElementById("form");
async function updateProduct() {

  var formData = new FormData(form);
  event.preventDefault();

  let response = await fetch(url, {
    method: "PUT",
    body: formData,
  });
  let data = await response.json();

  // var lujain = response;
  window.location.href = "ShowProduct.html";
  alert("your product has successfully edited");
}

document.getElementById("form").addEventListener("submit", updateProduct);

//get category from api for dropdown list
