import { useState } from "react";
import { useNavigate } from "react-router-dom";

import "./CSS/Register.css"


export function RegisterUser() {
  const [formData, setFormData] = useState({ email: '', password: '',confirmpassword: '' ,phonenumber: '', firstname: '', lastname: '', university: '', birthdate: '' });
  const navigate = useNavigate();
  


  async function register() {
    const formattedFormData = {
    ...formData,
    birthdate: formatDate(formData.birthdate)
  };
    let url = "https://localhost:7181/api/Account/register";
    try {
      let response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(formattedFormData),
        headers: new Headers({
          "Content-Type": "application/json"
        })
      });
      if (response.ok) {
        console.log("success");
        navigate("/home");
      } 
      else {
      const responseData = await response.json();
      const errorMessage = responseData.error; // Access the error message sent from the backend
      alert(errorMessage);
      }
    } catch (err) {
      alert("Error: " + err);
    }

    //Hello push
    
    return;
  }

  function handleChange(event) {
    const { name, value } = event.target;
    setFormData(prevFormData => ({
      ...prevFormData,
      [name]: value
    }));
  }

  function handleSubmit(event) {
    event.preventDefault();
    register();
  }

  const formatDate = (dateString) => {
  const date = new Date(dateString);
  const day = String(date.getDate()).padStart(2, '0');
  const month = String(date.getMonth() + 1).padStart(2, '0');
  const year = date.getFullYear();
  return `${day}-${month}-${year}`;
};

  return (
    <form className="RegisterForm" onSubmit={handleSubmit}>
        <label className="RegisterText">Opret Bruger</label>

      <div className="RegisterContainer">
          <div className="InputContainer1">
              <input className="InputName" placeholder="Fornavn" type="text" name="firstname" value={formData.firstname} onChange={handleChange} />

              <input className="InputName" placeholder="Efternavn" type="text" name="lastname" value={formData.lastname} onChange={handleChange} />
          </div>

          <div className="InputContainer2">
              <input className="RegisterInput" placeholder="Fødselsdato - dd-mm-yyyy" type="date" name="birthdate" value={formData.birthdate} onChange={handleChange} />

              <input className="RegisterInput" placeholder="E-Mail" type="text" name="email" value={formData.email} onChange={handleChange} />

              <input className="RegisterInput" placeholder="Telefonnummer" type="text" name="phonenumber" value={formData.phonenumber} onChange={handleChange} />

              <input className="RegisterInput" placeholder="Adgangskode" type="password" name="password" value={formData.password} onChange={handleChange} />

              <input className="RegisterInput" placeholder="Bekræft adgangskode" type="password" name="confirmpassword" value={formData.confirmpassword} onChange={handleChange} />

              <input className="RegisterInput" placeholder="Uddannelsessted" type="text" name="university" value={formData.university} onChange={handleChange} />
              
              <input className="RegisterSubmitButton" type="submit" value="Opret Bruger" />
          </div>
      </div>
    </form>
  );
}
