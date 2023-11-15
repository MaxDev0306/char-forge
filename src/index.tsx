import React from 'react'
import { createRoot } from 'react-dom/client'
import App from './Main/App';
import {UserProvider} from './Main/lib/user-context';
import './index.css'
import {ThemeProvider} from './Main/lib/theme-context';
import {createBrowserRouter, RouterProvider} from 'react-router-dom';
import {QueryClient} from '@tanstack/react-query/build/modern';
import {QueryClientProvider} from '@tanstack/react-query';

const container = document.getElementById('root')!
const root = createRoot(container)
const queryClient = new QueryClient()
const router = createBrowserRouter([
	{
		path: "/",
		element: <App />,
		children: [
			{
				path: "/test",
				element: <h1>Hey</h1>
			}
		]
	}
]);

root.render(
	<UserProvider>
		<ThemeProvider>
			<QueryClientProvider client={queryClient}>
				<RouterProvider router={router} />
			</QueryClientProvider>
		</ThemeProvider>
	</UserProvider>
)