import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Search } from "./Components/Search.js";
import { Navbar } from "./Components/Navbar.js";
import { Footer } from "./Components/Footer.js";

import "./App.css";
import RandomProducts from "./Components/RandomProducts.js";

function App() {
  return (
    <Router>
      <Navbar />
      <div className="main">
        <Routes>
          <Route path="/" element={<Search />} />
        </Routes>
      </div>
      <RandomProducts/>
      <Footer />
    </Router>
  );
}

export default App;