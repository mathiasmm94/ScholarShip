import { NavLink } from "react-router-dom";
import "./CSS/Navbar.css"


export function Navbar() {
  return (
    <nav className="nav_link"> 
      <div className="nav_bar">
        <img src="/images/LOGO.jpg" alt="Logo" />

      <NavLink to="/" className="nav_button_sale" exact activeClassName="nav_button_active" >
        Sælg dine bøger
      </NavLink>
      <NavLink to="/Login" className="nav_button" activeClassName="nav_button_active">
        Login
      </NavLink>
      <NavLink to="/Register" className="nav_button" activeClassName="nav_button_active">
        Opret Bruger
      </NavLink>
      </div>
    </nav>
  )
}
