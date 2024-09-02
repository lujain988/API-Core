async function apperdata(){
    event.preventDefault();
     debugger;
     var id =document.getElementById("userId");
     const url = `http://localhost:5286/api/USer/${id.value}`;
 
     var form=document.getElementById("userForm");
 
 
     var response  = await fetch(url);
 
     var result = await response.json();
 
 
     var username=document.getElementById("name");
     var email=document.getElementById("email1");
 username.value=result.username;
 email.value=result.email;
 
 }