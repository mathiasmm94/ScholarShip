import React from "react";

export function Searchbar(props) {
  const handleSearch = (event) => {
    props.onSearch(event.target.value);
  };

  return (
    <input
      type="text"
      placeholder="Enter search keyword"
      onChange={handleSearch}
    />
  );
}

