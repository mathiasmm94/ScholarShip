import React, { useState } from "react";
import "./CSS/SearchResult.css";


export function SearchResult(props) {
  const [selectedAnnouncement, setSelectedAnnouncement] = useState(null);
  const results = props.results;

  if (results.length === 0) {
    return <p>No results found.</p>;
  }

  const handleAnnouncementClick = (announcement) => {
    setSelectedAnnouncement(announcement);
  };



  if (selectedAnnouncement) {
    const annonceId = selectedAnnouncement.annonceId;
    fetch(`https://localhost:7181/api/chat/annonce/${annonceId}/owner`)
  .then(response => response.json())
  .then(data => {
    // Handle the retrieved owner data
    console.log(data); // Replace with your logic to display the owner's information
  })
  .catch(error => {
    console.error('Error:', error);
  });


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
        
      </div>
    );
  }

  return (
    <div className="annonce-list">
      {results.map((result) => (
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
  );
}
