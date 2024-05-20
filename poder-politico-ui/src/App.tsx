import React, { useState } from 'react';
import ppower from './politicalPower.jpg';
import './App.css';
import Login from './Login';
import Register from './Register';

function App() {
  const [currentPage, setCurrentPage] = useState('home');

  const handleNavigation = (page: string) => {
    setCurrentPage(page);
  };

  return (
    <div className="App">
      <header className="App-header">
        <button onClick={() => handleNavigation('login')}>Log In</button>
        <button onClick={() => handleNavigation('register')}>Register</button>
      </header>

      <main className="App-Main-Content">
        {currentPage === 'home' && (
          <>
            <h2>Welcome to Poder Politico!!</h2>
            <section className='game-section'>
              <img src={ppower} className="main-game" alt="ppower-game-menu" />
              <button>PLAY NOW</button>
            </section>
            <section className='intro'>
              <p>This is the main content area where you can find information and interact with our services.</p>
            </section>
          </>
        )}
        {currentPage === 'login' && <Login />}
        {currentPage === 'register' && <Register />}
      </main>

      <footer className="App-footer">
        <div className="footer-menu">
          <h3>Menu</h3>
          {/* Add menu items here */}
        </div>
        <div className="footer-title">
          <h3>Website Title</h3>
        </div>
        <div className="footer-social">
          <h3>Contact & Social Media</h3>
          {/* Add contact info and social media links here */}
          <span>Email: example@example.com</span>
          <div className="social-icons">
            <a href="#"><i className="fab fa-facebook"></i></a>
            <a href="#"><i className="fab fa-twitter"></i></a>
            {/* Add more social media icons */}
          </div>
        </div>
      </footer>
    </div>
  );
}

export default App;
