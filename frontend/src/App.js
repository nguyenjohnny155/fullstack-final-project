import './App.css';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import ItemPage from './pages/ItemPage';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { useState } from 'react';
import { AuthContext } from './contexts/AuthContext';

function App() {

  const [getAuthToken, setAuthToken] = useState("");

  return (
      <BrowserRouter>
        <AuthContext.Provider value={{getAuthToken, setAuthToken}}>
      {/*<div className="App">*/}
          <Routes>
              <Route path="/Home" element={<HomePage/>}/>
              <Route path="/Sign In" element={<LoginPage/>}/>
              <Route path="/Item" element={<ItemPage/>}/>
          </Routes>
      {/*</div>*/}
        </AuthContext.Provider>
      </BrowserRouter>
  );
}

export default App;
