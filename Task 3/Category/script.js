async function getAllCategory() {
  let url = "http://localhost:5286/api/Categories";
  let request = await fetch(url);

  let data = await request.json();
  let cards = document.getElementById("conteainer"); // Fixed typo here

  data.forEach((category) => {
    // Create card with save button
    let cardHTML = `
        <div class="card" style="width: 18rem;">
          <div class="card-body">
            <h5 class="card-title">${category.categoryName}</h5>

            <img src="${category.categoryImage}" alt="Image" class="card-img-top">
          </div>
           <button class="btn btn-primary" onclick="saveToLocalStorage(${category.id})">Details</button>

        </div>
      `;

    cards.innerHTML += cardHTML;
  });

  console.log(data);
}
function saveToLocalStorage(id) {
  localStorage.setItem("categories", id);
  window.location.href = "../Product/index.html";
}

getAllCategory();
