import React, { useState } from 'react'

export default function CartState() {
    const [cartItems, setCartItems] = useState([]);

    const addItemToCart = productItem => {
        if (!cartItems.includes(productItem)) {
            setCartItems(prevState => [...prevState, productItem]);
        } 
    }

    const removeItemFromCart = productItem => {
        const updatedCartItems = cartItems.filter(item => item !== productItem);
        setCartItems(updatedCartItems); 
    }

    return {
        cartItems: [cartItems, setCartItems], 
        addItemToCart, 
        removeItemFromCart
    }
}
