import { useState } from "react";
import "./CSS/Annonce.css";
import {useNavigate} from "react-router-dom";

export function CreateAnnonce() {
  const navigate = useNavigate();
  const [price, setPrice] = useState("");
  const [titel, setTitel] = useState("");
  const [kategori, setKategori] = useState("");
  const [beskrivelse, setBeskrivelse] = useState("");
  const [studieretning, setStudieretning] = useState("");
  const [billedesti, setBilledsti] = useState("");
  const [stand, setStand] = useState("");
  const [isFormSubmitted, setIsFormSubmitted] = useState(false);
  const [showPaymentPopup, setShowPaymentPopup] = useState(false);
  const [cardNumber, setCardNumber] = useState("");
  const [expiryDate, setExpiryDate] = useState("");
  const [securityCode, setSecurityCode] = useState("");
  const [numberOfWeeks, setNumberOfWeeks] = useState("1");

  const initialFormData = {
    price: "",
    titel: "",
    kategori: "",
    beskrivelse: "",
    studieretning: "",
    billedesti: "",
    stand: "",
    expiryDate: "",
    securityCode: "",
    cardNumber: "",
    numberOfWeeks: "1",
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (showPaymentPopup) {
      submitPaymentForm();
    } else {
      postAnnonce();
    }
    setPrice(initialFormData.price);
    setTitel(initialFormData.titel);
    setKategori(initialFormData.kategori);
    setBeskrivelse(initialFormData.beskrivelse);
    setStudieretning(initialFormData.studieretning);
    setBilledsti(initialFormData.billedesti);
    setStand(initialFormData.stand);
    setCardNumber(initialFormData.cardNumber);
    setExpiryDate(initialFormData.expiryDate);
    setSecurityCode(initialFormData.securityCode);
    setNumberOfWeeks(initialFormData.numberOfWeeks);
    setIsFormSubmitted(true);
  };
  const handleCancel = () => {
    setPrice(initialFormData.price);
    setTitel(initialFormData.titel);
    setKategori(initialFormData.kategori);
    setBeskrivelse(initialFormData.beskrivelse);
    setStudieretning(initialFormData.studieretning);
    setBilledsti(initialFormData.billedesti);
    setStand(initialFormData.stand);
    setCardNumber(initialFormData.cardNumber);
    setExpiryDate(initialFormData.expiryDate);
    setSecurityCode(initialFormData.securityCode);
    setNumberOfWeeks(initialFormData.numberOfWeeks);
    setIsFormSubmitted(true);
    setShowPaymentPopup(false);
    alert("Annonce er annulleret");
    navigate("/profile");
  };

  const handleCheckboxChange = () => {
    setShowPaymentPopup(!showPaymentPopup);
  };
  const handleWeeksChange = (e) => {
    setNumberOfWeeks(parseInt(e.target.value));
  };

  const submitPaymentForm = () => {
    console.log("Payment submitted:", cardNumber, expiryDate, securityCode);
    alert("Payment submitted successfully!");
    postAnnonce();
  };

  const decodeToken = () => {
    const t = localStorage.getItem("token");
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

  const postAnnonce = async () => {
    try {
      const token = localStorage.getItem("token");

      const response = await fetch("https://localhost:7181/api/Annonces", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
          Authorization: `Bearer ${token}`,
        },
        body: JSON.stringify({
          Price: price,
          Titel: titel,
          Kategori: kategori,
          Beskrivelse: beskrivelse,
          Studieretning: studieretning,
          BilledeSti: billedesti,
          EfManagerId: decodeToken(),
          Stand: stand,
          CheckboxValue: showPaymentPopup,
          NumberOfWeeks: numberOfWeeks,
        }),
      });
      console.log(response);
      if (!response.ok) {
        throw new Error("couldnt post ad");
      }
      alert("Annonce er tilføjet");
      const data = await response.json();
      console.log("data received:", data);
    } catch (error) {
      console.log("Error:  ", error);
    }
  };

  return (
    <div className="form-border">
      <form onSubmit={handleSubmit}>
        <label className="form-label">Oprettelse af annonce</label>
        <input
          className="form-input"
          type="number"
          id="price"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
          placeholder="Indsæt pris"
          required={!isFormSubmitted}
        />

        <input
          className="form-input"
          type="text"
          id="title"
          value={titel}
          onChange={(e) => setTitel(e.target.value)}
          placeholder="Indsæt titel"
          required={!isFormSubmitted}
        />

        <input
          className="form-input"
          type="text"
          id="category"
          value={kategori}
          onChange={(e) => setKategori(e.target.value)}
          placeholder="Indsæt kategori"
          required={!isFormSubmitted}
        />

        <textarea
          className="form-textarea"
          id="description"
          value={beskrivelse}
          onChange={(e) => setBeskrivelse(e.target.value)}
          placeholder="Indsæt beskrivelse"
          required={!isFormSubmitted}
        ></textarea>

        <input
          className="form-input"
          type="text"
          id="major"
          value={studieretning}
          onChange={(e) => setStudieretning(e.target.value)}
          placeholder="Indsæt studieretning"
          required={!isFormSubmitted}
        />

        <input
          className="form-input"
          type="text"
          id="image"
          value={billedesti}
          onChange={(e) => setBilledsti(e.target.value)}
          placeholder="Indsæt URL til billede"
          required={!isFormSubmitted}
        />

        <select
          className="form-input"
          id="Condition"
          value={stand}
          onChange={(e) => setStand(e.target.value)}
          requirrequired={!isFormSubmitted}
          ed
        >
          <option value="">Vælg stand</option>
          <option value="Som ny">Som ny</option>
          <option value="Lidt slidt">Lidt slidt</option>
          <option value="Slidt">Slidt</option>
          <option value="Velbrugt">Velbrugt</option>
        </select>

        <input
          type="checkbox"
          id="paymentCheckbox"
          checked={showPaymentPopup}
          onChange={handleCheckboxChange}
        />
        <label htmlFor="paymentCheckbox">Promover annonce </label>

        {showPaymentPopup && (
          <div className={`payment-popup ${showPaymentPopup ? "show" : ""}`}>
            <span className="price-label">
              Annoncen promoveres i {numberOfWeeks} uge
              {numberOfWeeks > 1 ? "r" : ""}
              <br />
              Prisen er {numberOfWeeks * 35},-
            </span>
            <select
              className="form-input"
              id="numberOfWeeks"
              value={numberOfWeeks}
              onChange={handleWeeksChange}
              disabled={!showPaymentPopup}
            >
              <option value="1">1 Uge</option>
              <option value="2">2 Uger</option>
              <option value="3">3 Uger</option>
              <option value="4">4 Uger</option>
            </select>
            <input
              className="form-input"
              type="text"
              id="cardNumber"
              value={cardNumber}
              onChange={(e) => {
                let formattedValue = e.target.value
                  .replace(/\s/g, "")
                  .replace(/(\d{4})/g, "$1 ")
                  .trim();

                if (formattedValue.length > 19) {
                  formattedValue = formattedValue.slice(0, 19);
                }

                setCardNumber(formattedValue);
              }}
              onKeyDown={(e) => {
                const key = e.key;
                const isNumeric = /^\d$/.test(key);
                const isBackspace = key === "Backspace";

                if (!isNumeric && !isBackspace) {
                  e.preventDefault();
                }
              }}
              placeholder="Kortnummer"
              required={showPaymentPopup}
              maxLength={19}
              pattern="\d{4}\s?\d{4}\s?\d{4}\s?\d{4}"
            />
            <input
              className="form-input"
              type="date"
              id="expiryDate"
              value={expiryDate}
              onChange={(e) => setExpiryDate(e.target.value)}
              placeholder="Udløbsdato"
              required={showPaymentPopup}
            />
            <input
              className="form-input"
              type="text"
              id="securityCode"
              value={securityCode}
              onChange={(e) => {
                const input = e.target.value.replace(/\D/g, "");
                setSecurityCode(input);
              }}
              onKeyDown={(e) => {
                const key = e.key;
                const isNumeric = /^\d$/.test(key);
                const isBackspace = key === "Backspace";

                if (!isNumeric && !isBackspace) {
                  e.preventDefault();
                }
              }}
              placeholder="Sikkerheds kode"
              required={showPaymentPopup}
              maxLength={3}
              pattern="\d{3}"
              title="Please enter a 3-digit security code"
            />
          </div>
        )}

        <div className="button-container">
          <button className="submitbutton" type="submit">
            Opret annonce!
          </button>
          <button className="cancelbutton" onClick={handleCancel}>
            Annuller ændring
          </button>
        </div>
      </form>
    </div>
  );
}
