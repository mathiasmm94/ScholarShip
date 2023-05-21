import React, { useState, useEffect } from "react";
import axios from "axios";
import "./CSS/RP.css";

export function RandomProducts() {
  const [randomProducts, setRandomProducts] = useState([]);

  useEffect(() => {
    getRandomProducts()
      .then(products => setRandomProducts(products))
      .catch(error => console.error(error));
  }, []);

  async function getRandomProducts() {
    try {
      const response = await axios.get('https://localhost:7181/api/Annonces');
      const allProducts = response.data;
      const randomIndices = generateRandomIndices(allProducts.length, 9); // Generer 9 tilfældige indekser
      const randomProducts = randomIndices.map(index => allProducts[index]); // Få de tilfældige produkter
      return randomProducts;
    } catch (error) {
      console.error("Fejl under hentning af produkter:", error);
      return [];
    }
  }

  function generateRandomIndices(maxRange, count) {
    const indices = Array.from({ length: maxRange }, (_, index) => index); // Opret et array med alle mulige indekser
    const randomIndices = [];
    while (randomIndices.length < count && indices.length > 0) {
      const randomIndex = Math.floor(Math.random() * indices.length); // Generer et tilfældigt indeks
      randomIndices.push(indices[randomIndex]); // Tilføj det tilfældige indeks til listen
      indices.splice(randomIndex, 1); // Fjern det tilfældige indeks fra det oprindelige array
    }
    return randomIndices;
  }

  function handleAnnouncementClick(result) {
    // Behandle klik på en annonce
    console.log("Klik på annonce:", result);
  }

  return (
    <div>
      <div className="title-container-RP">
        <h1 className="Title">Se også:</h1>
      </div>
      <div className="annonce-container-RP">
        <div className="annonce-list-RP">
          {randomProducts.map((result, index) => (
            <div
              className="annonce-item-RP"
              key={result.annonceId}
              onClick={() => handleAnnouncementClick(result)}
            >
              <h2>{result.titel}</h2>
              <div className="annonce-details">
                <img src={result.billedeSti} alt={result.titel} className="annonce-image-RP" />
                <p className="annonce-price-RP">Price: {result.price} kr.</p>
              </div>
            </div>
          ))}
        </div>
      </div>
    </div>
  );
}

export default RandomProducts;
