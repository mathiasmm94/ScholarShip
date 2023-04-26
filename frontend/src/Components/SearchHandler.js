import React, { useState } from "react";
import axios from "axios";
import { Searchbar } from "./Searchbar";
import { SearchResult } from "./SearchResult";
import { SearchButton } from "./SearchButton";

export function SearchHandler(props) {
  const [searchKeyword, setSearchKeyword] = useState("");
  const [searchResults, setSearchResults] = useState([]);

  const handleSearch = async (searchTerm) => {
    const response = await axios.get(
      `http://localhost:5238/api/search/${searchTerm}`
    );
    setSearchResults(response.data);
  };

  return (
    <div>
      <Searchbar onSearch={setSearchKeyword} />
      <SearchButton onSearch={() => handleSearch(searchKeyword)} />
      <SearchResult results={searchResults} />
    </div>
  );
}
