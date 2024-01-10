import React from 'react'
import ReactDOM from 'react-dom/client'
import './index.css'
import {createBrowserRouter, RouterProvider} from "react-router-dom";
import App from "./Main/App.tsx";
import CreationForm from "./Main/Character/Creation/CreationForm.tsx";
import ClassView from "./Main/Compendium/components/ClassView.tsx";

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

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
      <RouterProvider router={router} />
  </React.StrictMode>,
)
