import { ProductCard } from "./productCard";
import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";


export const ProfilePage = () => {
    const navigate = useNavigate();
    const [filteredAds, setFilteredAds] = useState([]);
    

    useEffect(() => {
      const delay = 100; // 0.5 seconds in milliseconds
    
      const timer = setTimeout(() => {
        fetchData();
      }, delay);
    
      return () => clearTimeout(timer); // Cleanup the timer on component unmount
    }, []);
    
    const fetchData = async () => {
      try {
        const token = localStorage.getItem('token');
        const efManagerId = Number( decodeToken(token));
  
        const response = await fetch("https://localhost:7181/api/Annonces", {
          method: "GET",
          headers: {
            "Content-Type": "application/json",
            Authorization: `Bearer ${token}`,
          },
        });
  
        if (!response.ok) {
          throw new Error("Could not fetch ads");
        }
  
        const data = await response.json();
        console.log("Data received:", data);
  
        // Filter ads based on the managerId
        const filteredAds = [];
        console.log(efManagerId)
        data.forEach((ad) => {
          if (ad.efManagerId === efManagerId) {
            console.log(filteredAds);
            filteredAds.push(ad);
          }
        });
        console.log("efManagerId values in data:", data.map((ad) => ad.efManagerId));
        setFilteredAds(filteredAds);
        console.log("filtered ads:",filteredAds);
      } catch (error) {
        console.log("Error:", error);
      }
    };
    

    const handleUpdateProfile = () => {
        navigate("/UpdateProfile");
      };


    return (
        <div>
        <button className="opdateProfileButton" onClick={handleUpdateProfile}>Update Profile</button>


        {filteredAds.map((ad) => (
        <ProductCard
          key={ad.id}
          Title={ad.titel}
          ImgSource={ad.billedeSti}
          category={ad.kategori}
          price={ad.price}
          stand={ad.stand}
          studieRetning={ad.studieretning}
          id={ad.annonceId}
          sx={ad.sx}
        />
      ))}
      </div>
    );
  };

function decodeToken(token) {
    const base64Url = token.split('.')[1];
    const base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    const jsonPayload = decodeURIComponent(
        window.atob(base64)
            .split('')
            .map(function (c) {
                return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
            })
            .join('')
    );

    const parsedToken = JSON.parse(jsonPayload);
    console.log(parsedToken.EfManagerId);
    return parsedToken.EfManagerId;
}