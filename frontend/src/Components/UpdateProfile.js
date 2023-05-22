import{ useState, useEffect} from "react";
import {useNavigate} from "react-router-dom";

export function UpdateProfile() {
 const navigate = useNavigate();
 
    const [firstname, setFirstName] = useState();
      const [lastname, setLasName] = useState("");
      const [email, setEmail] = useState("");
      const [phonenumber, setPhoneNumber] = useState("");
      const [birthdate, setBirthdate] = useState("");
      const [university, setUniversity] = useState("");
      const [efManagerId, setEfManagerId] = useState("");


    
      const decodeToken = () =>{
        const t = localStorage.getItem('token');
        let user = parseJwt(t);
        setEfManagerId(user.EfManagerId)
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
        updateProfile1();
    }
    
    

    useEffect(()=>{
      const getProfile = async () => {
        try {
          const token = localStorage.getItem('token');
          console.log(token.user);
          const ManagerId = Number( decodeToken(token));
          

          const response = await fetch(`https://localhost:7181/api/Managers/${ManagerId}`, {
            method: "GET",
            headers: { "Content-Type": "application/json", Authorization: `Bearer ${token}` },
          });
          console.log(response);
          
          if (!response.ok) {
            throw new Error("couldnt get profile");
            
          }
          const data = await response.json();
          
          console.log("data received:", data);
          return data
        } catch (error) {
          console.log("Error:  ", error);
        }
        
      };    

     
        getProfile().then((data)=>{ 
            setFirstName(data.firstName);
            setLasName(data.lastName);
            setEmail(data.email);
            setPhoneNumber(data.phoneNumber);
            setUniversity(data.university)
            setBirthdate(data.birthdate)
            setEfManagerId(data.efManagerId);           

        });

      },[]);


  const updateProfile1 = async () => {
    try {
      const token = localStorage.getItem('token');
      console.log(token.user);
      const ManagerId = Number( decodeToken(token));
      decodeToken();
      const response = await fetch(`https://localhost:7181/api/Managers/${ManagerId}`, {
        method: "PUT",
        headers: { "Content-Type": "application/json", Authorization: `Bearer ${token}` },
        body: JSON.stringify({
          Firstname: firstname,
          Lastname: lastname,
          Email: email,
          phonenumber: phonenumber,
          birthdate: birthdate,
          University: university,
          EfManagerId: efManagerId,
        }),
      });
      console.log(response);
      if (!response.ok) {
        throw new Error("couldnt update profile");
      }
      alert('Profil er nu opdateret');
      const data = await response.json();
      console.log("data received:", data);
    } catch (error) {
      console.log("Error:  ", error);
    }
  };

  return (
    <div className="form-border">
      <form onSubmit={handleSubmit}>
        <input
          className="form-input"
          type="text"
          id="firstName"
          value={firstname}
          onChange={(e) => setFirstName(e.target.value)}
          placeholder="Fornavn"
        />

        <input
          className="form-input"
          type="text"
          id="lastname"
          value={lastname}
          onChange={(e) => setLasName(e.target.value)}
          placeholder="Efternavn"
        />
         <input
          className="form-input"
          type="text"
          id="Email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          placeholder="Email"
        />
        <input
              className="form-input"
              type="tel"
              id="PhoneNumber"
              value={phonenumber}
              onChange={(e) => {
                let formattedValue = e.target.value
                  .replace(/\s/g, "")
                  .replace(/(\d{2})/g, "$1 ")
                  .trim();

                if (formattedValue.length > 11) {
                  formattedValue = formattedValue.slice(0, 11);
                }

                setPhoneNumber(e.target.value);
              }}
              onKeyDown={(e) => {
                const key = e.key;
                const isNumeric = /^\d$/.test(key);
                const isBackspace = key === "Backspace";

                if (!isNumeric && !isBackspace) {
                  e.preventDefault();
                }
              }}
              placeholder="Phonenumber"
              maxLength={11}
              pattern="\d{2}\s?\d{2}\s?\d{2}\s?\d{2}"
        />
        <input
          className="form-input"
          type="text"
          id="major"
          value={university}
          onChange={(e) => setUniversity(e.target.value)}
          placeholder="Universitet"
        />



        <input
          className="form-input"
          type="date"
          id="Birthdate"
          value={birthdate}
          onChange={(e) => setBirthdate(e.target.value)}
          placeholder="Birthdate"
        />

        <div>   
        <button className="cancelbutton" onClick={handleCancel}>
          ANNULLER
        </button>
        <button className="submitbutton" type="submit">
          OPDATER PROFIl
        </button>
        </div>
      </form>
    </div>
  );
}
