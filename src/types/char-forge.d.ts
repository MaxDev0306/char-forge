export type UserContextType = {
	isLoggedIn: boolean,
	toggleLoggedIn: () => void,
}

export type ThemeContextType = {
	darkMode: boolean,
	toggleDarkMode: () => void,
	setDarkMode: (darkMode: boolean) => void,
}