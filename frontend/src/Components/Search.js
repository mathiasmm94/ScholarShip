import React from "react";
import {SearchHandler} from "./SearchHandler";
import "./CSS/Text.css"
import "./CSS/Search.css"

export function Search(props) {
  const headingStyle = {
    color: '#ffd604', // update the color property to #ffd604
    fontSize: '32px'
  };
  return (
    <div>
      <h1 style={headingStyle}>SEARCH COMPONENT</h1>
      <SearchHandler />
    </div>
  );
}

