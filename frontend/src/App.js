import React, { useState } from 'react';
import axios from 'axios';
import { Searchbar } from './Components/Searchbar';
import { SearchResult } from './Components/SearchResult';

function App() {
  const [searchResults, setSearchResults] = useState([]);

  const handleSearch = async (query) => {
    try {
      const response = await axios.get(`http://localhost:5238/api/search/${query}`);
      setSearchResults(response.data);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <h1>Search App</h1>
      <Searchbar onSearch={handleSearch} />
      <SearchResult searchResults={searchResults} />
    </div>
  );
}

export default App;
