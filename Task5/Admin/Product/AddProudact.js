
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



var url = "http://localhost:5286/Products";
var form = document.getElementById("form");
async function fun() {
  event.preventDefault();
  var formData = new FormData(form);
  let respons = await fetch(url, {
    method: "POST",
    body: formData,
  });
  var data = respons;
  alert("Product added successfully");

  window.location.href = "ShowProduct.html";
}


 //save the product to the local storage