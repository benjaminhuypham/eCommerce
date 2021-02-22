import React, { useContext, useState } from 'react'
import { UserContext } from '../state/GlobalState';
import './CartItem.css'; 

export default function CartItem({cartItem, addTotalPrice, reduceTotalprice}) {

    const state = useContext(UserContext); 
    const {removeItemFromCart} = state.cartState; 
    const [quantity, setQuantity] = useState(1); 

    const increment = () => {
        setQuantity(prevState => prevState + 1); 
        addTotalPrice(cartItem.price); 
    }

    const decrement = () => {
        setQuantity(prevState => prevState - 1); 
        reduceTotalprice(cartItem.price)
    }

    const removeHandleClick = () => {
        removeItemFromCart(CartItem); 
    }

    return (
        <div className="CartItem">
            <h2>{cartItem.name}</h2>
            <span>${cartItem.price * quantity}</span>
            <p>{cartItem.description}</p>
            <div>
                <button onClick={increment}>+</button>
                <span>Quantity: {quantity}</span> 
                <button onClick={decrement} disabled={quantity === 1}>-</button>
                <button onClick={removeHandleClick}>x</button>
            </div>
        </div>
    )
}
