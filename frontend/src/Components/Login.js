import { useState } from "react";
import { useNavigate } from "react-router-dom";
import "./CSS/Login.css"

export function LogInForm() {
  const [formData, setFormData] = useState({ email: '', password: '' });
  const navigate = useNavigate();

  async function login() {
    let url = "https://localhost:7181/api/Account/login";
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
        navigate("/");
      } else {
        alert("Login mislykkedes");
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
    login();
  }

  return (
    <form className="loginForm" onSubmit={handleSubmit}>
        <label className="LogInText">LOG IND </label>
        <input className="LogInInput" placeholder="E-Mail" type="text" name="email" value={formData.email} onChange={handleChange} />

        <input className="LogInInput" placeholder="Adgangskode" type="password" name="password" value={formData.password} onChange={handleChange} />
      
      <input className="logInSubmitButton" type="submit" value="LOG IND" />
    </form>
  );
}
