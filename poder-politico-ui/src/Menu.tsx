import React from 'react';
import './Menu.css';

const Menu: React.FC = () => {
  return (
    <nav className="menu">
      <ul>
        <li><a href="/">Home</a></li>
        <li><a href="/login">Login</a></li>
        <li><a href="/register">Register</a></li>
      </ul>
    </nav>
  );
};

export default Menu;
