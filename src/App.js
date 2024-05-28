// App.js file in poder-politico-tc2005B/src/App.js

import logo from './PP.jpg';
import './App.css';
import Login from './Login.js';
import Register from './Register.js';

function App() {
  return (
<div className="App">
      <header className="App-header">
        <button><a href='Login.js'>Log In</a></button> {/* Aqui no jalan los links por ahora */}
        <button><a href='Register.js'>Register</a></button> {/* Aqui no jalan los links por ahora */}
      </header>

      <main className="App-Main-Content">
            <h2>Welcome to Poder Politico!!</h2>
            <section className='game-section'>
              <img src={logo} className="main-game" alt="ppower-game-menu" />
              <button>PLAY NOW</button>
            </section>
            <section className='intro'>
              <p>This is the main content area where you can find information and interact with our services.</p>
            </section>

        <div className="login-register-container">
          <div className='right'> <Login /> </div>
          <div className='left'> <Register /></div>
        </div>

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
