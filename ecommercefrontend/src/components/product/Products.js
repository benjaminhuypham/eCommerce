import React, { useContext, useState } from 'react'
import ProductItem from './ProductItem';
import { UserContext } from '../state/GlobalState'
import './Products.css'; 

export default function Products() {
    const state = useContext(UserContext); 
    const [products, setProducts] = state.productsAPI.products; 

    const handleChange = e => {
        const searchedProducts = products.filter(product => product.name.toLowerCase().includes(e.target.value.toLowerCase())); 
        if (searchedProducts === null) {}
        setProducts(searchedProducts); 
        console.log(searchedProducts);
    }

    return (
        <div className="Products">
            <input id="searchItems" type="text" placeholder="Search..." onChange={handleChange} />
            <div className="productItems">
                {products ? products.map(productItem => (
                    <ProductItem key={productItem.id} productItem={productItem}/>
                )) : <h2>No Result Found</h2>}
            </div>
        </div>
    )
}
