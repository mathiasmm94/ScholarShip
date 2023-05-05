import React from "react";
import "./CSS/Searchbar.css";

export function Searchbar(props) {
  const handleSearch = (event) => {
    props.onSearch(event.target.value);
  };

  return (
    <input
      className="searchBarInput"
      type="text"
      placeholder="Søg på den varer du mangler"
      onChange={handleSearch}
    />
  );
}

