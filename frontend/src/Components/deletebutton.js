import React from 'react';
import './CSS/styling.css';
import { useState } from 'react';


function DeleteButtonReal() {
   const [id, setId] = useState('');
   const handleClick = () => {
    if (window.confirm("Are you sure you want to delete this ad?"))
    fetch(`http://localhost:5238/api//${id}`, {
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
