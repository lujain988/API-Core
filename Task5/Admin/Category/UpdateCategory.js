const id = Number(localStorage.getItem("categories"));
const url = `http://localhost:5286/api/Categories/${id}`;
var form = document.getElementById("form");

async function updateCategory(event) {
    event.preventDefault(); 
    
    var formData = new FormData(form);
  
    formData.append("categoryName", document.getElementById("categoryName").value);

    const categoryImage = document.getElementById("categoryImage").files[0];
    if (categoryImage) {
        formData.append("categoryImage", categoryImage);
    }
  
   
        let request = await fetch(url, {
            method: "PUT",
            body: formData,
        });
        //  var data = request.json();
        // document.getElementById("categoryName").value =data.categoryName;
        //  document.getElementById("categoryImage").value = data.categoryImage;
          alert('Category updated successfully!');
         window.location.href = "../AdminDashboard.html";
        
    
}

document.getElementById("form").addEventListener("submit", updateCategory);
