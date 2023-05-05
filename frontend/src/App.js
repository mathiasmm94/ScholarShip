import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  Route,
} from "react-router-dom";
import {Search} from "./Components/Search.js";
import {Navbar} from "./Components/Navbar.js";

import "./App.css"
import { LogInForm } from "./Components/Login.js";


function App() {
  return (
    <Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Search/>}> </Route>
        <Route path="login" element={<LogInForm/>}></Route>
      </Routes>
    </Router>
  );
  
}

export default App;

