import './App.css';
import HomePage from './pages/HomePage';
import LoginPage from './pages/LoginPage';
import { BrowserRouter, Routes, Route } from "react-router-dom";

function App() {
  return (
    <BrowserRouter>
    {/*<div className="App">*/}
      <Routes>

        <Route path="/Home" element={<HomePage/>}/>
        <Route path="/Sign In" element={<LoginPage/>}/>
      </Routes>
    {/*</div>*/}
    </BrowserRouter>
  );
}

export default App;
