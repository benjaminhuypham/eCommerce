import React, { useContext, useState } from 'react'
import { UserContext } from '../state/GlobalState';
import './ProductItem.css'; 

export default function ProductItem({productItem}) {
    const state = useContext(UserContext)

    const {addItemToCart} = state.cartState; 

    const addHandleClick = () => {
        addItemToCart(productItem); 
    }

    return (
        <div className="ProductItem">
            <h2>{productItem.name}</h2>
            <span>${productItem.price}</span>
            <p>{productItem.description}</p>
            <div>
                <button onClick={addHandleClick}>Add</button>
                <button>View</button> 
            </div>
        </div>
    )
}
