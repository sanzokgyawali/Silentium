import {
  BrowserRouter as Router,
  Route,Routes, Link
} from "react-router-dom";
import './App.css';
import Login from './Components/Login';
import Verificationpage from './Components/Verificationpage';
import Otpverifiedmsg from './Components/Otpverifiedmsg';
import Screensaver from "./Components/Screensaver";
import Homepage from "./Components/Homepage/Homepage"

import Chatpage from "./Components/Chatpage/Chatpage";
import Createpostpage from "./Components/Homepage/Createpostpage";
import Msgpage from "./Components/Chatpage/Msgpage";
import Faqpage from "./Components/Faq/Faqpage";
import Notification from './Components/Notificationpage/Notification';
import { AppProvider } from "./Components/Context/context";




function App() {
    return (
     
    <div className="App">
            <Router>
                
     <Link to="login"></Link>
     <Routes>
      <Route path='/'element={<Login/>}></Route>
      <Route path="Verificationpage" element={<Verificationpage/>}></Route>
      <Route path="Otpverifiedmsg" element={<Otpverifiedmsg/>}></Route>
                    <Route path="screensaver" element={<Screensaver />}></Route>
                    <Route path="Homepage" element={<AppProvider><Homepage /></AppProvider>}></Route>
      <Route path="Createpostpage" element={<Createpostpage/>}></Route>

      <Route path="Chatpage" element={<Chatpage/>}></Route>

      <Route path="Msgpage" element={<Msgpage/>}></Route>
      <Route path="Faqpage" element={<Faqpage/>}></Route>

      <Route path="Notification" element={<Notification/>}></Route>

     
                    </Routes>
              
     </Router>
            
      </div>
   
  );
}

export default App;
