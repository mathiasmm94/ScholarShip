import React from "react";
import {
  BrowserRouter as Router,
  Routes,
  // Route,
} from "react-router-dom";
import { Search } from "./Components/Search.js";
import { Navbar } from "./Components/Navbar.js";

import "./App.css"
import { CreateAnnonce } from "./Components/CreateAnnonce.js";
import DeleteButtonReal from "./Components/deletebutton.js";


function App() {
  return (
    
     
      <><CreateAnnonce />
      <DeleteButtonReal></DeleteButtonReal></>

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

