import React from "react";
import './CSS/SearchResult.css'

export function SearchResult(props) {
  const results = props.results;

  if (results.length === 0) {
    return <p>No results found.</p>;
  }

  return (
    <div className="annonce-list">
      {results.map((result) => (
        <div key={result.annonceId} className="annonce-item">
          <img src={result.billedeSti} alt={result.titel} className="annonce-image" />
          <div className="annonce-details">
            <h2>{result.titel}</h2>
            <p>Price: {result.price} kr.</p>
            <p>Category: {result.kategori}</p>
            <p>Description: {result.beskrivelse}</p>
            <p>Study Direction: {result.studieretning}</p>
            <p>Condition: {result.stand}</p>
          </div>
        </div>
      ))}
    </div>
  );
}
