import React from "react";
import "./CSS/Footer.css";

export function Footer() {
    return (
      <footer className="footer">
        <div className="footer-content">
          <div className="footer-section">
            <h3>Kontakt os</h3>
            <p>Adresse: Månen 666 </p>
            <p>Telefon: 12345678</p>
            <p>E-mail: info@BirteKjær.dk</p>
          </div>
  
          <div className="footer-section">
            <h3>Links</h3>
            <ul>
              <li><a href="/">Hjem</a></li>
              <li><a href="/om-os">Om os</a></li>
              <li><a href="/kontakt">Kontakt</a></li>
            </ul>
          </div>
  
          <div className="footer-section">
            <h3>Følg os</h3>
            <div className="social-media-icons">
              <a href="#"><i className="fab fa-facebook"></i></a>
              <a href="#"><i className="fab fa-twitter"></i></a>
              <a href="#"><i className="fab fa-instagram"></i></a>
            </div>
          </div>
        </div>
  
        <div className="footer-bottom">
          <p>&copy; 2023 ScholarShip. Alle rettigheder forbeholdes.</p>
          <br/>
        </div>
      </footer>
    );
  }