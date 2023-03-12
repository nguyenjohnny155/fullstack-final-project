import * as React from 'react';
import Card from '@mui/material/Card';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import Typography from '@mui/material/Typography';
import Rating from '@mui/material/Rating';
import { Link } from 'react-router-dom';
import { makeStyles } from '@mui/styles';

const useStyles = makeStyles((theme) => ({
  ratingsReviews: {
    display: 'flex',
    alignItems: 'center'
  },
  titleStyle:{
    paddingLeft: 2,
    overflow: 'hidden',
    textOverflow: 'ellipsis',
    whiteSpace: 'nowrap'
  },
  priceStyle:{
    paddingLeft: 2
  }

}));


export default function ProductCard({itemId, imageSrc, productName, productTitle, numStars, numReviews, price }) {
  const classes = useStyles();

  return (
    <Link to={`/Item?id=${itemId}`}>
      <Card sx={{ maxWidth: 330 }}>
        <CardMedia
          component="img"
          height="230"
          image={imageSrc}//"/static/images/cards/paella.jpg"
          alt={productName}
        />

        <CardContent style={{padding: 5}}>
          <Typography className={classes.titleStyle} variant="h6" component="h2" align="left">
            {productTitle}
          </Typography>

          <div className={classes.ratingsReviews}>
            <Rating name="read-only" value={numStars} precision={0.5} readOnly/>

            <Typography variant="subtitle1" color="textSecondary" align="left">
              ({numReviews} reviews)
            </Typography>
          </div>

          <Typography className={classes.priceStyle} variant="h6" component="p" align="left">
            ${price.toFixed(2)}
          </Typography>
        </CardContent>
      </Card>
    </Link>
  );
}

//{productTitle.length <= 31 ? productTitle: (productTitle.substr(0, 31) + "...")}