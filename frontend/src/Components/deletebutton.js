import React from 'react';
import './CSS/Annonce.css';


function DeleteButtonReal({id}) {
  const token = localStorage.getItem("token");
  const decodeToken = () =>{
    const t = localStorage.getItem('token');
    let user = parseJwt(t);
    console.log(user);
    return user.EfManagerId;
  };
  function parseJwt(token) {
    var base64Url = token.split(".")[1];
    var base64 = base64Url.replace(/-/g, "+").replace(/_/g, "/");
    var jsonPayload = decodeURIComponent(
      window
        .atob(base64)
        .split("")
        .map(function (c) {
          return "%" + ("00" + c.charCodeAt(0).toString(16)).slice(-2);
        })
        .join("")
    );

    return JSON.parse(jsonPayload);
  }
   const handleClick = () => {
    decodeToken();
    console.log(id);
    if (window.confirm("Bekræft sletning af annonce"))
    fetch(`https://localhost:7181/api/Annonces/${id}`, {
       method: 'DELETE',
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`
      },
    })
      .then(response => response.json())
      .then(data => {
        alert("Annoncen er nu slettet")
        console.log("Deleting data ...." )
        
      })
      .catch(error => {
        console.log(error)
        
      });
      window.location.reload();
  }

  
  return (
    // <><input type="text" value={id} onChange={handleChange} placeholder="Enter ID" />
    <button className="deletebutton2" onClick={handleClick}>Slet Annonce</button>
    //</>
    
)}

export default DeleteButtonReal;
