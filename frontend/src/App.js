import './App.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Navbar, Container} from 'react-bootstrap';
import DateForm from './components/DateForm.jsx';
import Result from './components/Result.jsx';

function App() {
  
  const result = {
    numberOfAppearances: 5,
    todayDate: '2023-09-01',
    firstAppearance: '2023-08-02',
    previousApperance: '2023-08-30',
    nextApperance: '2023-09-06'
  };

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
            {result !== null && <Result result={result} />}
          </div>
      </div>
      
      <Navbar bg="dark" expand="lg">
        <Container>
            <Navbar.Brand href='https://github.com/MrChazar' className="text-white">Wykonane przez Jakuba Wieśniaka</Navbar.Brand>
        </Container>
      </Navbar>
      
    </div>
  );
}

export default App;
