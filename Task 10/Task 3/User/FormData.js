// async function apperdata(){
//     event.preventDefault();
//      debugger;
//      var id =document.getElementById("userId");
//      const url = `http://localhost:5286/api/USer/${id.value}`;
 
//     //  var form=document.getElementById("userForm");
 
 
//      var response  = await fetch(url);
 
//      var result = await response.json();
 
 
//      var username=document.getElementById("name");
//      var email=document.getElementById("email1");
//  username.value=result.username;
//  email.value=result.email;
 
//  }

 debugger;

async function apperdata() {
    event.preventDefault(); 
    var formm = document.getElementById("id");
    if (!id) {
        alert('Please enter an ID.');
        return;
    }
    const url = `http://localhost:5286/api/USer/${formm.value}`;
       
        const response = await fetch(url);
        
        if (!response.ok) {
            throw new Error('User not found');
        }
      

        // Parse the JSON response
        const data = await response.json();
        
        // Assuming data is an object, not an array
       
      document.getElementById("userName").value =data.username;
        // y.value = data.username;
      document.getElementById("userEmail").value =data.email;
        // z.value = data.email;
  
}
