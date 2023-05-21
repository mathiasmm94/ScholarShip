import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Search } from "./Components/Search.js";
import { Navbar } from "./Components/Navbar.js";
import { Footer } from "./Components/Footer.js";
import { LogInForm } from "./Components/Login.js";
import { RegisterUser } from "./Components/Register.js";
import RandomProducts from "./Components/RandomProducts.js";


import "./App.css";

function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Search />} />
        <Route path="login" element={<LogInForm />} />
        <Route path="register" element={<RegisterUser />} />
      </Routes>

      <RandomProducts/>
      
      <Footer />
    </Router>
  );
}

export default App;
