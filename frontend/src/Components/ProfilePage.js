import { ProductCard } from "./productCard";
import { useState, useEffect } from "react";

export const ProfilePage = () => {
    const [filteredAds, setFilteredAds] = useState([]);
  
    useEffect(() => {
      fetchData();
    }, []);
  
    const fetchData = async () => {
      try {
        const token = localStorage.getItem('token');
        const managerId = decodeToken(token);
  
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
        const filteredAds = data.filter((ad) => ad.managerID === managerId);
        setFilteredAds(filteredAds);
      } catch (error) {
        console.log("Error:", error);
      }
    };
  
    return (
      <>
        <label>Fisse</label>
        {filteredAds.map((ad) => (
          <ProductCard key={ad.id} Title={ad.Title} ImgSource={ad.ImgSource} price={ad.price} />
        ))}
      </>
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
    return parsedToken.EfManagerId;
}