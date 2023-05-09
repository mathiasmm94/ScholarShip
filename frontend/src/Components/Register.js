import { useState } from "react";
import { useNavigate } from "react-router-dom";

import "./CSS/Register.css"


export function RegisterUser() {
  const [formData, setFormData] = useState({ email: '', password: '',confirmpassword: '' ,phonenumber: '', firstname: '', lastname: '', university: '', birthdate: '' });
  const navigate = useNavigate();

  async function register() {
    let url = "https://localhost:7181/api/Account/register";
    try {
      let response = await fetch(url, {
        method: "POST",
        body: JSON.stringify(formData),
        headers: new Headers({
          "Content-Type": "application/json"
        })
      });
      if (response.ok) {
        let token = await response.json();
        localStorage.setItem("token", token.jwt);
        console.log("success");
        navigate("/home");
      } else {
        alert("Server returned: " + response.statusText);
      }
    } catch (err) {
      alert("Error: " + err);
    }
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

  return (
    <form className="RegisterForm" onSubmit={handleSubmit}>
        <label className="RegisterText">Opret Bruger</label>

    <div className="RegisterContainer">
        <div className="InputContainer1">
            <input className="InputName" placeholder="Fornavn" type="text" name="firstname" value={formData.firstname} onChange={handleChange} />

            <input className="InputName" placeholder="Efternavn" type="text" name="lastname" value={formData.lastname} onChange={handleChange} />
        </div>

        <div className="InputContainer2">
            <input className="RegisterInput" placeholder="Fødselsdato - dd-mm-yyyy" type="text" name="birthdate" value={formData.birthdate} onChange={handleChange} />

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
