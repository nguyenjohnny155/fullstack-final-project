import * as React from 'react';
import { styled } from '@mui/material/styles';
import Card from '@mui/material/Card';
import CardHeader from '@mui/material/CardHeader';
import CardMedia from '@mui/material/CardMedia';
import CardContent from '@mui/material/CardContent';
import CardActions from '@mui/material/CardActions';
import Avatar from '@mui/material/Avatar';
import IconButton, { IconButtonProps } from '@mui/material/IconButton';
import Typography from '@mui/material/Typography';
import { red } from '@mui/material/colors';
import FavoriteIcon from '@mui/icons-material/Favorite';
import ShareIcon from '@mui/icons-material/Share';
import ExpandMoreIcon from '@mui/icons-material/ExpandMore';
import MoreVertIcon from '@mui/icons-material/MoreVert';
import Rating from '@mui/material/Rating';
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


export default function ProductCard({imageSrc, productName, productTitle, numStars, numReviews, price }) {
  const classes = useStyles();

  return (
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
  );
}

//{productTitle.length <= 31 ? productTitle: (productTitle.substr(0, 31) + "...")}