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
import DeleteButtonReal from "./Components/deletebutton.js";
import { LogInForm } from "./Components/Login.js";
import { RegisterUser } from "./Components/Register.js";



function App() {
  return (
    <><Router>
      <Navbar />
      <Routes>
        <Route path="/" element={<Search />}> </Route>
        <Route path="/CreateAnnonce" element={<CreateAnnonce />} ></Route>
        <Route path="login" element={<LogInForm />}></Route>
        <Route path="register" element={<RegisterUser />}></Route>
      </Routes>
    </Router><>
        <DeleteButtonReal></DeleteButtonReal></></>

// <><Router>
      //   <Navbar />
      //   <Routes>
      //   </Routes>
      //   <div className="main">
      //     <Search />
      //   </div>
      // </Router>
    // </>

  );

}

export default App;

