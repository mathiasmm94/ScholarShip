import React, { useState } from 'react';
import axios from 'axios';

export function Searchbar() {
  const [searchTerm, setSearchTerm] = useState('');

  const handleSearch = async () => {
    try {
      const response = await axios.get(`http://localhost:5238/api/search/${searchTerm}`);
      console.log(response.data); // replace this with your desired logic
    } catch (error) {
      console.error(error);
    }
  };

  const handleInputChange = (event) => {
    setSearchTerm(event.target.value);
  };

  const handleKeyPress = (event) => {
    if (event.key === 'Enter') {
      handleSearch();
    }
  };

  return (
    <div>
      <input type="text" value={searchTerm} onChange={handleInputChange} onKeyPress={handleKeyPress} />
      <button onClick={handleSearch}>Search</button>
    </div>
  );
}

