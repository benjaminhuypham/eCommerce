import axios from 'axios';
import React, { useState } from 'react'; 
import { Link } from 'react-router-dom';

export default function Register() {
    const [user, setUser] = useState({
        username: "",
        password: "",
        name: "", 
        address: "", 
        email: "",
        phoneNumber: ""
    })

    const [message, setMessage] = useState(""); 

    const handleChange = e => {
        const {name, value} = e.target; 
        setUser(prevState => ({ ...prevState, [name]: value }))     
    }

    const handleSubmit = async e => {
        e.preventDefault(); 
        try {
            const registerUrl = "https://localhost:44368/api/authentication"
            const res = await axios.post(registerUrl, user);
            if (res.data.status == 400) {
                setMessage("Username or email has been registered, please choose something different!"); 
                window.location.href = "/register"; 
            }
            else {
                setMessage("");
                window.location.href = "/login"; 
            }
        }
        catch (err) {
            alert(err.response.data.msg); 
        }
    }

    return (
        <div className="Login">
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    name="username"
                    required 
                    placeholder="Username"
                    value={user.username}
                    onChange={handleChange}
                /><br/>
                <input
                    type="password"
                    name="password"
                    required 
                    placeholder="Password"
                    value={user.password}
                    onChange={handleChange}
                /><br/>
                <input
                    type="text"
                    name="name"
                    required 
                    placeholder="Name"
                    value={user.name}
                    onChange={handleChange}
                /><br/>
                <input
                    type="text"
                    name="address"
                    required 
                    placeholder="Address"
                    value={user.address}
                    onChange={handleChange}
                /><br/>
                <input
                    type="text"
                    name="email"
                    required 
                    placeholder="Email"
                    value={user.email}
                    onChange={handleChange}
                /><br/>
                <input
                    type="text"
                    name="phoneNumber"
                    required 
                    placeholder="PhoneNumber"
                    value={user.phoneNumber}
                    onChange={handleChange}
                /><br/>
                {message ? <p>{message}</p> : null}
                <div className="row">
                    <button type="submit">Register</button>
                    <Link to="/Login">Login</Link>
                </div>
            </form>
        </div>
    )
}
