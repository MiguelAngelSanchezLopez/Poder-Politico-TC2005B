import './Register.css';
import React, { useState } from 'react';

function Register() {

    const [name, setName] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
    const [success, setSuccess] = useState('');

    const handleSubmit = async (event) => {
        event.preventDefault();
        setError('');
        setSuccess('');

        try {
            const response = await fetch('http://localhost:3000/api/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name, email, password }),
            });

            const data = await response.json();

            if (response.ok) {
                setSuccess('Registration successful');
                // Reset form fields
                setName('');
                setEmail('');
                setPassword('');
            } else {
                setError(data.message || 'Registration failed');
            }
        } catch (error) {
            setError('An error occurred. Please try again.');
        }
    };

    return (
        <div className="register-container">
            <h2>Register</h2>
            {error && <p className="error">{error}</p>}
            {success && <p className="success">{success}</p>}
            <form className="register-form" onSubmit={handleSubmit}>
                <div className="form-group">
                    <label htmlFor="Name">Name:</label>
                    <input 
                        type="text" 
                        id="Name" 
                        name="Name" 
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        required 
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="Email">Email:</label>
                    <input 
                        type="email" 
                        id="Email" 
                        name="Email" 
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required 
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="Password">Password:</label>
                    <input 
                        type="password" 
                        id="Password" 
                        name="Password" 
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required 
                    />
                </div>
                <button type="submit">Sign Up</button>
            </form>
        </div>
    );
}

export default Register;
