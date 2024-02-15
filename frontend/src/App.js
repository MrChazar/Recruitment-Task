import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Navbar, Container} from 'react-bootstrap';
import DateForm from './components/DateForm.jsx';
import Result from './components/Result.jsx';

function App() {
  return (
    <div className="App">
      
      <Navbar bg="dark" expand="lg">
        <Container>
            <Navbar.Brand className="text-white">Recruitment Task</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
        </Container>
      </Navbar>

      <div className="container d-flex justify-content-center align-items-center vh-100">
          <div className="content">
            <DateForm />
          </div>
      </div>

      <div className="container d-flex justify-content-center align-items-center mb-1">
          <div className="content">
            <Result />
          </div>
      </div>
      
      <footer class="navbar navbar-dark bg-dark sticky-bottom">
          <div class="container">
              <span class="text-white"> <a className="text-white text-decoration-none" href='https://github.com/MrChazar' >Zadanie Wykonane Przez Jakuba Wieśniak - MrChazar</a></span>
          </div>
      </footer>
      
    </div>
  );
}

export default App;
