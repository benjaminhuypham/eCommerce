import axios from 'axios';
import React, { useState } from 'react'; 
import { Link } from 'react-router-dom';

export default function Login() {
    const [user, setUser] = useState({
        username: "",
        password: ""
    }); 
    
    const [message, setMessage] = useState(""); 

    const handleChange = e => {
        const {name, value} = e.target; 
        setUser(prevState => ({ ...prevState, [name]: value }))     
    }

    const handleSubmit = async e => {
        e.preventDefault(); 
        try {
            const registerUrl = "https://localhost:44368/api/authentication"
            const res = await axios.put(registerUrl, user);
            console.log(res.data.status); 
            if (res.data.status === 400) {
                setMessage("Username or password is incorrect, please try again!"); 
                window.location.href = "/login"; 
            }
            else {
                setMessage("");  
                window.location.href = "/";
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
                />
                {message !== null ? <p>{message}</p> : null}
                <div className="row">
                    <button type="submit">Login</button>
                    <Link to="/register">Register</Link>
                </div>
            </form>
        </div>
    )
}
