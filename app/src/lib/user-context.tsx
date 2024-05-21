import {createContext, PropsWithChildren, useState} from 'react';
import {UserContextType} from '../../types/char-forge';

export const UserContext = createContext<UserContextType|null>(null);
export const UserProvider = ({children}: PropsWithChildren) => {
	const [isLoggedIn, setIsLoggedIn] = useState<boolean>(false);

	const toggleLoggedIn = () => {
		setIsLoggedIn(!isLoggedIn);
	}

	return (
		<UserContext.Provider value={{isLoggedIn, toggleLoggedIn}}>
			{children}
		</UserContext.Provider>
	)
}
