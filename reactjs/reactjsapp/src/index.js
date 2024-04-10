import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { AppProvider } from './Components/Context/context';
import Homepage from './Components/Homepage/Homepage';
//import { createServer } from 'http';
//import { Server } from "socket.io";

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
    <React.StrictMode>
        
        <App />
       
       
    </React.StrictMode>
    
);
//const httpServer = createServer();
//const io = new Server(httpServer, {
//    cors: {
//        origin: "http://localhost:3000/Msgpage",
//        methods: ["GET", "POST"],
//    },
//});
//io.on("connection", async (socket) => {

//});
//console.log("Listening to port....");
//httpServer.listen(process.env.PORT || 4000);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
