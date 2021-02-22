import React from 'react'
import { Route } from 'react-router-dom';
import Products from './product/Products'; 
import Login from './authentication/Login'; 
import Cart from './cart/Cart'; 
import Register from './authentication/Register';

export default function Pages() {
    return (
        <div className="Pages">
            <Route path="/products" component={Products} />
            <Route path="/login" component={Login} />
            <Route path="/cart" component={Cart} />
            <Route path="/register" component={Register} />
        </div>
    )
}
