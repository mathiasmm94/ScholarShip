import React, { useState, useEffect } from "react";
import axios from "axios";
import "./CSS/RP.css";
import { ChatWindow } from "./ChatWindow";

export function RandomProducts() {
  const token = localStorage.getItem("token");
  const [randomProducts, setRandomProducts] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [isChatOpen, setIsChatOpen] = useState(false);

  const handleChatToggle = () => {
    setIsChatOpen(!isChatOpen);
  };
  
  useEffect(() => {
    getRandomProducts()
      .then(products => setRandomProducts(products))
      .catch(error => console.error(error));
  }, []);

  async function getRandomProducts() {
    try {
      const token = localStorage.getItem("token"); // Rettede fejlen her
      const response = await axios.get("https://localhost:7181/api/Annonces/CheckBoxValue?checkBoxValue=true");
      const allProducts = response.data;
      const randomIndices = generateRandomIndices(allProducts.length, 9);
      const randomProducts = randomIndices.map((index) => allProducts[index]);
      console.log(randomProducts);
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

  function handleAnnouncementClick(product) {
    setSelectedProduct(product);
  }

  function handleBackToSearchResults() {
    setSelectedProduct(null);
  }

  return (
    <div className="random-products-container">
      {selectedProduct ? (
        <div className="selected-announcement">
          <h2>{selectedProduct.titel}</h2>
          <img
            src={selectedProduct.billedeSti}
            alt={selectedProduct.titel}
            className="selected-announcement-image"
          />
          <p>Price: {selectedProduct.price} kr.</p>
          <p>Category: {selectedProduct.kategori}</p>
          <p>Description: {selectedProduct.beskrivelse}</p>
          <p>Study Direction: {selectedProduct.studieretning}</p>
          <p>Condition: {selectedProduct.stand}</p>
          <button className="back-to-search-button" onClick={handleBackToSearchResults}>
            Back to products
          </button>

          {token && (
          <div className="Chat">
            <div className="chat-buttons">
              <button className="toggle_chat_button" onClick={handleChatToggle}>
                {isChatOpen ? "Close Chat" : "Open Chat"}
              </button>

              {isChatOpen && (
                <div className="Chat">
                  <ChatWindow chatId={selectedProduct.chatRoomId} />
                </div>
              )}
            </div>
          </div>
        )}

        </div>
      ) : (
        <div>
          <div className="title-container-RP">
            <h1 className="Title">Udvalgte annoncer: </h1>
          </div>
          <div className="annonce-container-RP">
            <div className="annonce-list-RP">
              {randomProducts.map((product, index) => (
                <div
                  className="annonce-item-RP"
                  key={product.annonceId}
                  onClick={() => handleAnnouncementClick(product)}
                >
                  <h2>{product.titel}</h2>
                  <div className="annonce-details">
                    <img src={product.billedeSti} alt={product.titel} className="annonce-image-RP" />
                    <p className="annonce-price-RP">Price: {product.price} kr.</p>
                  </div>
                </div>
              ))}
            </div>
          </div>
        </div>
      )}
    </div>
  );
}

export default RandomProducts;
