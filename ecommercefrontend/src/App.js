import {BrowserRouter as Router } from 'react-router-dom';
import './App.css';
import Header from './components/Header';
import Pages from './components/Pages';
import GlobalState from './components/state/GlobalState';

function App() {
  return (
    <GlobalState>
      <Router>
        <Header />
        <Pages />
      </Router>
    </GlobalState>
  );
}

export default App;
