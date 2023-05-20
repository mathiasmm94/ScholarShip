import { useState } from "react";
import "./CSS/Annonce.css";

export function CreateAnnonce() {
  const [price, setPrice] = useState("");
  const [titel, setTitel] = useState("");
  const [kategori, setKategori] = useState("");
  const [beskrivelse, setBeskrivelse] = useState("");
  const [studieretning, setStudieretning] = useState("");
  const [billedesti, setBilledsti] = useState("");
  const [stand, setStand] = useState("");
  const [chatId, setChatId] = useState("");
  const [isFormSubmitted, setIsFormSubmitted] = useState(false);

  const initialFormData = {
    price: "",
    titel: "",
    kategori: "",
    beskrivelse: "",
    studieretning: "",
    billedesti: "",
    stand: "",
    chatId: "",
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    postAnnonce();
    setPrice(initialFormData.price);
    setTitel(initialFormData.titel);
    setKategori(initialFormData.kategori);
    setBeskrivelse(initialFormData.beskrivelse);
    setStudieretning(initialFormData.studieretning);
    setBilledsti(initialFormData.billedesti);
    setStand(initialFormData.stand);
    setChatId(initialFormData.chatId);
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
    setChatId(initialFormData.chatId);
    setIsFormSubmitted(true);
    alert("Annonce er annulleret");
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
          ChatId: chatId,
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
          placeholder="Indsæt billedesti"
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
          className="form-input"
          type="number"
          id="ChatId"
          value={chatId}
          onChange={(e) => setChatId(e.target.value)}
          placeholder="Indsæt ChatId"
          required={!isFormSubmitted}
        />

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
