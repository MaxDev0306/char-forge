import React, {useContext} from 'react';
import {UserContext} from './lib/user-context';
import {ThemeContextType, UserContextType} from '../types/char-forge';
import {Button, Switch} from 'antd';
import {ThemeContext} from './lib/theme-context';
import {MdOutlineDarkMode, MdOutlineLightMode} from 'react-icons/md';

export default function App() {

	const { isLoggedIn, toggleLoggedIn } = useContext(UserContext) as UserContextType;

	const {darkMode, toggleDarkMode, setDarkMode} = useContext(ThemeContext) as ThemeContextType;

	return (
		<div id={"app"} style={{backgroundColor: darkMode ? 'darkgrey' : 'white'}}>
			<span>{isLoggedIn ? 'LoggedIn' : 'Please Log In'}</span>
			<Button onClick={toggleLoggedIn}>Toggle</Button>
			<Button onClick={toggleDarkMode}>Toggle Theme</Button>
			<Switch onChange={(e) => setDarkMode(e)} checked={darkMode} checkedChildren={<MdOutlineDarkMode />} unCheckedChildren={<MdOutlineLightMode />}/>
		</div>
	)
}