import './Login.css';
import React, { useState } from 'react';
import MainPage from './MainPage';

function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');
    const [isLoggedIn, setIsLoggedIn] = useState(false);

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError('');
        
        try {
            const response = await fetch('http://localhost:3000/api/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, password }),
            });

            const data = await response.json();

            if (response.ok) {
                // Handle successful login (e.g., redirect, save token)
                setSuccess('Login successful');
                setIsLoggedIn(true);  // Set login status to true
            } else {
                setError(data.message || 'Login failed');
            }
        } catch (error) {
            setError('An error occurred. Please try again.');
        }
    

        if (isLoggedIn === true) {
            return <MainPage />;
        }
    };

    return (
        <div className="login-container">
            <h2>Login</h2>
            {error && <p className="error">{error}</p>}
            <form className="login-form" onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="email">Email:</label>
                    <input 
                        type="email" 
                        id="email" 
                        name="email" 
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password:</label>
                    <input 
                        type="password" 
                        id="password" 
                        name="password" 
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                    />
                </div>
                <button type="submit" onClick={handleSubmit}>Login</button>
            </form>
        </div>
    );
}

export default Login;