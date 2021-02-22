import axios from 'axios';
import React, { useEffect, useState } from 'react'

export default function ProductsAPI() {
    const [products, setProducts] = useState([]); 

    const getProducts = async () => {
        const productsUrl = "https://localhost:44368/api/products"; 
        const res = await axios.get(productsUrl); 
        setProducts(res.data); 
    }

    useEffect(() => {
        getProducts(); 
    }, [])

    return {
        products: [products, setProducts]
    }
}
