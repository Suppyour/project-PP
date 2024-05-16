import './App.css'
import CreateNavigation from './components/CreateNavigation'
import LoginForm from './components/LoginForm'
import RegistrationForm from './components/RegistrationForm'
import { VisibilityProvider } from './components/VisibilityContext';

function App() {
  return (
    <>
      <header>
        <CreateNavigation />
      </header>
      <main class="main-content">
        <VisibilityProvider>
          <LoginForm />
          <RegistrationForm />
        </VisibilityProvider>
      </main>
      <footer>
        <p>© PROFIT</p>
        <p>Сделано в качестве студенческого проекта “Digital-Portfolio”, 
          Уральский Федеральный университет имени первого 
          президента России Б.Н.Ельцина</p>
      </footer>
    </>
  )
}

export default App
