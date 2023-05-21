import React, { useState } from "react";
import "./CSS/SearchResult.css";
import "./CSS/SearchButton.css";
import  {ChatWindow}  from "./ChatWindow";


export function SearchResult(props) {
  const [selectedAnnouncement, setSelectedAnnouncement] = useState(null);
  const [currentPage, setCurrentPage] = useState(1);
  const [selectedValue, setSelectedValue] = useState(10); // Startværdi er 10
  const productsPerPage = selectedValue;
  

  const results = props.results;

  if (results.length === 0) {
    return <p>No results found.</p>;
  }


  const handleAnnouncementClick = (announcement) => {
    setSelectedAnnouncement(announcement);
  };

  const indexOfLastProduct = currentPage * productsPerPage;
  const indexOfFirstProduct = indexOfLastProduct - productsPerPage;
  const currentProducts = results.slice(indexOfFirstProduct, indexOfLastProduct);

  const prevPage = () => {
    if (currentPage > 1) {
      setCurrentPage(currentPage - 1);
    }
  };

  const nextPage = () => {
    if (currentPage < Math.ceil(results.length / productsPerPage)) {
      setCurrentPage(currentPage + 1);
    }
  };

  if (selectedAnnouncement) {
    const annonceId = selectedAnnouncement.annonceId;

  const chatroom = fetch(`https://localhost:7181/api/chat/annonce/${annonceId}/owner`)
  .then(response => response.json())
  .then(data => {
    // Handle the retrieved owner data
    //console.log(data); // Replace with your logic to display the owner's information
  })
  .catch(error => {
    console.error('Error:', error);
    
  });
    const chatId = selectedAnnouncement.chatRoomId
    console.log(chatId);
    return (
      <div className="selected-announcement">
        <h2>{selectedAnnouncement.titel}</h2>
        <img
          src={selectedAnnouncement.billedeSti}
          alt={selectedAnnouncement.titel}
          className="selected-announcement-image"
        />
        <p>Price: {selectedAnnouncement.price} kr.</p>
        <p>Category: {selectedAnnouncement.kategori}</p>
        <p>Description: {selectedAnnouncement.beskrivelse}</p>
        <p>Study Direction: {selectedAnnouncement.studieretning}</p>
        <p>Condition: {selectedAnnouncement.stand}</p>
        <button className="back-to-search-button" onClick={() => setSelectedAnnouncement(null)}>
          Back to search results
        </button>
        
        <ChatWindow chatId={chatId}/>
        
      </div>
    );
  }

  return (
    <div>  
    

      <div className="annonce-list">

        {currentProducts.map((result) => (
          <div
            className="annonce-item"
            key={result.annonceId}
            onClick={() => handleAnnouncementClick(result)}
          >
            <div className="annonce-details">
              <img src={result.billedeSti} alt={result.titel} className="annonce-image" />
              <h2>{result.titel}</h2>
              <p className="annonce-price">Price: {result.price} kr.</p>
            </div>
          </div>
        ))}
      </div>

      <div className="pagination">

          <div className="button-border">
        <button className="page-button" onClick={prevPage} disabled={currentPage === 1}>
          Previous
        </button>
        <button className="page-button" onClick={nextPage} disabled={currentPage === Math.ceil(results.length / productsPerPage)}>
          Next
        </button>
        </div>

        <p className="pageNumber">
        Side {currentPage} af {Math.ceil(results.length/productsPerPage)}
      </p>
        
        <select className="dropdown" value={selectedValue} onChange={(e) => setSelectedValue(parseInt(e.target.value))}>
          <option value={5}> 5 </option>
          <option value={10}> 10 </option>
          <option value={15}> 15 </option>
          <option value={20}> 20 </option>
          <option value={25}> 25 </option>
        </select>
        
    
      </div>
    </div>

  );
}

