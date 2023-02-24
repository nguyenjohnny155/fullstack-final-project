import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import Box from '@mui/material/Box';
import Toolbar from '@mui/material/Toolbar';
import Typography from '@mui/material/Typography';
import IconButton from '@mui/material/IconButton';
import MenuIcon from '@mui/icons-material/Menu';
import SwipeableDrawer from '@mui/material/SwipeableDrawer';
import List from '@mui/material/List';
import Divider from '@mui/material/Divider';
import ListItem from '@mui/material/ListItem';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import { makeStyles } from '@mui/styles';
import { createTheme, ThemeProvider } from '@mui/material/styles';
import HomeIcon from '@mui/icons-material/Home';
import WhatshotIcon from '@mui/icons-material/Whatshot';
import ShuffleIcon from '@mui/icons-material/Shuffle';

import CollectionsIcon from '@mui/icons-material/Collections';
import SearchIcon from '@mui/icons-material/Search';
import ClassIcon from '@mui/icons-material/Class';
import AppsIcon from '@mui/icons-material/Apps';
import ConstructionIcon from '@mui/icons-material/Construction';
import PersonAddIcon from '@mui/icons-material/PersonAdd';
import LoginIcon from '@mui/icons-material/Login';

const useStyles = makeStyles((theme) => ({
  root: {
    flexGrow: 1,
  },
  
}));

const theme = createTheme({});

export default function ButtonAppBar() {

  const [state, setState] = React.useState({
    top: false,
    left: false,
    bottom: false,
    right: false,
  });

  const toggleDrawer = (anchor, open) => (event) => {
    if(event && event.type === 'keydown' && (event.key === 'Tab' || event.key === 'Shift')){
      return;
    }

    setState({ ...state, [anchor]: open});
  };

  const list = (anchor) => (
    <Box
      sx={{ width: anchor === 'top' || anchor === 'bottom' ? 'auto' : 250}}
      role="presentation"
      onClick={toggleDrawer(anchor, false)}
      onKeyDown={toggleDrawer(anchor, false)}
    >
      <List>
        {['Home', 'Trending', 'Random', 'Images', 'Search', 'Browse', 'Apps'].map((text, index) => (
          <ListItem key={text} disablePadding>
            <ListItemButton>
              <ListItemIcon>
                {
                  text === 'Home' ? <HomeIcon/> : 
                  text === 'Trending' ? <WhatshotIcon/> : 
                  text === 'Random' ? <ShuffleIcon/> : 
                  text === 'Images' ? <CollectionsIcon/> :
                  text === 'Search' ? <SearchIcon/> :
                  text === 'Browse' ? <ClassIcon/> :
                  text === 'Apps' ? <AppsIcon/> : 
                  <ConstructionIcon/>
                }
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItemButton>
          </ListItem>
        ))}
      </List>
      <Divider />
      <List>
        {['Sign In', 'Create Account'].map((text, index) => (
          <ListItem key={text} disablePadding>
            <ListItemButton>
              <ListItemIcon>
                {text === 'Sign In' ? <LoginIcon/> : 
                 text === 'Create Account' ? <PersonAddIcon/> :
                 <ConstructionIcon/>}
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItemButton>
          </ListItem>
       ))}
      </List>
      <Divider />
      <List>
        {['Discord'].map((text, index) => (
          <ListItem key={text} disablePadding>
            <ListItemButton>
              <ListItemIcon>
                 <ConstructionIcon/> {/* Discord Icon goes here */}
              </ListItemIcon>
              <ListItemText primary={text} />
            </ListItemButton>
          </ListItem>
       ))}
      </List>
    </Box>
  );

  return (
    <ThemeProvider theme={theme}>
    <Box sx={{ flexGrow: 1, width: '100vw', maxWidth: '100%'}} 
    >
      <AppBar position="sticky" style={{zIndex: 1251}}>
        <Toolbar>
              <IconButton
                size="large"
                edge="start"
                color="inherit"
                aria-label="menu"
                sx={{ mr: 2 }}
                onClick={toggleDrawer('left', true)} 
                
                >
              <MenuIcon />
              </IconButton>

          <Typography variant="h6" component="div" sx={{ flexGrow: 1 }}>
            IMAGE HERE
          </Typography>
        </Toolbar>
      </AppBar>
      <SwipeableDrawer
        anchor={'left'}
        open={state['left']}
        onClose={toggleDrawer('left', false)}
        onOpen={toggleDrawer('left', true)}
        style={{zIndex: 1250}}
        variant="temporary"
      >
        <Toolbar/>
        {list('left')}
      </SwipeableDrawer>
    </Box>
    </ThemeProvider>
  );
}