import React from 'react';
import './CSS/Annonce.css';
import { useState } from 'react';


function DeleteButtonReal(id) {
  //  const [id, setId] = useState('');
   const handleClick = () => {
    if (window.confirm("Er du sikker på at du vil slette annoncen?"))
    fetch(`https://localhost:7181/api/Annonces/${id}`, {
       method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
      //body: JSON.stringify({/* payload data */ })
    })
      .then(response => response.json())
      .then(data => {
        alert("Annoncen er nu slettet")
        console.log("Deleting data ...." )
      })
      .catch(error => {
        console.log(error) // handle error
        
      });
  }
  // const handleChange = (event) => {
  //   setId(event.target.value);
  // }
  return (
    // <><input type="text" value={id} onChange={handleChange} placeholder="Enter ID" />
    <button className="deletebutton2" onClick={handleClick}>Slet Annonce</button>
    //</>
    
)}

export default DeleteButtonReal;
