import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";
import { Search } from "./Components/Search.js";
import { Navbar } from "./Components/Navbar.js";

import "./App.css"
import { CreateAnnonce } from "./Components/CreateAnnonce.js";
import { LogInForm } from "./Components/Login.js";
import { RegisterUser } from "./Components/Register.js";
import { ProfilePage } from "./Components/ProfilePage.js";
import { UpdateAnnonce } from "./Components/UpdateAnnonce.js";



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
      </Routes>
    </Router>
    <UpdateAnnonce /></>


  );

}

export default App;

