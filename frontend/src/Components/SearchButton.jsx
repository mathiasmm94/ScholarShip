import React from "react";
import './CSS/SearchButton.css'

export function SearchButton(props) {
    const handleClick = () => {
      props.onSearch();
    };
  
    return <button className="search-button" onClick={handleClick}>Søg</button>;
  }
  
