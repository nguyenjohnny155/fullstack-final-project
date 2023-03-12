import React, {useEffect, useState} from 'react';
import ButtonAppBar from '../components/navbar/Navbar';
import ProductCard from '../components/cards/ProductCard.tsx';
import Box from '@mui/material/Box';


export default function HomePage() {

    const [shopData, setShopData] = useState(null);

    const loadPage = async() => {
        const data = await fetch('/api/Shop')
         .then((response) => {
            return response.json().then((data) =>{
                setShopData(data);
                return data;
            })
         })
         .catch((error) => {
            console.log(error);
         });

        return data;
    };

    let ignore = false;
    useEffect(() => {
        if(!ignore) loadPage()
        return () => { ignore = true; }
    }, []);

    function getProductCardList(){
        let productCardList = null;
        if(shopData != null){
            productCardList = shopData.map((item, index) =>{
                return (<ProductCard key={index}
                            itemId={item.id}  
                            imageSrc={item.s3BaseUrl}
                            productName={item.itemName}
                            productTitle={item.itemName}
                            numStars={item.rating}
                            numReviews={item.numReviews}
                            price={item.itemBasePrice}
                        />  
                        )
                }
            )
        }
        return productCardList;
    }

    return (
        <div>
            <ButtonAppBar/>
            <Box style={{marginTop: '10px', marginLeft: '260px', marginRight: '260px'}}> 
                <div style={{
                    display:'flex',
                    justifyContent: 'space-between',
                    alignItems: 'center',
                    maxWidth: '100%'
                }}>

                {getProductCardList()}

                </div>
            </Box>
        </div>
    )
}