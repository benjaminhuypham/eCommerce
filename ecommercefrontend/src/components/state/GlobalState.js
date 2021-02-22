import React, { createContext } from 'react'; 
import ProductsAPI from '../api/ProductsAPI'; 
import CartState from './CartState';

export const UserContext = createContext(); 

export default function GlobalState({children}) {

    const state = {
        productsAPI: ProductsAPI(), 
        cartState: CartState() 
    }

    return (
        <UserContext.Provider value={state}>
            {children}
        </UserContext.Provider>
    )
}
