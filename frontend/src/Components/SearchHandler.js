import React, { useState, useEffect } from "react";
import axios from "axios";
import {Searchbar} from "./Searchbar";
import {SearchResult} from "./SearchResult";

export function SearchHandler(props) {
  const [searchKeyword, setSearchKeyword] = useState("");
  const [searchResults, setSearchResults] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      const response = await axios.get(
        `http://localhost:5238/api/search/${searchKeyword}`
      );
      setSearchResults(response.data);
    };

    if (searchKeyword) {
      fetchData();
    }
  }, [searchKeyword]);

  return (
    <div>
      <Searchbar onSearch={setSearchKeyword} />
      <SearchResult results={searchResults} />
    </div>
  );
}

