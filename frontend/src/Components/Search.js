import React from "react";
import {SearchHandler} from "./SearchHandler";
import "./CSS/Text.css"
import "./CSS/Search.css"
import { Link } from "react-router-dom";

export function Search(props) {
  const headingStyle = {
    color: '#ffd604', // update the color property to #ffd604
    fontSize: '32px'
  };
  return (
    <div>
      <SearchHandler />
    </div>
  );
}

