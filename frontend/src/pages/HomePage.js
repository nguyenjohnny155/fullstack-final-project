import React, {useState} from 'react';
import ButtonAppBar from '../components/navbar/Navbar';
import ProductCard from '../components/cards/ProductCard.tsx';

import PhobGccMotherboard from '../assets/phobgcc-2.0.2-motherboard-only.png';
import PhobGccControllerBlack from '../assets/budget-phobgcc-2.0.2-controller-black.png';
import Box from '@mui/material/Box';


export default function HomePage() {

    const clickHandler = async() => {

        const data = await fetch('/api/Shop')
         .then((response) => {
            return response;
         })
         .catch((error) => {
            console.log(error);
         });

    };

    return (
        <div>
            <ButtonAppBar/>
            <Box style={{marginTop: '10px', marginLeft: '260px', marginRight: '260px'}}> {/* this will hold all the contents */}
                <div style={{
                    display:'flex',
                    justifyContent: 'space-between',
                    alignItems: 'center',
                    maxWidth: '100%'
                }}>

                <button type="button" onClick={clickHandler}> Click me! </button>

                <ProductCard 
                    imageSrc={PhobGccControllerBlack} 
                    productName="PhobGCC 2.0.2 Controller Black"
                    productTitle="PhobGCC 2.0.2 Controller Black"
                    numStars={4.5}
                    numReviews={10099}
                    price={249.99}
                    />

                <ProductCard 
                    imageSrc={PhobGccMotherboard} 
                    productName="PhobGcc Motherboard 2.0.2"
                    productTitle="PhobGCC Motherboard 2.0.2 (MOTHERBOARD ONLY)"
                    numStars={4.5}
                    numReviews={1399}
                    price={54.99}
                    />

                <ProductCard 
                    imageSrc={PhobGccControllerBlack} 
                    productName="PhobGCC 2.0.2 Controller Black"
                    productTitle="PhobGCC 2.0.2 Controller Black"
                    numStars={4.5}
                    numReviews={10099}
                    price={249.99}
                    />

                <ProductCard 
                    imageSrc={PhobGccControllerBlack} 
                    productName="PhobGCC 2.0.2 Controller Black"
                    productTitle="PhobGCC 2.0.2 Controller Black"
                    numStars={4.5}
                    numReviews={10099}
                    price={249.99}
                    />
                </div>
            </Box>
        </div>
    )
}