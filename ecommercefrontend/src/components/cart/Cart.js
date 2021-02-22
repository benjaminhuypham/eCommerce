import React, { useContext, useState } from 'react'
import { UserContext } from '../state/GlobalState'
import CartItem from './CartItem';
import './Cart.css'; 

export default function Cart() {
    const state = useContext(UserContext); 
    const [cartItems] = state.cartState.cartItems;
    let intialTotalPrice = cartItems.reduce((acc, val) => acc + val.price, 0);

    const [totalPrice, setTotalPrice] = useState(intialTotalPrice); 

    const addTotalPrice = (price) => {
        setTotalPrice(prevState => prevState + price); 
    }

    const reduceTotalprice = (price) => {
        setTotalPrice(prevState => prevState - price); 
    }

    return (
        <div className="Cart">
            <div className="cartItems">
                {cartItems.map(cartItem => (
                    <CartItem key={cartItem.id} cartItem={cartItem} addTotalPrice={addTotalPrice} reduceTotalprice={reduceTotalprice} />
                ))}
            </div>
            <div className="cartTotal">
                <span>Total Price: ${totalPrice}</span>
                <button>Checkout</button>
            </div>
        </div>
    )
}
