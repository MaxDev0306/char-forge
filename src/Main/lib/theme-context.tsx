import {createContext, PropsWithChildren, useState} from 'react';
import {ThemeContextType} from '../../types/char-forge';

export const ThemeContext = createContext<ThemeContextType|null>(null);

export const ThemeProvider = ({children}: PropsWithChildren) => {
	const [darkMode, setDarkMode] = useState<boolean>(false);

	const toggleDarkMode = () => {
	  setDarkMode(!darkMode);
	}

	return (
		<ThemeContext.Provider value={{darkMode, toggleDarkMode, setDarkMode}}>
			{children}
		</ThemeContext.Provider>
	)
}