import React, { useContext } from 'react'; 
import {Link, Switch} from 'react-router-dom'; 
import { UserContext } from './state/GlobalState';
import './Header.css'; 

export default function Header() {
    const state = useContext(UserContext); 
    const [cartItemsLength] = state.cartState.cartItems;

    return (
        <Switch>
            <div className="Header">
                <ul className="nav-links">
                    <li id="products"><Link to="/products">Products</Link></li>
                    <li id="login"><Link to="/login">Login</Link></li>
                    <div id="cart">
                        <span id="cart-quantity">{cartItemsLength.length}</span>
                        <li><Link to="/cart">Cart</Link></li>
                    </div>
                </ul>
            </div>
        </Switch>
    )
}
