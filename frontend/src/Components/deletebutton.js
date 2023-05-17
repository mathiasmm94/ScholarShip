import React from 'react';
import './CSS/Annonce.css';
import { useState } from 'react';


function DeleteButtonReal() {
   const [id, setId] = useState('');
   const handleClick = () => {
    if (window.confirm("Are you sure you want to delete this ad?"))
    fetch(`https://localhost:7181/api/Annonces/${id}`, {
       method: 'DELETE',
      headers: {
        'Content-Type': 'application/json'
      },
      //body: JSON.stringify({/* payload data */ })
    })
      .then(response => response.json())
      .then(data => {
        console.log("Deleting data ...." )
      })
      .catch(error => {
        console.log(error) // handle error
        
      });
  }
  const handleChange = (event) => {
    setId(event.target.value);
  }
  return (
    <><input type="text" value={id} onChange={handleChange} placeholder="Enter ID" />
    <button className="deletebutton2" onClick={handleClick}>Delete Ad</button></>
    
)}

export default DeleteButtonReal;
