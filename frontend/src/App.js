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


function App() {
  return (
    // <><Router>
    //   <Navbar />
    //   <Routes>

    //   </Routes>
    //   <div className="main">
    //     <Search />
    //   </div>
    // </Router>
      <CreateAnnonce />
    // </>




  );

}

export default App;

