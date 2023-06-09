import { NavLink, useNavigate } from "react-router-dom";
import "./CSS/Navbar.css";

export function Navbar() {
  const token = localStorage.getItem("token");
  const navigate = useNavigate();

  function logout() {
    localStorage.removeItem("token");
    navigate("/");
  }

  function returnToHome(){
    navigate("/")
  }

  return (
    <nav className="nav_link">
      <div className="nav_bar">
        <img className="Logo" onClick={returnToHome} src="/images/LOGO.jpg" alt="Logo"/>

        <NavLink to="/CreateAnnonce" className="nav_button_sale" activeClassName="nav_button_active">
          Sælg dine bøger
        </NavLink>

        {token ? (
          <><button className="nav_button" onClick={logout}>
            Logout
          </button>
          <NavLink to="/profile" className="nav_profile"></NavLink></>
        ) : (
          <>
            <NavLink to="/login" className="nav_button" activeClassName="nav_button_active">
              Login
            </NavLink>
            <NavLink to="/register" className="nav_button" activeClassName="nav_button_active">
              Opret Bruger
            </NavLink>
          </>
        )}
      </div>
    </nav>
  );
}
