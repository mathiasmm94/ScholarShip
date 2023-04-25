import React from 'react';

export function SearchResult({ searchResults }) {
    console.log(searchResults)
  return (
    <div>
      <h2>Search Results</h2>
      {searchResults.length > 0 ? (
        <ul>
          {searchResults.map((result) => (
            <li key={result.id}>{result.name}</li>
          ))}
        </ul>
      ) : (
        <p>No results found.</p>
      )}
    </div>
  );
}


