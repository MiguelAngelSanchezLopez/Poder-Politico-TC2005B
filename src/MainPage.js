// MainPage.js
import React from 'react';
import logo from './PP.jpg';

function MainPage() {
  return (
    <div>
      <main className="App-Main-Content">
            <h2>Welcome to Poder Politico!!</h2>
            <section className='game-section'>
              <img src={logo} className="main-game" alt="ppower-game-menu" />
              <button>PLAY NOW</button>
            </section>
            <section className='intro'>
              <p>This is the main content area where you can find information and interact with our services.</p>
            </section>
        </main>
    </div>
  );
}

export default MainPage;
