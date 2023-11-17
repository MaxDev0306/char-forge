import React, {useEffect, useState} from 'react'
import { createRoot } from 'react-dom/client'
import App from './Main/App';
import {UserProvider} from './Main/lib/user-context';
import './index.css'
import {ThemeProvider} from './Main/lib/theme-context';
import {createBrowserRouter, RouterProvider} from 'react-router-dom';
import ClassView, {ApiClass, ApiClassResult} from "./Main/Compendium/components/ClassView";
import CreationForm from "./Main/Character/Creation/CreationForm";

const container = document.getElementById('root')!
const root = createRoot(container)



const router = createBrowserRouter([
	{
		path: "/",
		element: <App />,
		children: [
			{
				path: 'character',
				element: <CreationForm/>
			},
			{
				path: "classes",
				element: <ClassView />
			}
		]
	}
]);

root.render(
	<UserProvider>
		<ThemeProvider>
			<RouterProvider router={router} />
		</ThemeProvider>
	</UserProvider>
)