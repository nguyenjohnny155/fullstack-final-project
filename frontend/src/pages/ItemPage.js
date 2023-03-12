import React, { useEffect, useState } from 'react';
import ButtonAppBar from '../components/navbar/Navbar';
import Box from '@mui/material/Box'

export default function ItemPage(){
    const queryParameters = new URLSearchParams(window.location.search)
    const id = queryParameters.get("id")
    const [itemData, setItemData] = useState();

    const fetchHandler = async() => {
        const data = await fetch(`/api/Shop/${id}`)
         .then((response) => {
            return response.json().then((data) =>{
                setItemData(data);
                return data;
            })
         })
         .catch((error) => {
            console.log(error);
         });

        console.log(data);
        return data;
    };
    
    let ignore = false;
    useEffect(() => {
        if(!ignore) fetchHandler()
        return () => { ignore = true; }
    }, []);

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


                </div>
            </Box>
      </div>
    )
}