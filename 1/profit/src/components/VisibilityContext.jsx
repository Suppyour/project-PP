import React, { createContext, useContext, useState } from 'react';

const VisibilityContext = createContext();

export function VisibilityProvider({ children }) {
    const [isRegistered, setIsRegistered] = useState(false);
    const [loggedInUsername, setLoggedInUsername] = useState('');

    return (
        <VisibilityContext.Provider value={{ isRegistered, setIsRegistered, loggedInUsername, setLoggedInUsername }}>
            {children}
        </VisibilityContext.Provider>
    );
}

export function useVisibility() {
    return useContext(VisibilityContext);
}