import React from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { Search } from "./Components/Search.js";
import { Navbar } from "./Components/Navbar.js";
import { Footer } from "./Components/Footer.js";
import { LogInForm } from "./Components/Login.js";
import { RegisterUser } from "./Components/Register.js";
import { CreateAnnonce } from "./Components/CreateAnnonce.js";
import RandomProducts from "./Components/RandomProducts.js";


import "./App.css";

function App() {
  return (
   
    <><Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Search />}> </Route>
        <Route path="/CreateAnnonce" element={<CreateAnnonce />}></Route>
        <Route path="login" element={<LogInForm />}></Route>
        <Route path="register" element={<RegisterUser />}></Route>
        <Route path="/profile" element={<ProfilePage />}></Route>
        <Route path="/opdaterAnnonces/:id" element={<UpdateAnnonce  />}></Route>
      </Routes>

      <RandomProducts/>
      
      <Footer />
    </Router>
    </>


  );
  
}

export default App;
