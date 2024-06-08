import React, { useRef, useEffect, useState } from 'react';
import logo from './PP.jpg';
import './App.css';
import Login from './Login.js';
import Register from './Register.js';
import { AuthContext, AuthProvider } from './AuthContext';
import InterpretacionGrafica from './indexai.js'; // Corrected import name
import './App.css';

function AppContent() {
  // Session auth and LogOut
  const { isAuthenticated, setIsAuthenticated } = React.useContext(AuthContext);

  const handleLogout = () => {
    setIsAuthenticated(false);
  };

  // References management
  const loginRef = useRef(null);
  const registerRef = useRef(null);

  const scrollToLogin = () => {
    loginRef.current.scrollIntoView({ behavior: 'smooth' });
  };
  const scrollToRegister = () => {
    registerRef.current.scrollIntoView({ behavior: 'smooth' });
  };

  // Data chart creation 
  const [data, setData] = useState([]);

    useEffect(() => {
        axios.get('http://localhost:3000/api/data')
            .then(response => {
                setData(response.data);
            })
            .catch(error => {
                console.error('There was an error fetching the data!', error);
            });
    }, []);

  return (
    <div className="App">
      <header className="App-header">
        {!isAuthenticated ? (
          <>
            <button onClick={scrollToLogin}>Log In</button>
            <button onClick={scrollToRegister}>Register</button>
          </>
        ) : (
          <div className="logout-container">
            <button className="logout-button" onClick={handleLogout}>Logout</button>
          </div>
        )}
      </header>

      <main className="App-Main-Content">
        <h2>Welcome to Poder Politico!!</h2>
        <section className='game-section'>
          <img src={logo} className="main-game" alt="ppower-game-menu" />
        </section>
        <section className='intro'>
          {/* Additional content can be added here */}
        </section>
        {!isAuthenticated ? (
          <div className="login-register-container">
            <div className='right' ref={loginRef}><Login /></div>
            <div className='left' ref={registerRef}><Register /></div>
          </div>
        ) : (
          <>
            <button><a href='https://peltre.itch.io/political-power'>Get started the game!</a></button>
            <div className='data-ai'> 
              <div className='interpretacion-AI'> <InterpretacionGrafica /> </div> 
              <div className='data-chart'>
                <h1>Data from MS SQL Server</h1>
                <Chart data={data} />
                </div>
            </div> 
          </>
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
          <span>Email: example@example.com</span>
          <div className="social-icons">
            {/* Social media icons can be added here */}
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
