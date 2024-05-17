import { Input } from '@chakra-ui/react'
import { Button } from '@chakra-ui/react'
import axios from 'axios'
import React, { useState } from 'react';
import './RegistrationForm.css'
import { useVisibility } from './VisibilityContext';

function RegistrationForm() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [email, setEmail] = useState('');
    const [successMessage, setSuccessMessage] = useState('');
    const [errorMessage, setErrorMessage] = useState('');
    const { isRegistered } = useVisibility();
    const [loggedInUsername, setLoggedInUsername] = useState('');
    
  
    const handleSubmit = async (e) => {
      e.preventDefault();
  
      try {
        const response = await axios.post('https://localhost:7177/Users/Register', {
          username,
          password,
          email,
        });

        setSuccessMessage('Пользователь успешно зарегистрирован!');
        setLoggedInUsername(username);
        

        console.log(response.data);

      } catch (error) {

        setErrorMessage('Произошла ошибка при регистрации. Пожалуйста, попробуйте снова.');

        console.error(error.response.data);

      }
    };

    return (
      <>
        {!isRegistered && (
        <form onSubmit={handleSubmit} class="registration-menu">
            <Input type="text" value={username} onChange={(e) => setUsername(e.target.value)} placeholder="Логин" />
            <Input type="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Пароль" />
            <Input type="text" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Электронная почта" />
            <Button type="submit" colorScheme="orange">Регистрация</Button>
        </form>
        )}

        {successMessage && <p class="success-message">{successMessage}</p>}

        {errorMessage && <p class="error-message">{errorMessage}</p>}
      </>
    );
}

export default RegistrationForm;

