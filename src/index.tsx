import React from 'react'
import { createRoot } from 'react-dom/client'
import App from './Main/App';
import {UserProvider} from './Main/lib/user-context';
import './index.css'
import {ThemeProvider} from './Main/lib/theme-context';

const container = document.getElementById('root')!
const root = createRoot(container)



root.render(
	<UserProvider>
		<ThemeProvider>
			<App />
		</ThemeProvider>
	</UserProvider>
)