import './Register.css';

function Register() {
    return (
        <div className="register-container">
      <h2>Register</h2>
      <form className="register-form">
        <div className="form-group">
          <label htmlFor="Name">Name:</label>
          <input type="text" id="Name" name="Name" />
        </div>
        <div className="form-group">
          <label htmlFor="Surname">Surname:</label>
          <input type="text" id="Surname" name="Surname" />
        </div>
        <div className="form-group">
          <label htmlFor="Email">Email:</label>
          <input type="email" id="Email" name="Email" />
        </div>
        <div className="form-group">
          <label htmlFor="Password">Password:</label>
          <input type="password" id="Password" name="Password" />
        </div>
        <button type="submit">Sign Up</button>
      </form>
    </div>
    );
}