import { Input, Button } from '@chakra-ui/react';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import './LoginForm.css';
import { useVisibility } from './VisibilityContext';
import CreateMainPage from './CreateMainPage';

function LoginForm() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [userData, setUserData] = useState(null);
    const [showLogin, setShowLogin] = useState(true);
    const { setIsRegistered } = useVisibility();

    

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('https://localhost:7177/Users/Login', {
                email,
                password,
            }, {
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.status === 200) {
                console.log("Успешный вход");
                setUserData(response.data);
                setShowLogin(false); 
                setIsRegistered(true);
            }
        } catch (error) {
            console.error("Ошибка входа", error);
        }
    };

    const logout = () => { 
        setUserData(null);
        setShowLogin(true);
    };

    return (
        <div>
            {showLogin? ( 
                <form onSubmit={handleSubmit} className="login-menu">
                    <Input type="text" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Электронная почта" />
                    <Input type="password" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Пароль" />
                    <Button type="submit" colorScheme="orange">Войти</Button>
                </form>
            ) : (
                <>
                    <div class="exit-button">
                        <Button onClick={logout} >Выход из аккаунта</Button>
                    </div>
                    <CreateMainPage />
                </>
            )}
        </div>
    );
}

export default LoginForm;