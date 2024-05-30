// App.js file in poder-politico-tc2005B/src
import React, { useContext, useRef } from 'react';
import logo from './PP.jpg';
import './App.css';
import Login from './Login.js';
import Register from './Register.js';
import { AuthContext, AuthProvider } from './AuthContext';
import interpretacionGrafica from './solucionAI.js';

function AppContent() {
  // Session auth and LogOut
  const { isAuthenticated, setIsAuthenticated } = React.useContext(AuthContext);

  const handleLogout = () => {
      setIsAuthenticated(false);
  };
  // References mngmnt
  const loginRef = useRef(null);
  const registerRef = useRef(null);

  const scrollToLogin = () => {
    loginRef.current.scrollIntoView({ behavior: 'smooth' });
  };
  const scrollToRegister = () => {
    registerRef.current.scrollIntoView({ behavior: 'smooth' });
  };




  return (

    <div className="App">
      <header className="App-header">
        {!isAuthenticated ?  (
        <>
          <button onClick={scrollToLogin}>Log In</button>
          <button onClick={scrollToRegister}>Register</button>
        </>
      ) : (
          <button onClick={handleLogout}> Logout </button>
      )}
      </header>

      <main className="App-Main-Content">
            <h2>Welcome to Poder Politico!!</h2>
            <section className='game-section'>
              <img src={logo} className="main-game" alt="ppower-game-menu" />
              {/* <button>PLAY NOW</button> */}
            </section>
            <section className='intro'>
              <p>This is the main content area where you can find information and interact with our services.</p>
            </section>
            {!isAuthenticated ? (
              <div className="login-register-container">
                <div className='right' ref={loginRef}><Login /></div>
                <div className='left' ref={registerRef}><Register /></div>
              </div>
        ) : (
            <button><a href='some-other-page'>Go to Another Page</a></button>
        )}
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


function App() {
  return (
    <AuthProvider>
      <AppContent />
    </AuthProvider>
  );
}

export default App; 
