import React from "react";

export function SearchResult(props) {
  const results = props.results;

  if (results.length === 0) {
    return <p>No results found.</p>;
  }

  return (
    <ul>
      {results.map((result) => (
        <li key={result.annonceId}>
          <h3>{result.titel}</h3>
          <p>Price: {result.price}</p>
          <p>Category: {result.kategori}</p>
          <p>Description: {result.beskrivelse}</p>
          <p>Study field: {result.studieretning}</p>
          <p>Condition: {result.stand}</p>
          <img src={result.billedeSti} alt={result.titel} />
        </li>
      ))}
    </ul>
  );
}
