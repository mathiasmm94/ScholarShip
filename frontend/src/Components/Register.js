import { useState } from "react";
import { useNavigate } from "react-router-dom";

import "./CSS/Register.css"

export function RegisterUser() {
  const [formData, setFormData] = useState({ email: '', password: '', confirmpassword: '', phonenumber: '', firstname: '', lastname: '', university: '', birthdate: '' });
  const [formErrors, setFormErrors] = useState({});

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
        alert("Bruger oprettet");
        navigate("/");
      } else {
        const responseData = await response.json();
        const errorMessage = responseData.error;
        alert(errorMessage);
      }
    } catch (err) {
      alert("Error: " + err);
    }
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
    if (validateForm()) {
      register();
    }
  }

  function validateForm() {
    const errors = {};  
    let hasErrors = false;

    for (const [fieldName, fieldValue] of Object.entries(formData)) {
      if (fieldValue.trim() === "") {
        errors[fieldName] = "Field is required";
        hasErrors = true;
      }
    }
    if (formData.password !== formData.confirmpassword) {
      alert("Passwords do not match");
      hasErrors = true;
    }

    setFormErrors(errors);
    return !hasErrors;
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
          <input
            className={`InputName ${formErrors.firstname && "InvalidField"}`}
            placeholder="Fornavn"
            type="text"
            name="firstname"
            value={formData.firstname}
            onChange={handleChange}
          />
          {formErrors.firstname && <span className="ErrorMessage">{formErrors.firstname}</span>}

          <input
            className={`InputName ${formErrors.lastname && "InvalidField"}`}
            placeholder="Efternavn"
            type="text"
            name="lastname"
            value={formData.lastname}
            onChange={handleChange}
          />
          {formErrors.lastname && <span className="ErrorMessage">{formErrors.lastname}</span>}
        </div>

        <div className="InputContainer2">
          <input
            className={`RegisterInput ${formErrors.birthdate && "InvalidField"}`}
            placeholder="Fødselsdato - dd-mm-yyyy"
            type="date"
            name="birthdate"
            value={formData.birthdate}
            onChange={handleChange}
            />
            {formErrors.birthdate && <span className="ErrorMessage">{formErrors.birthdate}</span>}
  
            <input
              className={`RegisterInput ${formErrors.email && "InvalidField"}`}
              placeholder="E-Mail"
              type="text"
              name="email"
              value={formData.email}
              onChange={handleChange}
            />
            {formErrors.email && <span className="ErrorMessage">{formErrors.email}</span>}
  
            <input
              className={`RegisterInput ${formErrors.phonenumber && "InvalidField"}`}
              placeholder="Telefonnummer"
              type="text"
              name="phonenumber"
              value={formData.phonenumber}
              onChange={handleChange}
            />
            {formErrors.phonenumber && <span className="ErrorMessage">{formErrors.phonenumber}</span>}
  
            <input
              className={`RegisterInput ${formErrors.password && "InvalidField"}`}
              placeholder="Adgangskode"
              type="password"
              name="password"
              value={formData.password}
              onChange={handleChange}
            />
            {formErrors.password && <span className="ErrorMessage">{formErrors.password}</span>}
  
            <input
              className={`RegisterInput ${formErrors.confirmpassword && "InvalidField"}`}
              placeholder="Bekræft adgangskode"
              type="password"
              name="confirmpassword"
              value={formData.confirmpassword}
              onChange={handleChange}
            />
            {formErrors.confirmpassword && <span className="ErrorMessage">{formErrors.confirmpassword}</span>}
  
            <input
              className={`RegisterInput ${formErrors.university && "InvalidField"}`}
              placeholder="Uddannelsessted"
              type="text"
              name="university"
              value={formData.university}
              onChange={handleChange}
            />
            {formErrors.university && <span className="ErrorMessage">{formErrors.university}</span>}
  
            <input className="RegisterSubmitButton" type="submit" value="Opret Bruger" />
          </div>
        </div>
      </form>
    );
  }
  
