import { useState } from "react";
import { useNavigate } from "react-router-dom";


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
    <form className="registerForm" onSubmit={handleSubmit}>
        <label className="RegisterText">Register User</label>
        <input className="RegisterInput" placeholder="E-Mail" type="text" name="email" value={formData.email} onChange={handleChange} />

        <input className="RegisterInput" placeholder="Adgangskode" type="password" name="password" value={formData.password} onChange={handleChange} />
      
      <input className="RegisterSubmitButton" type="submit" value="LOG IND" />
    </form>
  );
}
