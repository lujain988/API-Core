debugger;
const form = document.getElementById("form");
form.addEventListener("submit", async function () {
  event.preventDefault();

  const url = "http://localhost:5286/api/USer/login";
  const formData = new FormData(form);
  if (!username || !email || !password) {
    alert("Please fill in both the email and password fields.");
    return;
  }

  const response = await fetch(url, {
    method: "POST",
    body: formData,
  });

  const result = await response.json();

  if (response.ok) {
    // const result = JSON.parse(data);
    localStorage.setItem("jwtToken", result.token);

    // const cartresponse = await fetch('http://localhost:5286/api/Cart',  {
    //   headers: {
    //     'Authorization': `Bearer ${result.token}`
    //   }
    // });
    // debugger;
    //     if (cartresponse.ok) {
    //       const cartResult = await cartresponse.json();
    //       console.log(cartResult);
    //       localStorage.setItem('cartId', cartResult.id); // Store cartId
    //     } else {
    //       console.error('Failed to fetch cartId');
    //     }

    alert("User Logged In");
    window.location.href = "../Product/index.html";
  } else {
    alert(`Login failed: ${data}`);
  }
});
