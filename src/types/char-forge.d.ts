export type UserContextType = {
    isLoggedIn: boolean,
    toggleLoggedIn: () => void,
}

export type ThemeContextType = {
    darkMode: boolean,
    toggleDarkMode: () => void,
    setDarkMode: (darkMode: boolean) => void,
}

export type DndClass = {
    name: string,
	hit_die: number
}

export type Attribute = {
    name: string,
    short: AttributeShort,
}

export type AttributeShort = 'CON'|'STR'|'DEX'|'INT'|'WIS'|'CHA';