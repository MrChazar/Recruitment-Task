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
            <Result />
          </div>
      </div>
      
      <Navbar bg="dark" expand="lg">
        <Container>
            <Navbar.Brand href='https://github.com/MrChazar' className="text-white">Zadanie Wykonane Przez Jakuba Wieśniak - MrChazar</Navbar.Brand>
        </Container>
      </Navbar>
      
    </div>
  );
}

export default App;
