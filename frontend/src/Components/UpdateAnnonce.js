import{ useState, useEffect} from "react";
import {useParams, useNavigate} from "react-router-dom";
import "./CSS/Annonce.css";

export function UpdateAnnonce() {
 const navigate = useNavigate();
  const { id } = useParams();
  console.log(id);
 
    const [price, setPrice] = useState(null);
      const [titel, setTitel] = useState("");
      const [kategori, setKategori] = useState("");
      const [beskrivelse, setBeskrivelse] = useState("");
      const [studieretning, setStudieretning] = useState("");
      const [billedesti, setBilledsti] = useState("");
      const [efManagerId, setEfManagerId] = useState("");
      const [stand, setStand] = useState("");
  const [showPaymentPopup, setShowPaymentPopup] = useState(false);
  const [cardNumber, setCardNumber] = useState("");
  const [expiryDate, setExpiryDate] = useState("");
  const [securityCode, setSecurityCode] = useState("");
  const [numberOfWeeks, setNumberOfWeeks] = useState("1");
    
      const decodeToken = () =>{
        const t = localStorage.getItem('token');
        let user = parseJwt(t);
        setEfManagerId(user.EfManagerId);
        console.log(user);
        return user.EfManagerId;
      }
      function parseJwt (token) {
        var base64Url = token.split('.')[1];
        var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));
    
        return JSON.parse(jsonPayload);
    }
    const handleCancel = () => {
      navigate("/profile");
    };
    const handleSubmit = () => {
      navigate("/profile");
        updateAnnonce2();
    }
    const handleCheckboxChange = () => {
      setShowPaymentPopup(!showPaymentPopup);
    };
    const handleWeeksChange = (e) => {
      setNumberOfWeeks(parseInt(e.target.value));
    };
  
    // const submitPaymentForm = () => {
    //   // Perform payment processing with cardNumber, expiryDate, and securityCode
    //   // You can add your logic here to handle the payment details
    //   console.log("Payment submitted:", cardNumber, expiryDate, securityCode);
    //   alert("Payment submitted successfully!");
      
      const getAnnonce2 = async () => {
        try {
          const token = localStorage.getItem('token');
          console.log(token.user);
          console.log("Sut mine lange løg J12C", id);
          const response = await fetch(`https://localhost:7181/api/Annonces/${id}`, {
            method: "GET",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${token}` },
          });
          console.log(response);
          
          if (!response.ok) {
            throw new Error("couldnt get ad");
            
          }
          const data = await response.json();
          
          console.log("data received:", data);
          return data;
        } catch (error) {
          console.log("Error:  ", error);
        }
        
      };    
      
      useEffect(()=>{
        getAnnonce2().then((data)=>{ 
            setPrice(data.price);
            setBeskrivelse(data.beskrivelse);
            setBilledsti(data.billedeSti);
            setEfManagerId(data.efManagerId);
            setStand(data.stand);
            setStudieretning(data.studieretning)
            setTitel(data.titel);
            setKategori(data.kategori);
            setNumberOfWeeks(data.numberOfWeeks);
            setShowPaymentPopup(data.showPaymentPopup);
        })

      }, []);


  const updateAnnonce2 = async () => {
    try {
      const token = localStorage.getItem('token');
      console.log(token.user);
      
      decodeToken();
      const response = await fetch(`https://localhost:7181/api/Annonces/${id}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json", Authorization: `Bearer ${token}` },
        body: JSON.stringify({
          Price: price,
          Titel: titel,
          Kategori: kategori,
          Beskrivelse: beskrivelse,
          Studieretning: studieretning,
          BilledeSti: billedesti,
          EfManagerId: efManagerId,
          Stand: stand,
          CheckboxValue: showPaymentPopup,
          NumberOfWeeks: numberOfWeeks,
        }),
      });
      console.log(response);
      if (!response.ok) {
        throw new Error("couldnt update ad");
      }
      const data = await response.json();
      console.log("data received:", data);
    } catch (error) {
      console.log("Error:  ", error);
    }
  };

  return (
    <div className="form-border">
       <label className="form-label">Opdatering af annonce</label>
      <form onSubmit={handleSubmit}>
        <input
          className="form-input"
          type="number"
          id="price"
          value={price}
          onChange={(e) => setPrice(e.target.value)}
          placeholder="Indsæt pris"
        />

        <input
          className="form-input"
          type="text"
          id="title"
          value={titel}
          onChange={(e) => setTitel(e.target.value)}
          placeholder="Indsæt titel"
        />

        <input
          className="form-input"
          type="text"
          id="category"
          value={kategori}
          onChange={(e) => setKategori(e.target.value)}
          placeholder="Indsæt kategori"
        />

        <textarea
          className="form-textarea"
          id="description"
          value={beskrivelse}
          onChange={(e) => setBeskrivelse(e.target.value)}
          placeholder="Indsæt beskrivelse"
        ></textarea>

        <input
          className="form-input"
          type="text"
          id="major"
          value={studieretning}
          onChange={(e) => setStudieretning(e.target.value)}
          placeholder="Indsæt studieretning"
        />

        <input
          className="form-input"
          type="text"
          id="image"
          value={billedesti}
          onChange={(e) => setBilledsti(e.target.value)}
          placeholder="Indsæt URL til billede"
        />

       {/* <input
          className="form-input"
          type="number"
          id="ManagerId"
          value={efManagerId}
          onChange={(e) => setEfManagerId(e.target.value)}
          placeholder="Indsæt EfManagerId"
        /> */}

        <select
          className="form-input"
          id="Condition"
          value={stand}
          onChange={(e) => setStand(e.target.value)}
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
        <label htmlFor="paymentCheckbox">Vis promovering </label>

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
                const input = e.target.value.replace(/\D/g, ""); // Remove non-numeric characters
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

      <div>
        <button className="submitbutton" type="submit">
          Gem ændringer
        </button>
        <button className="cancelbutton" onClick={handleCancel}>
            Annuller ændring
          </button>
          </div>
      </form>
    </div>
  );
}
